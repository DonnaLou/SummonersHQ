﻿#pragma checksum "C:\Users\Donna\Documents\Visual Studio 2010\Projects\PhoneApp1\PhoneApp1\EventsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DF3ED131E6C6EFFA010808655E420B89"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Advertising.Mobile.UI;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PhoneApp1 {
    
    
    public partial class EventsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock eventNameTxt;
        
        internal System.Windows.Controls.TextBlock eventDescTxt;
        
        internal System.Windows.Controls.TextBlock eventTimeTxt;
        
        internal System.Windows.Controls.TextBlock eventAddressLabel;
        
        internal System.Windows.Controls.TextBlock eventAddressTxt;
        
        internal System.Windows.Controls.TextBlock eventUrlLabel;
        
        internal System.Windows.Controls.TextBlock eventUrlTxt;
        
        internal System.Windows.Controls.HyperlinkButton eventUrlHyperLink;
        
        internal System.Windows.Controls.TextBlock eventFindUsLabel;
        
        internal System.Windows.Controls.TextBlock eventFindUsTxt;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl adControl;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneApp1;component/EventsPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.eventNameTxt = ((System.Windows.Controls.TextBlock)(this.FindName("eventNameTxt")));
            this.eventDescTxt = ((System.Windows.Controls.TextBlock)(this.FindName("eventDescTxt")));
            this.eventTimeTxt = ((System.Windows.Controls.TextBlock)(this.FindName("eventTimeTxt")));
            this.eventAddressLabel = ((System.Windows.Controls.TextBlock)(this.FindName("eventAddressLabel")));
            this.eventAddressTxt = ((System.Windows.Controls.TextBlock)(this.FindName("eventAddressTxt")));
            this.eventUrlLabel = ((System.Windows.Controls.TextBlock)(this.FindName("eventUrlLabel")));
            this.eventUrlTxt = ((System.Windows.Controls.TextBlock)(this.FindName("eventUrlTxt")));
            this.eventUrlHyperLink = ((System.Windows.Controls.HyperlinkButton)(this.FindName("eventUrlHyperLink")));
            this.eventFindUsLabel = ((System.Windows.Controls.TextBlock)(this.FindName("eventFindUsLabel")));
            this.eventFindUsTxt = ((System.Windows.Controls.TextBlock)(this.FindName("eventFindUsTxt")));
            this.adControl = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("adControl")));
        }
    }
}

