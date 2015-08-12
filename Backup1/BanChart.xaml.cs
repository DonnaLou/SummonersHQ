using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace SummonersHQ
{
    public partial class BanChart : PhoneApplicationPage
    {
        private string NARank = "http://www.lolking.net/charts?region=na&league=ranked&type=bans&range=weekly";
        private string EUWRank = "http://www.lolking.net/charts?region=euw&league=ranked&type=bans&range=weekly";
        private string EUNERank = "http://www.lolking.net/charts?region=eune&league=ranked&type=bans&range=weekly";

        private string server;
        public BanChart()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(BanChart_Loaded);
        }

        void BanChart_Loaded(object sender, RoutedEventArgs e)
        {
            server = NavigationContext.QueryString.Keys.Count > 0 ? NavigationContext.QueryString["version"] : "";

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    getBanData();
                }
                catch
                {
                    ErrorPanel.Visibility = Visibility.Visible;
                    BanListGrid.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                OfflinePanel.Visibility = Visibility.Visible;
                BanListGrid.Visibility = Visibility.Collapsed;
            }
            
            return;
        }

        private void getBanData()
        {
            WebClient client = new WebClient();
            Uri dataUri = new Uri(NARank);

            if (server == "euw")
                dataUri = new Uri(EUWRank);
            else if (server == "eune")
                dataUri = new Uri(EUNERank);

            client.AllowReadStreamBuffering = true;
            client.DownloadStringCompleted += (client_getBanDataSet);
            client.DownloadStringAsync(dataUri);
        }

         void client_getBanDataSet(object sender, DownloadStringCompletedEventArgs e)
         {
             HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
             doc.LoadHtml(e.Result);

             string xpath = "//*[@id='container_inner']/script/text()";

             HtmlAgilityPack.HtmlNode containerNode = doc.DocumentNode.SelectSingleNode(xpath);

             string info = containerNode.InnerHtml.Replace("\n", string.Empty).Replace("\t", String.Empty);

             int startIndexOf = info.LastIndexOf("groups");

             string subString = info.Substring(startIndexOf);

             int endIndexOf = subString.LastIndexOf("graph.draw");

             string updateSubString = subString.Substring(0, endIndexOf);

             Match match = Regex.Match(subString, @"(^groups').+}}");

             String jsonValue = String.Empty;
             BanList banData = new BanList();

             if (match.Success)
             {
                 string groups = match.Groups[0].Value.Replace("'", "\"");

                 jsonValue = "{\"" + groups + "]}";
                 banData = JsonConvert.DeserializeObject<BanList>(jsonValue);
             }

             if (banData.groups.Count() > 0)
             {
                 Dispatcher.BeginInvoke(() =>
                 {
                     if (server == "euw")
                         PageTitle.Text = "Top Ban EUW";
                     else if (server == "eune")
                         PageTitle.Text = "Top Ban EUNE";
                     else
                         PageTitle.Text = "Top Ban NA";

                     champBanList.ItemsSource = banData.groups.ToList<BanChampion>();

                 });
             }
         }

         protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
         {
             NavigationService.Navigate(new Uri("/Menu.xaml?id=4", UriKind.Relative));
         }

    }
}