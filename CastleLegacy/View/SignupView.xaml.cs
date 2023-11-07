using CastleLegacy.Helpers;
using System.Windows.Controls;
using System.Windows.Input;

namespace CastleLegacy.View
{
    
    public partial class SignupView : Page 
    {

       

        public SignupView()
        {
            InitializeComponent();
        }

        public void PlayHoverSound(object sender, MouseEventArgs e)
        {
            SoundManager.PlayHoverSound();
        }

    }
}
