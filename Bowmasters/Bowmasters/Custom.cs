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
        //liste des couleurs possibles
        static private ConsoleColor[] colors = {
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

        /// <summary>
        /// retourne une couleur aléatoire
        /// </summary>
        /// <returns></returns>
        public static ConsoleColor GetRandomColor()
        {
            return colors[new Random().Next(colors.Length)];
        }
    }
}
