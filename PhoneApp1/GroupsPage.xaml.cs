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
using System.Windows.Media.Imaging;
using Microsoft.Advertising;
using System.Diagnostics;

namespace SummonersHQ
{
    public partial class GroupsPage : PhoneApplicationPage
    {
        private Group selectedGroup;

        public GroupsPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(groupsPage_DataBind);
        }

        private void groupsPage_DataBind(object sender, RoutedEventArgs e)
        {
            groupNameTxt.Text = selectedGroup.name;
            grouptDescTxt.Text = selectedGroup.description.Trim();
            memberCtTxt.Text = selectedGroup.memberCount.ToString();
            groupUrlTxt.Text = selectedGroup.uri.ToString();
            groupLocationTxt.Text = selectedGroup.city.ToString() + ", " + selectedGroup.country.ToString();
            groupUrlHyperLink.NavigateUri = new Uri(selectedGroup.uri, UriKind.Absolute);

            if(!String.IsNullOrEmpty(selectedGroup.logoUri))
                groupLogo.Source = new BitmapImage(new Uri(selectedGroup.logoUri));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.selectedGroup = (Application.Current as App).selectedGroup;
            base.OnNavigatedTo(e);
        }
    }
}