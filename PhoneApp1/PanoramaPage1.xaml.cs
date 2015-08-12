using System;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

namespace PhoneApp1
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        List<Group> panoramaGroups = new List<Group>();
        List<Events> panoramaEvents = new List<Events>();

        public PanoramaPage1()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Uri getGroupAddress = new Uri("https://api.meetup.com/2/groups.xml?key=763d215944377480693c592a17334449&sign=true&topic=league-of-legends&page=20");

            HttpWebRequest getGroupsRequest = (HttpWebRequest)WebRequest.Create(getGroupAddress);
            getGroupsRequest.BeginGetResponse(GetGroupsResponse, getGroupsRequest);

            Uri getEventAddress = new Uri("https://api.meetup.com/2/open_events.xml?key=763d215944377480693c592a17334449&sign=true&topic=league-of-legends&page=20");
            HttpWebRequest getEvents = (HttpWebRequest)WebRequest.Create(getEventAddress);
            getEvents.BeginGetResponse(GetEventsResponse, getEvents);
        }

        protected void NaviToGroups(object sender, EventArgs e)
        {
           
        }

        protected void NaviToPatches(object sender, EventArgs e)
        {
            this.Content = new PatchPage();
        }

        private void NaviToGallery(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.Content = new FanArtGalery();
        }

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
                        String description = item.Element("description").Value;

                        Group newGroup = new Group(groupName, city);
                        newGroup.description = description;

                        panoramaGroups.Add(newGroup);                         
                    }
                    
                }
                catch (WebException e)
                {
                    txtZipCode1.Text = "WebException Received" + e.Message;
                    return;
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
                        String description = item.Element("description").Value;
                        String findUs = item.Element("how_to_find_us") != null ? item.Element("how_to_find_us").Value : "";
                        String eventUrl = item.Element("event_url").Value;
                        int yesRsvp = item.Element("yes_rsvp_count") != null ? int.Parse(item.Element("yes_rsvp_count").Value) : 99999;
                        int rsvpLimit = item.Element("rsvp_limit") != null ? int.Parse(item.Element("rsvp_limit").Value) : 99999;
                        int maybeRsvp = item.Element("maybe_rsvp_count") != null ? int.Parse(item.Element("maybe_rsvp_count").Value) : 99999;
                        double time = double.Parse(item.Element("time").Value);
                        double timeOffSet = double.Parse(item.Element("utc_offset").Value);
                        double eventDuration = item.Element("duration") != null ? double.Parse(item.Element("duration").Value) : 0;

                        DateTime eventStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        eventStartTime = eventStartTime.AddMilliseconds(time + timeOffSet);

                        DateTime eventEndTime = eventStartTime.AddMilliseconds(eventDuration);

                        XElement venueNode = item.Element("venue");

                        Venue venue = new Venue();
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

                        panoramaEvents.Add(newEvent);
                    }

                }
                catch (WebException e)
                {

                    txtZipCode1.Text = "WebException Received" + e.Message;
                    return;
                }
            }
        }

        private Venue GetVenue(XElement node)
        {
            String vName = node.Element("name").Value;
            String vAddress = node.Element("address_1").Value;
            String vState = node.Element("state").Value;
            String vCity = node.Element("city").Value;
            String vZip = node.Element("zip").Value;

            return new Venue()
            {
                name = vName,
                state = vState,
                address = vAddress,
                city = vCity,
                zip = vZip
            };
        }

       
    }
}