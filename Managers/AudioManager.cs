using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using Windows.Media.Playback;

namespace Projet_7.Managers
{
    internal class AudioManager 
    {
        private MediaPlayer media;
        public void PlayMusic(string filepath)
        {
            /*media = new MediaPlayer();
            media.(new Uri(filepath));
            media.Play();*/
        }
        public void SetVolume(int volume) 
        {
            media.Volume = volume/100.0f ;
        
        
        }
    }
}
