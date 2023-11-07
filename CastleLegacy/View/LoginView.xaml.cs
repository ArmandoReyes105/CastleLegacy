using System;
using System.Windows.Controls;
using System.Windows.Input;
using CastleLegacy.Helpers;

namespace CastleLegacy.View
{
    
    public partial class LoginView : Page
    {

        public LoginView()
        {
            InitializeComponent(); 
        }

        private void ShowPopup(object sender, MouseEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void HidePopup(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
        }

        public void PlayHoverSound(object sender, MouseEventArgs e)
        {
            SoundManager.PlayHoverSound();
        }

    }
}
