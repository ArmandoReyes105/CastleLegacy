using System.Globalization;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Media;
using System.IO;
using System.Windows.Navigation;
using CastleLegacy.Helpers;

namespace CastleLegacy.View
{
    
    public partial class LoginView : Window
    {

        public LoginView()
        {
            InitializeComponent();
            ChangeLanguageLabel();
        }

        private void ShowPopup(object sender, MouseEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void HidePopup(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void ChangeLanguageLabel() 
        {
            CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
            LanguageTxt.Text = currentUICulture.Name.ToUpper(); 
        }

        private void OpenMenuView(object sender, RoutedEventArgs e) 
        {

            SoundManager.PlayClickSound();

            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void ChangeLanguage(object sender, RoutedEventArgs e)
        {

            SoundManager.PlayClickSound();

            Button selectedButton = (Button)sender;
            string buttonContent = selectedButton.Content.ToString();

            if (buttonContent == "Spanish" || buttonContent == "Español")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es"); 
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }

            LoginView login = new LoginView();
            login.Show();
            this.Close();

        }

        public void PlayHoverSound(object sender, MouseEventArgs e)
        {
            SoundManager.PlayHoverSound();
        }

        private void OpenSignupView(object sender, MouseButtonEventArgs e)
        {
            SoundManager.PlayClickSound();

            SignupView signup = new SignupView();   
            this.Close();
            signup.Show();
        }
    }
}
