using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Net.NetworkInformation;

namespace SummonersHQ
{
    public class Patch
    {
        public string date{get; set;}
        public string version{get; set;}
        public string patchURL { get; set; }
    }

    public partial class PatchList : PhoneApplicationPage
    {
        List<Patch> patchLinks = new List<Patch>();

        public PatchList()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(PatchList_Loaded);
        }

        void PatchList_Loaded(object sender, RoutedEventArgs e)
        {
            if ((Application.Current as App).patchNotesList == null || (Application.Current as App).patchNotesList.Count == 0)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    getPatchLinks();
                }
            }
            else
            {
                this.patchLinks = (Application.Current as App).patchNotesList;
                this.patchListBox.ItemsSource = patchLinks;
            }

            return;
        }

        private void getPatchLinks()
        {
            WebClient client = new WebClient();

            client.AllowReadStreamBuffering = true;
            client.DownloadStringCompleted += (client_getPatchLinks);
            client.DownloadStringAsync(new Uri("http://leaguecraft.com/patches/"));
        }

        void client_getPatchLinks(object sender, DownloadStringCompletedEventArgs e)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(e.Result);

            string xpath = "//*[@id='core_content_container']/div[1]/div/div/table";

            HtmlAgilityPack.HtmlNode containerNode = doc.DocumentNode.SelectSingleNode(xpath);
            HtmlAgilityPack.HtmlNodeCollection tableNodes = containerNode.SelectNodes("tr");

            for(int i = 0; i<15; i++)
            {
                Patch localPatch = new Patch();
                localPatch.version = tableNodes[i].ChildNodes[3].ChildNodes[0].InnerHtml;
                localPatch.date = tableNodes[i].ChildNodes[1].InnerHtml;
                localPatch.patchURL = tableNodes[i].ChildNodes[3].ChildNodes[0].GetAttributeValue("href", "").Replace("/patches/", String.Empty);
                patchLinks.Add(localPatch);
            }
            this.patchListBox.ItemsSource = patchLinks;

            (Application.Current as App).patchNotesList = patchLinks;
        }

        protected void listBox_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            //Get the data object that represents the current selected item
            Patch data = (sender as ListBox).SelectedItem as Patch;
            NavigationService.Navigate(new Uri("/PatchPage.xaml?version=" + data.patchURL, UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml?id=2", UriKind.Relative));
        }

    }
}