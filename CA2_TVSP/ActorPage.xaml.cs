using CA2_TVSP.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CA2_TVSP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ActorPage : Page
    {

        public static String staticImdb;

        public ActorPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(334, 627);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(334, 627));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var actorParameters = (ActorParams)e.Parameter;

            BitmapImage profileIconSrc = new BitmapImage();
            profileIconSrc.UriSource = new Uri("ms-appx:///Images/" + actorParameters.LastName + ".jpg");
            profilePicture.Source = profileIconSrc;

            actorName.Text = actorParameters.FirstName + " " + actorParameters.LastName;
            dateOfBirth.Text = actorParameters.DoB.ToString("dd/MM/yyyy");
            role.Text = actorParameters.Role;
            biography.Text = actorParameters.Biography;

            staticImdb = actorParameters.IMDB;

        }

        private void Return2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
            
        }

        private async void IMDB_button_Click(object sender, RoutedEventArgs e)
        {
            string openIBDB = @staticImdb;
            var uri = new Uri(openIBDB);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }

}
