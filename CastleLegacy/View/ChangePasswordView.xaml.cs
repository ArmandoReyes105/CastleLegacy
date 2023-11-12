using CastleLegacy.Helpers;
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
using System.Windows.Shapes;

namespace CastleLegacy.View
{
    /// <summary>
    /// Lógica de interacción para ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView : Window
    {
        public ChangePasswordView()
        {
            InitializeComponent();
        }

        public void PlayHoverSound(object sender, MouseEventArgs e)
        {
            SoundManager.PlayHoverSound();
        }
    }
}
