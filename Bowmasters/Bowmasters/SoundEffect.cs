///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 07.02.2025
///*******************************************************

using System.Collections.Generic;
using System.Media;

namespace Bowmasters
{
    /// <summary>
    /// Classe des sons qui permet de précharger et de lancer un son
    /// </summary>
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
