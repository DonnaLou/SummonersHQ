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
using System.Windows.Navigation;
using Microsoft.Advertising;
using System.Diagnostics;

namespace SummonersHQ
{
    public partial class EventsPage : PhoneApplicationPage
    {
        Events thisEvent;

        public EventsPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(eventpage_DataBind);
        }

        private void eventpage_DataBind(object sender, RoutedEventArgs e)
        {
            eventNameTxt.Text = thisEvent.name;
            eventDescTxt.Text = thisEvent.eventDescription.Trim();
            eventTimeTxt.Text = thisEvent.when;

            if (thisEvent.venue == null)
            {
                eventAddressLabel.Visibility = Visibility.Collapsed;
            }
            else
            {
                eventAddressTxt.Text = thisEvent.venue.ToString();
            }

            eventUrlTxt.Text = thisEvent.eventURL;

            if (String.IsNullOrEmpty(thisEvent.howToFindUs))
            {
                eventFindUsLabel.Visibility = Visibility.Collapsed;
            }
            else
            {
                eventFindUsTxt.Text = thisEvent.howToFindUs;
            }

            eventUrlHyperLink.NavigateUri = new Uri(thisEvent.eventURL, UriKind.Absolute);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.thisEvent = (Application.Current as App).selectedEvent;
            base.OnNavigatedTo(e);
        }
    }
}