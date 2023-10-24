using System.Globalization;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Media;
using System.IO;
using System.Windows.Navigation;

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

            PlaySound("../../Audio/ButtonClick.wav");

            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void ChangeLanguage(object sender, RoutedEventArgs e)
        {

            PlaySound("../../Audio/ButtonClick.wav"); 

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

        private void PlaySound(string sound) 
        {
            SoundPlayer soundPlayer = new SoundPlayer(sound);
            soundPlayer.Play();
            soundPlayer.Dispose();
        }

        public void PlayHoverSound(object sender, MouseEventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer("../../Audio/ButtonHover.wav");
            soundPlayer.Play();
            soundPlayer.Dispose();
        }

        private void OpenSignupView(object sender, MouseButtonEventArgs e)
        {
            PlaySound("../../Audio/ButtonClick.wav");

            SignupView signup = new SignupView();   
            this.Close();
            signup.Show();
        }
    }
}
