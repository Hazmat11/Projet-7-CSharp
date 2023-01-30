using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;


namespace Projet_7.Managers
{
    internal class AudioManager 
    {
        public void PlayMusic(string filepath)
        {
            SoundPlayer soundPlayer = new SoundPlayer(filepath);
            soundPlayer.Play();
        }
    }
}
