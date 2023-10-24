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

namespace CastleLegacy.View
{
    /// <summary>
    /// Lógica de interacción para SignupView.xaml
    /// </summary>
    public partial class SignupView : Window
    {
        public SignupView()
        {
            InitializeComponent();
        }

        private void OpenLoginView(object sender, MouseButtonEventArgs e)
        {
            //PlaySound("../../Audio/ButtonClick.wav");

            LoginView loginView = new LoginView();  
            this.Close();
            loginView.Show();
        }
    }
}
