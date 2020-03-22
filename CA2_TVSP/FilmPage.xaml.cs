using CA2_TVSP.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class FilmPage : Page
    {
        public static List<Actor> staticCast = new List<Actor>();

        public FilmPage()
        {
            ApplicationView.PreferredLaunchViewSize = new Size(334, 627);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(334, 627));
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (ShowParams)e.Parameter;

            BitmapImage imgSrc = new BitmapImage();
            imgSrc.UriSource = new Uri("ms-appx:///Images/" + parameters.ShowImage + "_wallpaper.jpg");

            showWallpaper.Source = imgSrc;

            showTitle.Text = parameters.Title;
            showSynopsis.Text = parameters.Synopsis;
            showGenre.Text = parameters.Genre;
            showReleaseDate.Text = parameters.YearOfShow.ToString();
            showChannel.Text = parameters.Channel.ChannelName;
            showScreeningTime.Text = parameters.ScreeningTime;

            foreach(Staff s in parameters.ProdList.ProductionList)
            {
                showProd.Text += s.FirstName + " " + s.LastName + " (" + s.Role + ")\n";
            }

            foreach (Actor a in parameters.CastList.CastingList)
            {
                staticCast.Add(a);

                //STACKPANNEL
                StackPanel stp2 = new StackPanel();
                stp2.Name = a.FirstName + a.LastName[0];
                stp2.Tapped += new TappedEventHandler(ActorTile_Tapped);
                stp2.Height = 110;
                stp2.Width = 90;
                stp2.Background = new SolidColorBrush(Colors.White);
                stp2.Margin = new Thickness(0, 0, 10, 0);

                //IMAGE
                Image img2 = new Image();
                BitmapImage imgSrc2 = new BitmapImage();
                imgSrc2.UriSource = new Uri("ms-appx:///Images/" + a.LastName + ".jpg");

                img2.Source = imgSrc2;

                //TEXTBLOCK
                TextBlock txt2 = new TextBlock();
                txt2.Text = a.FirstName + " " + a.LastName[0] + ".";
                txt2.Foreground = new SolidColorBrush(Colors.Black);
                txt2.FontSize = 10;
                txt2.Margin = new Thickness(5, 3.5, 0, 5);

                //APPEND COMPONENTS
                stp2.Children.Add(img2);
                stp2.Children.Add(txt2);

                mustWatchSection.Children.Add(stp2);
            }

        }


        private void ActorTile_Tapped(object sender, TappedRoutedEventArgs e)
        {

            StackPanel clickedActor = sender as StackPanel;
            DependencyObject ActorNameContainer = VisualTreeHelper.GetChild(clickedActor, 0);
            Image actorName = ActorNameContainer as Image;
            string actorNameFileName = ((BitmapImage)actorName.Source).UriSource.AbsolutePath;


            string lastNameFromFile = Path.GetFileNameWithoutExtension(actorNameFileName);

            Actor tmpActor = staticCast.Find(x => x.LastName == lastNameFromFile);

            var actorParameters = new ActorParams();
            actorParameters.FirstName = tmpActor.FirstName;
            actorParameters.LastName = tmpActor.LastName;
            actorParameters.Role = tmpActor.Role;
            actorParameters.DoB = tmpActor.DateOfBirth;
            actorParameters.IMDB = tmpActor.ImbdPage;
            actorParameters.Biography = tmpActor.Biograhy;

            Frame.Navigate(typeof(ActorPage), actorParameters);
        }

        private void Return_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }
    }
}
