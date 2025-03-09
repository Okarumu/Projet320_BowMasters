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
    internal static class SoundEffect
    {
        // Déclaration et initialisation des attributs *********************************************

        /// <summary>
        /// Dictionnaire qui permet de stocker un nom ainsi qu'un SoundPlayer ensemble
        /// </summary>
        private static Dictionary<string, SoundPlayer> _soundPlayers = new Dictionary<string, SoundPlayer>();   

        // Déclaration et implémentations des méthodes *********************************************
        /// <summary>
        /// Charge un son et l'ajoute dans le dictionnaire afin de pouvoir le lancer
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filepath"></param>
        public static void PreloadSound(string key, string filepath)
        {
            // crée un soundplayer avec le filepath donné
            SoundPlayer player = new SoundPlayer(filepath);
            // charge le son
            player.Load();
            // ajoute le son dans le dictionnaire avec le nom donné
            _soundPlayers[key] = player;
        }

        /// <summary>
        /// Lance un son depuis un dictionnaire grâce au nom donné
        /// </summary>
        /// <param name="key"></param>
        public static void PlaySound(string key)
        {
            // lance le son grâce au nom donné dans le dictionnaire
            _soundPlayers[key].Play();
        }
    }
}
