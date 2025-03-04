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
        private const int _SCREEN_HEIGHT = 40;   // hauteur de la fenêtre
        private const int _SCREEN_WIDTH = 150;   // largeur de la fenêtre


        // Déclaration et implémentation des méthodes ********************
        /// <summary>
        /// Met la fenêtre de la bonne taille, fais en sorte de ne pas pouvoir scroll et rend le curseur invisible
        /// </summary>
        static public void SetGameOptions()
        {
            Console.SetWindowSize(_SCREEN_WIDTH, _SCREEN_HEIGHT);
            Console.SetBufferSize(_SCREEN_WIDTH, _SCREEN_HEIGHT);
            Console.CursorVisible = false;
        }
    }
}
