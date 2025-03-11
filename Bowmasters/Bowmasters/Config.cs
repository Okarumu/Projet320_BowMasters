///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 17.01.2025
///*******************************************************

using System;

namespace Bowmasters
{
    /// <summary>
    /// Permet de configurer les paramètres du jeu
    /// Domaine d'application : La taille de la fenêtre, le nombre de point de vies des joueurs, leur positions ainsi que la taille et la position des tours
    /// </summary>
    static class Config
    {
        // Déclaration et initialisation des constantes ******************

        // Paramètres pour la fenêtre

        /// <summary>
        /// Hauteur de la fenêtre
        /// </summary>
        private const byte _SCREEN_HEIGHT = 40;

        /// <summary>
        /// Largeur de la fenêtre
        /// </summary>
        private const byte _SCREEN_WIDTH = 150;

        // Paramètres du jeu

        /// <summary>
        /// nombre de points de vie par joueur
        /// </summary>
        public const byte AMOUNT_OF_LIFE_PER_PLAYER = 1;

        /// <summary>
        /// nombre du joueur 1
        /// </summary>
        public const byte PLAYER_NUMBER_FOR_PLAYER_ONE = 1;

        /// <summary>
        /// nombre du joueur 2
        /// </summary>
        public const byte PLAYER_NUMBER_FOR_PLAYER_TWO = 2;

        /// <summary>
        /// position x du joueur 1
        /// </summary>
        public const byte X_POSITION_PLAYER_1 = 20;

        /// <summary>
        /// position x du joueur 2
        /// </summary>
        public const byte X_POSITION_PLAYER_2 = _SCREEN_WIDTH - X_POSITION_PLAYER_1 - 3;

        /// <summary>
        /// position y des joueurs 1 et 2
        /// </summary>
        public const byte Y_POSITION_PLAYER_1_AND_2 = _SCREEN_HEIGHT - 3;

        /// <summary>
        /// couleur du joueur 1
        /// </summary>
        public const ConsoleColor COLOR_PLAYER_1 = ConsoleColor.Green;

        /// <summary>
        /// couleur du joueur 2
        /// </summary>
        public const ConsoleColor COLOR_PLAYER_2 = ConsoleColor.Red;

        /// <summary>
        /// hauteur des tours
        /// </summary>
        public const byte TOWER_HEIGHT = 8;

        /// <summary>
        /// largeur des tours
        /// </summary>
        public const byte TOWER_WIDTH = 3;

        /// <summary>
        /// position x de la tour du joueur 1
        /// </summary>
        public const byte X_POSITION_TOWER_ONE = X_POSITION_PLAYER_1 + 13;

        /// <summary>
        /// position x de la tour du joueur 2
        /// </summary>
        public const byte X_POSITION_TOWER_TWO = X_POSITION_PLAYER_2 - 8 - TOWER_WIDTH;

        /// <summary>
        /// position y des tours du joueur 1 et 2
        /// </summary>
        public const byte Y_POSITION_TOWER_ONE_AND_TWO = _SCREEN_HEIGHT - TOWER_HEIGHT;               


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
