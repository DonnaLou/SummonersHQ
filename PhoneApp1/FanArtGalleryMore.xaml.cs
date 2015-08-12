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
using System.IO;
using System.Windows.Media.Imaging;

namespace SummonersHQ
{
    public partial class FanArtGalleryMore : PhoneApplicationPage
    {
        int pageIndex = 0;
        int pagingLimit = 100;

        public FanArtGalleryMore()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(fanArtGallery_Loaded);
        }

        private void fanArtGallery_Loaded(object sender, RoutedEventArgs e)
        {
            pageIndex = NavigationContext.QueryString.Keys.Count > 0 ? int.Parse(NavigationContext.QueryString["pageIndex"]) : 0;
            queryForGalleryData(pageIndex);
        }


        private void queryForGalleryData(int queryIndex)
        {
            Uri getGalleryAddress = new Uri("http://iambivalenc3.tumblr.com/api/read?tagged=league+of+legends&type=photo&start=" + queryIndex);

            HttpWebRequest getGalleryRequest = (HttpWebRequest)WebRequest.Create(getGalleryAddress);
            getGalleryRequest.BeginGetResponse(getGalleryResponse, getGalleryRequest);
        }

        void getGalleryResponse(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;

            if (request.HaveResponse)
            {
                try
                {
                    List<String> imageUriList400px = new List<String>();
                    List<String> imageUriList250px = new List<String>();

                    WebResponse response = request.EndGetResponse(result);
                    Stream outStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(outStream);
                    string xmlResult = reader.ReadToEnd();

                    HtmlAgilityPack.HtmlDocument xdoc = new HtmlAgilityPack.HtmlDocument();
                    xdoc.LoadHtml(xmlResult);

                    HtmlAgilityPack.HtmlNodeCollection posts = xdoc.DocumentNode.SelectNodes("tumblr/posts/post[@type='photo']");
                    if (posts != null)
                    {
                        foreach (HtmlAgilityPack.HtmlNode post in posts)
                        {
                            string targetUri400 = post.SelectSingleNode("photo-url[@max-width='400']").InnerHtml;
                            imageUriList400px.Add(targetUri400);
                            string targetUri250 = post.SelectSingleNode("photo-url[@max-width='250']").InnerHtml;
                            imageUriList250px.Add(targetUri250);
                        }
                    }
                    populatePivot(imageUriList400px, imageUriList250px);
                }
                catch (WebException e)
                {
                    return;
                }
            }
            else
            {
                //Show try again later err msg;
            }
        }
       
        private void populatePivot(List<String> imageUriList400, List<String> imageUriList250)
        {
            Dispatcher.BeginInvoke(() =>
            {
                int deleteIndex = GalleryPivot.Items.Count -1;
                List<PivotItem> addPivots = new List<PivotItem>();

                for (int i = 0; i < imageUriList400.Count - 1; i++)
                {
                    string uriCopy400 = imageUriList400[i];
                    string uriCopy250 = imageUriList250[i];
                    int imageNumber = i;
                    PivotItem p = new PivotItem() { Header = "-->" };

                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(uriCopy400));

                    if(img.ActualHeight > 650)          //use smaller image if width will be too long
                        img.Source = new BitmapImage(new Uri(uriCopy250));

                    p.Content = img;

                    GalleryPivot.Items.Add(p);
                }

                if (this.pageIndex < this.pagingLimit)
                {
                    PivotItem loadMorePivotItem = new PivotItem() { Header = "more?" };
                    Image btnImg = new Image() { Source = new BitmapImage(new Uri("Images/kogBtn.jpg", UriKind.Relative)) };
                    btnImg.Tap += loadMoreBtn_Click;
                    loadMorePivotItem.Content = btnImg;
                    GalleryPivot.Items.Add(loadMorePivotItem);
                }
                else
                {
                    PivotItem loadMorePivotItem = new PivotItem() { Header = "end" };
                    Image btnImg = new Image() { Source = new BitmapImage(new Uri("Images/wwEnd.png", UriKind.Relative)) };
                    loadMorePivotItem.Content = btnImg;
                    GalleryPivot.Items.Add(loadMorePivotItem);
                }

                if (this.pageIndex > 0)
                    GalleryPivot.Items.Remove(GalleryPivot.Items[deleteIndex]);

                if (this.pageIndex == 0)
                    loadingLabel.Text = "";

                GalleryPivot.SelectedIndex = deleteIndex;

            });
        }

        protected void loadMoreBtn_Click(object sender, RoutedEventArgs e)
        {
            this.pageIndex += 20;
            NavigationService.Navigate(new Uri("/FanArtGalleryMore.xaml?pageIndex=" + this.pageIndex, UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml?id=0", UriKind.Relative));
        }
    }
}