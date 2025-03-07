///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 17.01.2025
///*******************************************************

using System;

namespace Bowmasters
{
    /// <summary>
    /// Permet de configurer la taille de la fenêtre de jeu
    /// </summary>
    static class Config
    {
        // Déclaration et initialisation des constantes ******************

        /// <summary>
        /// Hauteur de la fenêtre
        /// </summary>
        public const byte SCREEN_HEIGHT = 40;

        /// <summary>
        /// Largeur de la fenêtre
        /// </summary>
        public const byte SCREEN_WIDTH = 150;

        // Déclaration et implémentation des méthodes ********************

        /// <summary>
        /// Met la fenêtre de la bonne taille, fais en sorte de ne pas pouvoir scroll et rend le curseur invisible
        /// </summary>
        static public void SetGameOptions()
        {
            Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            Console.SetBufferSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            Console.CursorVisible = false;
        }
    }
}
