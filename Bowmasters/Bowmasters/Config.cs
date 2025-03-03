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
        // Déclaration des attributs *************************************
        private const int SCREEN_HEIGHT = 40;   // hauteur de la fenêtre
        private const int SCREEN_WIDTH = 150;   // largeur de la fenêtre


        //////////////////////////// Déclaration et implémentation des méthodes ////////////////////////////

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
