///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 31.01.2025
///*******************************************************

using System;

namespace Bowmasters
{
    /// <summary>
    /// classe permettant la customisation d'objet (pour l'instant uniquement la couleur)
    /// </summary>
    static class Custom
    {
        // Déclaration et initialisation des attributs ***************************************
        static private ConsoleColor[] _colors = {            // tableau de couleurs possibles
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Gray,
            ConsoleColor.DarkGray,
            ConsoleColor.Blue
        };

        // Déclaration et implémentation des méthodes *****************************************
        /// <summary>
        /// retourne une couleur aléatoire
        /// </summary>
        /// <returns></returns>
        public static ConsoleColor GetRandomColor()
        {
            return _colors[new Random().Next(_colors.Length)];
        }
    }
}
