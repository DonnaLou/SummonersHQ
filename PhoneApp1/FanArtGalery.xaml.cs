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
using System.Xml.Linq;
using System.Windows.Media.Imaging;

namespace PhoneApp1
{
    public partial class FanArtGalery : PhoneApplicationPage
    {
        List<String> imageUriList = new List<String>();

        public FanArtGalery()
        {
            InitializeComponent();
            queryForGalleryData();
        }
        
        private void queryForGalleryData()
        {
            Uri getGalleryAddress = new Uri("http://iambivalenc3.tumblr.com/api/read?tagged=league+of+legends&type=photo");

            HttpWebRequest getGalleryRequest = (HttpWebRequest)WebRequest.Create(getGalleryAddress);
            getGalleryRequest.BeginGetResponse(getGalleryResponse, getGalleryRequest);

            
        }

        void getGalleryResponse(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
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

                    HtmlAgilityPack.HtmlNodeCollection posts = xdoc.DocumentNode.SelectNodes("tumblr/posts/post[@type='photo']");
                    foreach (HtmlAgilityPack.HtmlNode post in posts)
                    {
                        string targetUri = post.SelectSingleNode("photo-url[@max-width='400']").InnerHtml;
                        imageUriList.Add(targetUri);
                    }
                    populatePivot();
                }
                catch (WebException e)
                {
                   return;
                }
            }
        }
       
        private void populatePivot()
        {

            for ( int i = 0; i < imageUriList.Count-1; i++)
            {
                string uriCopy = imageUriList[i];
                string imageNumber = (i+1).ToString();
                Dispatcher.BeginInvoke(() =>
                {
                    PivotItem p = new PivotItem();
                    p.Header = "item" + imageNumber;
                    Image img = new Image();

                    img.Source = new BitmapImage(new Uri(uriCopy));
                    p.Content = img;
                    GalleryPivot.Items.Add(p);
                });
            }
        }

    }
}