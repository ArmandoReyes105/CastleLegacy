using CastleLegacy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CastleLegacy.View
{
    
    public partial class MenuView : Page
    {
        public MenuView()
        {
            InitializeComponent();

            PlayImageAnimation(imagen, .1, 2);
            PlayImageAnimation(imagen2, .45, 3); 

        }

        private void PlayImageAnimation(Image image, double animationValue, int time)
        {
            DoubleAnimation FadeOut = new DoubleAnimation
            {
                To = animationValue,
                Duration = TimeSpan.FromSeconds(time),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            image.BeginAnimation(Image.OpacityProperty, FadeOut); 
        }

        private void PlayHoverSound(object sender, MouseEventArgs e) 
        {
            SoundManager.PlayHoverSound();
        }

        private void QuitGame(object sender, RoutedEventArgs e)
        {
            SoundManager.PlayClickSound();

            LoginView login = new LoginView();
            Window.GetWindow(this).Close();
            login.Show();

        }

        private void OpenConfigurationView(object sender, RoutedEventArgs e)
        {
            SoundManager.PlayClickSound();

            NavigationService navegationService = NavigationService.GetNavigationService(this);
            navegationService.Navigate(new ConfigurationView());
        }

    }
}
