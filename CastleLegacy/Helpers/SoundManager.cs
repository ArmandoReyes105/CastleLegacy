using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CastleLegacy.Helpers
{
    public class SoundManager
    {

        public static void PlayClickSound()
        {
            SoundPlayer soundPlayer = new SoundPlayer("../../Audio/ButtonClick.wav");
            soundPlayer.Play();
            soundPlayer.Dispose();
        }

        public static void PlayHoverSound()
        {
            SoundPlayer soundPlayer = new SoundPlayer("../../Audio/ButtonHover.wav");
            soundPlayer.Play();
            soundPlayer.Dispose();
        }

    }
}
