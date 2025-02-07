using System.Collections.Generic;
using System.Media;

namespace Bowmasters
{
    internal class SoundEffect
    {
        static Dictionary<string, SoundPlayer> soundPlayers = new Dictionary<string, SoundPlayer>();

        public static void PreloadSound(string key, string filepath)
        {
            SoundPlayer player = new SoundPlayer(filepath);
            player.Load();
            soundPlayers[key] = player;
        }

        public static void PlaySound(string key)
        {
            soundPlayers[key].Play();
        }
    }
}
