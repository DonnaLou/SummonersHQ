using System;
using System.Net;
using Microsoft.Phone.Controls;
using System.Windows;
using System.Windows.Media;
using System.Net.NetworkInformation;

namespace SummonersHQ
{
    public partial class PatchPage : PhoneApplicationPage
    {
        public string html;
        public string targetPatchVersion = String.Empty;

        public PatchPage()                      //Page to display latest Patch
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(patchPage_Loaded);
        }


        private void patchPage_Loaded(object sender, RoutedEventArgs e)
        {
            String patchVersion = NavigationContext.QueryString.Keys.Count > 0 ? NavigationContext.QueryString["version"] : "";
            targetPatchVersion = patchVersion;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (String.IsNullOrEmpty(targetPatchVersion))
                {
                    ScrapeForLatestPatchUri();
                }
                else
                {
                    ScrapePatchSite();
                }
            }
            else
            {
                browserControl.NavigateToString("Internet Connection Required");
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void ScrapeForLatestPatchUri()
        {
            WebClient client = new WebClient();
            //client.DownloadStringAsync(new Uri("http://lol-patch.com"));
            client.DownloadStringAsync(new Uri("http://leaguecraft.com/patches/"));
            client.AllowReadStreamBuffering = true;
            client.DownloadStringCompleted += (client_GetLatestPatchUri);             
        }

        void client_GetLatestPatchUri(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FormatForBrowser("Server is some technical difficulties. <br/>Please try again later.");
            }
            else
            {
                string pageSource = e.Result;
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(pageSource);

                string xpath = "//*[@id='core_content_container']/div[1]/div/div/table/tr/td[2]";

                HtmlAgilityPack.HtmlNode latestPatchNode =
                   doc.DocumentNode.SelectSingleNode(xpath);

                string latestPatchNodeLink = latestPatchNode.ChildNodes[0].GetAttributeValue("href", "");

                targetPatchVersion = latestPatchNodeLink.Replace("/patches/", string.Empty);

                ScrapePatchSite();
            }
        }

        private void ScrapePatchSite()
        {
            WebClient client = new WebClient();
            //client.DownloadStringAsync(new Uri("http://lol-patch.com/"+targetPatchVersion));
            client.DownloadStringAsync(new Uri("http://leaguecraft.com/patches/" + targetPatchVersion));
            client.AllowReadStreamBuffering = true;
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_GetPatchDetail);
        }

        void client_GetPatchDetail(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FormatForBrowser("SORRY! Patch information Not Found<br/> Please try another patch.");
            }
            else
            {
                string pageSource = e.Result;
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(pageSource);

                HtmlAgilityPack.HtmlNode containerNode = doc.DocumentNode.SelectSingleNode("//*[@id='core_content_container']/div[1]/div/div");

                string versionNumber = containerNode.SelectSingleNode("h1").InnerText.Replace("Patch ", String.Empty);

                PageTitle.Text = versionNumber;

                string patchBody = containerNode.SelectSingleNode("h1").NextSibling.NextSibling.InnerHtml;

                HtmlAgilityPack.HtmlDocument patchBodyHtml = new HtmlAgilityPack.HtmlDocument();
                patchBodyHtml.LoadHtml(patchBody);

                //Trim Empty nodes at the beginning
                while (String.IsNullOrEmpty(patchBodyHtml.DocumentNode.FirstChild.OuterHtml.Trim()))
                {
                    patchBodyHtml.DocumentNode.FirstChild.Remove();
                }

                //Trim Empty nodes at the end
                while (String.IsNullOrEmpty(patchBodyHtml.DocumentNode.LastChild.OuterHtml.Trim()))
                {
                    patchBodyHtml.DocumentNode.LastChild.Remove();
                }

                patchBodyHtml.LoadHtml(patchBodyHtml.DocumentNode.InnerHtml.Trim());

                //Remove href links at the end
                while (patchBodyHtml.DocumentNode.SelectSingleNode("p/a") != null)
                {
                    patchBodyHtml.DocumentNode.SelectSingleNode("p/a").Remove();
                }

                while (patchBodyHtml.DocumentNode.SelectSingleNode("/a") != null)
                {
                    patchBodyHtml.DocumentNode.SelectSingleNode("/a").Remove();
                }

                //Remove any embedded youtube video 
                if (patchBodyHtml.DocumentNode.SelectSingleNode("p/iframe") != null)
                {
                    patchBodyHtml.DocumentNode.SelectSingleNode("p/iframe").Remove();
                }

                FormatForBrowser(patchBodyHtml.DocumentNode.OuterHtml);
            }
        }

        private void FormatForBrowser(String patchBodyHtml)
        {
            html = patchBodyHtml;

            Color backgroundColor = (Color)((Application.Current as App).Resources["PhoneBackgroundColor"]);
            string bgColor = backgroundColor.ToString();
            string fontColor = "#000";
            if (bgColor == "#FF000000")
            {
                fontColor = "#fff";
                bgColor = "#000";
            }

            var htmlConcat = string.Format("<html>" +
              "<body style=\"margin:0px;padding:0px;background-color:{2};\" " +
              "<div id=\"pageWrapper\" style=\"width:100%; color:{1}; " +
              "background-color:{2}\">{0}</div></body></html>",
              html,
              fontColor,
              bgColor);

            browserControl.NavigateToString(htmlConcat);
        }      
    }
}