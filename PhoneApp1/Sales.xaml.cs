using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace SummonersHQ
{
    public partial class Sales : PhoneApplicationPage
    {
        List<SaleItem> unSortedSales = new List<SaleItem>();

        public Sales()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Sales_Loaded);
        }

        void Sales_Loaded(object sender, RoutedEventArgs e)
        {
            if ((Application.Current as App).saleList == null || 
                (Application.Current as App).saleList.championsOnSale.Count == 0 ||
                (Application.Current as App).saleList.skinsOnSale.Count == 0)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    getSalesList();
                }
                else
                {
                    OfflinePanel.Visibility = Visibility.Visible;
                    SalesPanel.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                this.DataBindView((Application.Current as App).saleList);
            }
            return;
        }

        private void getSalesList()
        {
            Uri wikiSalesAddress = new Uri("http://leagueoflegends.wikia.com/api.php?action=query&prop=revisions&titles=League_of_Legends_Wiki/Sale&rvprop=content&rvgeneratexml=true&format=json");
            HttpWebRequest getSalesRequest = (HttpWebRequest)WebRequest.Create(wikiSalesAddress);
            getSalesRequest.BeginGetResponse(GetSalesResponse, getSalesRequest);
        }

        private void GetSalesResponse(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;

            if (request != null)
            {
                WebResponse response = request.EndGetResponse(result);
                Stream outStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(outStream);
                string xmlResult = reader.ReadToEnd();

                var wikiRevisionObject = JsonConvert.DeserializeObject<WikiSales>(xmlResult);

                WikiSales wikiSale = wikiRevisionObject as WikiSales;

                revisions[] revisionArray = wikiSale.query.pages.pageDetails.revisions;

                string revisionText = revisionArray[0].parsetree;

                SalesList salesList = new SalesList();

                XDocument xdoc = XDocument.Parse(revisionText);

                XElement rootNode = xdoc.Element("root");

                IEnumerable<XElement> templates = rootNode.Elements("template");

                foreach (XElement template in templates)
                {
                    unSortedSales.Clear();
                    IEnumerable<XElement> partsNodes = template.Elements("part");
                    foreach (XElement part in partsNodes)
                    {
                        if (part.HasElements)
                        {
                            XElement name = part.Element("name");
                            string nameValue = name.Value.Trim();
                            StorePart(salesList, part, nameValue);
                        }
                    }
                }

                salesList.Import(unSortedSales);
                (Application.Current as App).saleList = salesList;
                DataBindView(salesList);
            }
        }

        private void StorePart(SalesList salesList, XElement part, string nameValue)
        {
            switch (nameValue)
            {
                case "enddate":
                    salesList.enddate = part.Element("value").Value.Trim();
                    break;
                case "startdate":
                    salesList.startdate = part.Element("value").Value.Trim();
                    break;
                default:
                    if (nameValue.Contains("champ"))
                    {
                        int champId = int.Parse(nameValue.Replace("champ", String.Empty).Trim());
                        if (MemoryContainSaleItem(champId))
                        {
                            SaleItem si = GetSaleItem(champId);
                            si.champName = part.Element("value").Value.Trim();
                        }
                        else
                        {
                            SaleItem newSales = new SaleItem()
                            {
                                champId = champId,
                                champName = part.Element("value").Value.Trim()
                            };
                            unSortedSales.Add(newSales);
                        }
                    }
                    else if (nameValue.Contains("ip"))
                    {
                        int champId = int.Parse(nameValue.Replace("ip", String.Empty).Trim());
                        if (MemoryContainSaleItem(champId))
                        {
                            SaleItem si = GetSaleItem(champId);
                            si.ipPrice = part.Element("value").Value.Trim();
                        }
                        else
                        {
                            SaleItem newSales = new SaleItem()
                            {
                                champId = champId,
                                ipPrice = part.Element("value").Value.Trim()
                            };
                            unSortedSales.Add(newSales);
                        }
                    }
                    else if (nameValue.Contains("price"))
                    {
                        int champId = int.Parse(nameValue.Replace("price", String.Empty).Trim());
                        if (MemoryContainSaleItem(champId))
                        {
                            SaleItem si = GetSaleItem(champId);
                            si.rpPrice = part.Element("value").Value.Trim();
                        }
                        else
                        {
                            SaleItem newSales = new SaleItem()
                            {
                                champId = champId,
                                rpPrice = part.Element("value").Value.Trim()
                            };
                            unSortedSales.Add(newSales);
                        }
                    }
                    else if (nameValue.Contains("skin"))
                    {
                        int champId = int.Parse(nameValue.Replace("skin", String.Empty).Trim());
                        if (MemoryContainSaleItem(champId))
                        {
                            SaleItem si = GetSaleItem(champId);
                            si.skinName = part.Element("value").Value.Trim();
                            si.skinSale = true;
                        }
                        else
                        {
                            SaleItem newSales = new SaleItem()
                            {
                                champId = champId,
                                skinName = part.Element("value").Value.Trim(),
                                skinSale = true
                            };
                            unSortedSales.Add(newSales);
                        }
                    }
                    break;
            }
        }

        private void DataBindView(SalesList sales)
        {
            Dispatcher.BeginInvoke(() =>
            {
                DurationTimeText.Text = sales.startdate + " to " + sales.enddate;
                championSaleListBox.ItemsSource = sales.championsOnSale;
                skinSaleListBox.ItemsSource = sales.skinsOnSale;
            });
        }

        private bool MemoryContainSaleItem(int itemId)
        {
            foreach (SaleItem si in unSortedSales)
            {
                if (si.champId == itemId)
                    return true;
            }
            return false;
        }

        private SaleItem GetSaleItem(int itemId)
        {
            foreach (SaleItem si in unSortedSales)
            {
                if (si.champId == itemId)
                    return si;
            }
            return null;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml?id=3", UriKind.Relative));
        }
    }
}