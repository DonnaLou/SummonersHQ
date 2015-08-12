using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Net.NetworkInformation;
using System.IO;

namespace SummonersHQ
{
    public class updates
    {
        public string message {get; set;}
        public string dateMessage { get; set; }
    }
    public partial class Information : PhoneApplicationPage
    {
        public Information()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(PatchList_Loaded);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml?id=5", UriKind.Relative));
        }

        void PatchList_Loaded(object sender, RoutedEventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                queryForUpdates();
            }
            else
            {
                return;
            }
        }


        private void queryForUpdates()
        {
            Uri getUpdatesUrl = new Uri("http://summonerhq.tumblr.com/api/read");

            HttpWebRequest getUpdateRequest = (HttpWebRequest)WebRequest.Create(getUpdatesUrl);
            getUpdateRequest.BeginGetResponse(getUpdateResponse, getUpdateRequest);
        }

        void getUpdateResponse(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            List<updates> updateList = new List<updates>();
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);
                    Stream outStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(outStream);
                    string xmlResult = reader.ReadToEnd();

                    HtmlAgilityPack.HtmlDocument xdoc = new HtmlAgilityPack.HtmlDocument();
                    xdoc.LoadHtml(xmlResult);

                    HtmlAgilityPack.HtmlNodeCollection posts = xdoc.DocumentNode.SelectNodes("tumblr/posts/post[@type='regular']");
                    foreach (HtmlAgilityPack.HtmlNode post in posts)
                    {
                        string updateString = post.SelectSingleNode("regular-body").InnerText.Replace("&lt;p&gt;", String.Empty).Replace("&lt;/p&gt;", String.Empty);
                        string dateString = DateTime.Parse(post.GetAttributeValue("date", "")).ToString("MMM dd, yyyy");
                        updateList.Add(new updates() {message = updateString, dateMessage = dateString});
                    }

                    if (updateList.Count > 0)
                    {
                        Dispatcher.BeginInvoke(() =>
                        {
                            updateListBox.ItemsSource = updateList;
                        });
                    }
                }
                catch (WebException e)
                {
                    return;
                }
            }
        }
    }
}