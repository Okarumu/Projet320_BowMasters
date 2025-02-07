using System.Media;

namespace Bowmasters
{
    internal class Music
    {
        static SoundPlayer musicPlayer = new SoundPlayer();
        public static void PlayMusic(string filepath)
        {
            musicPlayer.SoundLocation = filepath;
            musicPlayer.Play();
        }

        public static void StopMusic()
        {
            musicPlayer.Stop();
        }
    }
}
