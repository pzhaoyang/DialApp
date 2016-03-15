using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DialerAppSimple.Resources;

namespace DialerAppSimple
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // check dail code!!
            string dialCode = "";
            if (NavigationContext.QueryString.TryGetValue("DialString", out dialCode))
            {
                int intDialCode = int.Parse(dialCode);
                switch (intDialCode)
                {
                    case 634: // factory tool
                        launchToolByUri(true, "oem-tool-sft:");
                        break;
                    case 778: // this app
                    default:
                        break;
                }
            }
        }

        private async void launchToolByUri(bool shouldTerminate, string uriStr)
        {
            try
            {
                // await Windows.System.Launcher.LaunchUriAsync(new Uri(toolUri));
                await Windows.System.Launcher.LaunchUriAsync(new Uri(uriStr));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (shouldTerminate)
                Application.Current.Terminate();
        }
        private void btnLaunchByUri_Click(object sender, RoutedEventArgs e)
        {
            launchToolByUri(true, "oem-tool-sft:");
        }

        private void btnLaunchSettings_Click(object sender, RoutedEventArgs e)
        {
            launchToolByUri(true, "ms-settings-bluetooth:");
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}