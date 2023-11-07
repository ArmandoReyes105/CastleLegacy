using CastleLegacy.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;


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
            NavigationManager.Instance.NavigateTo(new LoginView()); 

        }

        private void OpenConfigurationView(object sender, RoutedEventArgs e)
        {
            SoundManager.PlayClickSound();

            //NavigationService navegationService = base.NavigationService.GetNavigationService(this);
            //navegationService.Navigate(new ConfigurationView());
        }

    }
}
