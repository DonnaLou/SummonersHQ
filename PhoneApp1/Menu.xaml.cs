using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.Net.NetworkInformation;
using System.Windows.Controls;

namespace SummonersHQ
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        List<Group> panoramaGroups = new List<Group>();
        List<Events> panoramaEvents = new List<Events>();

        private bool hasNoGroupEventData()
        {
            return ((Application.Current as App).panoramaEvents == null) || ((Application.Current as App).panoramaGroups == null)
                || (Application.Current as App).panoramaGroups.Count == 0 || (Application.Current as App).panoramaEvents.Count == 0;
        }

        public PanoramaPage1()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (hasNoGroupEventData())
                {
                    if ((Application.Current as App).panoramaGroups == null || (Application.Current as App).panoramaGroups.Count == 0)
                    {
                        Uri getGroupAddress = new Uri("https://api.meetup.com/2/groups.xml?key=763d215944377480693c592a17334449&sign=true&topic=league-of-legends&page=20");
                        HttpWebRequest getGroupsRequest = (HttpWebRequest)WebRequest.Create(getGroupAddress);
                        getGroupsRequest.BeginGetResponse(GetGroupsResponse, getGroupsRequest);
                    }

                    if ((Application.Current as App).panoramaEvents == null || (Application.Current as App).panoramaEvents.Count == 0)
                    {
                        Uri getEventAddress = new Uri("https://api.meetup.com/2/open_events.xml?key=763d215944377480693c592a17334449&sign=true&text_format=plain&topic=league-of-legends&page=20");
                        HttpWebRequest getEvents = (HttpWebRequest)WebRequest.Create(getEventAddress);
                        getEvents.BeginGetResponse(GetEventsResponse, getEvents);
                    }
                }
                else
                {
                    this.panoramaEvents = (Application.Current as App).panoramaEvents;
                    this.panoramaGroups = (Application.Current as App).panoramaGroups;
                    Dispatcher.BeginInvoke(() =>
                    {
                        DispatchGroupInfo();
                        DispatchEventInfo();
                    });
                }
            }
            else
            {   
                txtGroup.Text = "Wifi/Data plan plz :( ";
                nextEventTxt.Text = "I need internet plz!";
            }
        }

        #region navigations
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            String id = NavigationContext.QueryString.Keys.Count > 0? NavigationContext.QueryString["id"]:"0" ;
            int selectionIndex = int.Parse(id);
            panoramaControl.DefaultItem = panoramaControl.Items[selectionIndex];
            base.OnNavigatedTo(e);
        }

        protected void NaviToFanArt(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FanArtGallery.xaml", UriKind.Relative));
        }

        protected void NaviToEvents(object sender, EventArgs e)
        {
           
            NavigationService.Navigate(new Uri("/EventsListPage.xaml", UriKind.Relative));
        }

        protected void NaviToGroups(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/GroupListPage.xaml", UriKind.Relative));
        }

        protected void NaviToPatches(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PatchList.xaml", UriKind.Relative));
        }

        protected void NaviToLatestPatch(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PatchPage.xaml", UriKind.Relative));
        }

        protected void NaviToSales(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Sales.xaml", UriKind.Relative));
        }

        protected void NaviToMastery(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MasteryPage.xaml", UriKind.Relative));
        }

        protected void NaviToBans(object sender, EventArgs e)
        {
            StackPanel stack = sender as StackPanel;
            string stacktag = stack.Tag.ToString();

            switch (stacktag)
            {
                case "na":
                    NavigationService.Navigate(new Uri("/BanChart.xaml?version=na", UriKind.Relative));
                    break;
                case "euw":
                    NavigationService.Navigate(new Uri("/BanChart.xaml?version=euw", UriKind.Relative));
                    break;
                default:
                    NavigationService.Navigate(new Uri("/BanChart.xaml?version=eune", UriKind.Relative));
                    break;
            }
        }

        protected void faqTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FAQPage.xaml", UriKind.Relative));
        }

        protected void infoTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Information.xaml", UriKind.Relative));
        }

        protected void supportTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Support.xaml", UriKind.Relative));
        }

        protected void upComingEventTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (panoramaEvents.Count > 0)
            {
                (Application.Current as App).selectedEvent = this.panoramaEvents[0];
                NavigationService.Navigate(new Uri("/EventsPage.xaml", UriKind.Relative));
            }
        }

        private void tapGroupOne(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (panoramaGroups.Count > 0)
            {
                (Application.Current as App).selectedGroup = this.panoramaGroups[0];
                NavigationService.Navigate(new Uri("/GroupsPage.xaml", UriKind.Relative));
            }
        }

        #endregion


        private void GetGroupsResponse(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);
                    Stream outStream = response.GetResponseStream();
                    StreamReader reader =  new StreamReader(outStream);
                    string xmlResult = reader.ReadToEnd();
                    XDocument xdoc = XDocument.Parse(xmlResult);

                    IEnumerable<XElement> items = xdoc.Descendants("item");
                    foreach (XElement item in items)
                    {
                        String groupName = item.Element("name").Value;
                        String city = item.Element("city").Value;
                        XElement descriptionNode = item.Element("description");

                        HtmlAgilityPack.HtmlDocument descriptionHtml = new HtmlAgilityPack.HtmlDocument();
                        descriptionHtml.LoadHtml(descriptionNode.Value);

                        while (descriptionHtml.DocumentNode.SelectSingleNode("p/img") != null)
                        {
                            descriptionHtml.DocumentNode.SelectSingleNode("p/img").Remove();
                        }

                        while (descriptionHtml.DocumentNode.SelectSingleNode("p/a") != null)
                        {
                            descriptionHtml.DocumentNode.SelectSingleNode("p/a").Remove();
                        }

                        String description = RemoveHtmlTags(descriptionHtml.DocumentNode.OuterHtml);
                       
                        String link = item.Element("link").Value;
                        long count = long.Parse(item.Element("members").Value);
                        String country = item.Element("country").Value.ToString();
                        String logoUrl = item.Element("group_photo") != null? item.Element("group_photo").Element("thumb_link").Value : "";

                        Group newGroup = new Group(groupName, city);
                        newGroup.description = description;
                        newGroup.uri = link;
                        newGroup.memberCount = count;
                        newGroup.country = country;
                        newGroup.logoUri = logoUrl;

                        panoramaGroups.Add(newGroup);
                    }

                    Dispatcher.BeginInvoke(() =>
                    {
                        DispatchGroupInfo();
                    });

                    (Application.Current as App).panoramaGroups = this.panoramaGroups;
                }
                catch (WebException e)
                {
                    return ;
                }
            }
        }

        void GetEventsResponse(IAsyncResult result)
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
                    XDocument xdoc = XDocument.Parse(xmlResult);

                    IEnumerable<XElement> items = xdoc.Descendants("item");
                    foreach (XElement item in items)
                    {
                        String eventName = item.Element("name") != null ? item.Element("name").Value : "";
                        String description = item.Element("description") != null? (RemoveHtmlTags(item.Element("description").Value)) : ""; 
                        String findUs = item.Element("how_to_find_us") != null ? item.Element("how_to_find_us").Value : "";
                        String eventUrl = item.Element("event_url").Value;
                        int yesRsvp = item.Element("yes_rsvp_count") != null ? int.Parse(item.Element("yes_rsvp_count").Value) : 99999;
                        int rsvpLimit = item.Element("rsvp_limit") != null ? int.Parse(item.Element("rsvp_limit").Value) : 99999;
                        int maybeRsvp = item.Element("maybe_rsvp_count") != null ? int.Parse(item.Element("maybe_rsvp_count").Value) : 99999;
                        double time = double.Parse(item.Element("time").Value);
                        double timeOffSet = double.Parse(item.Element("utc_offset").Value);
                        double eventDuration = item.Element("duration") != null ? double.Parse(item.Element("duration").Value) : 0;

                        long groupId = long.Parse(item.Element("group").Element("id").Value);

                        DateTime eventStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        eventStartTime = eventStartTime.AddMilliseconds(time + timeOffSet);

                        DateTime eventEndTime = eventStartTime.AddMilliseconds(eventDuration);

                        XElement venueNode = item.Element("venue");

                        Venue venue = null;
                        if (venueNode != null)
                        {
                            venue = GetVenue(venueNode);
                        }
                       
                        Events newEvent = new Events(eventName, description, venue);
                        newEvent.eventURL = eventUrl;
                        newEvent.howToFindUs = findUs;
                        newEvent.yesRsvp = yesRsvp;
                        newEvent.rsvpLimit = rsvpLimit;
                        newEvent.maybeRsvp = maybeRsvp;
                        newEvent.eventStartTime = eventStartTime;
                        newEvent.eventEndTime = eventEndTime;
                        newEvent.groupId = groupId;

                        panoramaEvents.Add(newEvent);
                    }

                    Dispatcher.BeginInvoke(() =>
                    {
                        DispatchEventInfo();
                    });

                    (Application.Current as App).panoramaEvents = this.panoramaEvents;
                }
                catch (WebException e)
                {
                    return;
                }
            }
        }

        private void DispatchGroupInfo()
        {
            for (int i = 0; i < panoramaGroups.Count - 1; i++)
            {
                if (!String.IsNullOrEmpty(panoramaGroups[i].logoUri))
                {
                    thumbTag.Source = new BitmapImage(new Uri(panoramaGroups[i].logoUri));
                    txtGroup.Text = panoramaGroups[i].name;
                    break;
                }
            }

            if (panoramaGroups.Count == 0)
                txtGroup.Text = "Currently there are no groups. Check back later or create one at www.MeetUp.com";
        }

        private void DispatchEventInfo()
        {
            if (panoramaEvents.Count > 0)
            {
                if (panoramaEvents[0].name.ToString().Length > 40)
                {
                    nextEventTxt.Text = panoramaEvents[0].name.ToString().Substring(0, 40) + "...";
                }
                else
                {
                    nextEventTxt.Text = panoramaEvents[0].name.ToString();
                }
                nextEventTime.Text = panoramaEvents[0].when.ToString();
            }
            else
            {
                nextEventTxt.Text = "Currently, there are no upcoming events. /n Check back later.";
                nextEventTime.Text = "";
            }
        }

        private Venue GetVenue(XElement node)
        {
            String vName = node.Element("name") != null ? node.Element("name").Value : "";
            String vAddress = node.Element("address_1") != null ? node.Element("address_1").Value : "";
            String vState = node.Element("state") != null ? node.Element("state").Value : "";
            String vCity = node.Element("city") != null ? node.Element("city").Value : "";
            String vZip = node.Element("zip") != null ? node.Element("zip").Value : "" ;

            return new Venue()
            {
                name = vName,
                state = vState,
                address = vAddress,
                city = vCity,
                zip = vZip
            };
        }

        private string RemoveHtmlTags(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
      

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                while (NavigationService.RemoveBackEntry() != null)
                {
                    NavigationService.RemoveBackEntry();
                }
            }
        }
    }
}