using CastleLegacy.Helpers;
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

            SoundManager.PlayClickSound();

            //NavigationService navigationService = base.NavigationService.GetNavigationService(this);
            //navigationService.GoBack();

        }

        private void PlayHoverSound(object sender, MouseEventArgs e) 
        {
            SoundManager.PlayHoverSound();  
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
