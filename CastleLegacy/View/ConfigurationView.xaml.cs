using System.Globalization;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CastleLegacy.View
{
    public partial class ConfigurationView : Page
    {
        public ConfigurationView()
        {
            InitializeComponent();
            ChangeLanguageLabel();
        }

        private void ReturnToMenu(object sender, RoutedEventArgs e) 
        {

            PlaySound("../../Audio/ButtonClick.wav");

            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.GoBack();

        }

        private void PlayHoverSound(object sender, MouseEventArgs e) 
        {
            PlaySound("../../Audio/ButtonHover.wav"); 
        }

        private void PlaySound(string sound) 
        {
            SoundPlayer soundPlayer = new SoundPlayer(sound);
            soundPlayer.Play();
            soundPlayer.Dispose();
        }

        private void ChangeLanguageLabel() 
        {
            CultureInfo currentUICulture = CultureInfo.CurrentUICulture;

            if (currentUICulture.Name.ToUpper() == "ES")
            {
                txtLanguage.Text = "Español";
            }
            else
            {
                txtLanguage.Text = "English";
            }
        }

    }
}
