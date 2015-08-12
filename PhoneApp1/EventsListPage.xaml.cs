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

namespace SummonersHQ
{
    public partial class EventsListPage : PhoneApplicationPage
    {
        List<Events> eventsList;
        public EventsListPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(eventList_Loaded);            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.eventsList = (Application.Current as App).panoramaEvents;
            base.OnNavigatedTo(e);
        }

        void eventList_Loaded(object sender, RoutedEventArgs e)
        {
            if (eventsList != null && eventsList.Count > 0)
            {
                //noResult.Visibility = Visibility.Collapsed;
                eventsListBox.ItemsSource = eventsList;
            }
        }

        protected void eventsListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        protected void eventButtonClick(object sender, EventArgs e)
        {
            Button b = sender as Button;

            Events selectedEvent = b.DataContext as Events;
            (Application.Current as App).selectedEvent = selectedEvent;

            NavigationService.Navigate(new Uri("/EventsPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml?id=1", UriKind.Relative));
        }

    }
}