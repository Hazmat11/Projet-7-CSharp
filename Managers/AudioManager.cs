using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using Windows.Media.Playback;

namespace Projet_7.Managers
{
    internal class AudioManager
    {
        public void PlayMusic(string filepath)
        {
            SoundPlayer music = new SoundPlayer(filepath);
            music.Play();
        }
        public void EndMusic(string filepath)
        {
            SoundPlayer music = new SoundPlayer(filepath);
            music.Stop();
        }
    }
}
