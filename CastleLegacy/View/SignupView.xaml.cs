using CastleLegacy.Helpers;
using CastleLegacy.ServerServices;
using CastleLegacy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;

namespace CastleLegacy.View
{
    /// <summary>
    /// Lógica de interacción para SignupView.xaml
    /// </summary>
    public partial class SignupView : Window
    {

        private SignupVM signupVM;

        public SignupView()
        {
            InitializeComponent();
        }

        private void OpenLoginView(object sender, MouseButtonEventArgs e)
        {
            SoundManager.PlayClickSound();

            LoginView loginView = new LoginView();
            this.Close();
            loginView.Show();
        }

        public void PlayHoverSound(object sender, MouseEventArgs e)
        {
            SoundManager.PlayHoverSound();
        }

        private void OpenMenuView()
        {
            SoundManager.PlayClickSound();

            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            signupVM = new SignupVM();

            if (!string.IsNullOrEmpty(TextBox_Email.Text) && !string.IsNullOrEmpty(TextBox_Username.Text) &&
                !string.IsNullOrEmpty(TextBox_Password.Text) && !string.IsNullOrEmpty(TextBox_ConfirmPassword.Text))
            {
                if (TextBox_Password.Text == TextBox_ConfirmPassword.Text)
                {
                    var account = new Account { Email = TextBox_Email.Text, Username = TextBox_Username.Text, Password = TextBox_Password.Text, AccountStatus = "Online" };
                    signupVM.addAccount(account);

                    OpenMenuView();
                }
            }
        }
    }
}
