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
    public partial class GroupListPage : PhoneApplicationPage
    {
        List<Group> groupList;
        public GroupListPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(groupList_Loaded);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.groupList = (Application.Current as App).panoramaGroups;
            base.OnNavigatedTo(e);
        }

        void groupList_Loaded(object sender, RoutedEventArgs e)
        {
            if (groupList != null && groupList.Count > 0)
            {
                groupsListBox.ItemsSource = groupList;
            }
        }

        protected void eventButtonClick(object sender, EventArgs e)
        {
            Button b = sender as Button;

            Group selectedGroup = b.DataContext as Group;
            (Application.Current as App).selectedGroup = selectedGroup;

            NavigationService.Navigate(new Uri("/GroupsPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml?id=1", UriKind.Relative));
        }

    }
}