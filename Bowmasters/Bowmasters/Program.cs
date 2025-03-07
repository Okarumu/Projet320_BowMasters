///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 17.01.2024
/// Description : Jeu où 2 joueurs, séparés par 2 tours s'affrontent en se lançant des balles chacun à leur tour.
///*******************************************************

using System;
using System.Runtime.CompilerServices;
[assembly:InternalsVisibleTo("BowMastersTests")]

namespace Bowmasters
{
    internal class Program
    {
        static void Main()
        {
            // Déclaration et initialisation des constantes *******************************************************************
            const byte AMOUNT_OF_LIFE_PER_PLAYER = 3;                   // nombre de points de vie par joueur
            const byte PLAYER_NUMBER_FOR_PLAYER_ONE = 1;                // nombre du joueur 1
            const byte PLAYER_NUMBER_FOR_PLAYER_TWO = 2;                // nombre du joueur 2
            const byte X_POSITION_PLAYER_1 = 20;                                                    // position x du joueur 1
            const byte X_POSITION_PLAYER_2 = Config.SCREEN_WIDTH - X_POSITION_PLAYER_1 - 3;                       // position x du joueur 2
            const byte Y_POSITION_PLAYER_1_AND_2 = Config.SCREEN_HEIGHT - 3;                  // position y des joueurs 1 et 2
            const ConsoleColor COLOR_PLAYER_1 = ConsoleColor.Green;     // couleur du joueur 1
            const ConsoleColor COLOR_PLAYER_2 = ConsoleColor.Red;       // couleur du joueur 2
            const byte TOWER_HEIGHT = 8;                                // hauteur des tours
            const byte TOWER_WIDTH = 3;                                 // largeur des tours
            const byte X_POSITION_TOWER_ONE = X_POSITION_PLAYER_1 + 13;                       // position x de la tour du joueur 1
            const byte X_POSITION_TOWER_TWO = X_POSITION_PLAYER_2 - 8 - TOWER_WIDTH;                      // position x de la tour du joueur 2
            const byte Y_POSITION_TOWER_ONE_AND_TWO = Config.SCREEN_HEIGHT - TOWER_HEIGHT;               // position y des tours du joueur 1 et 2


            // Déclaration des variables ********************************************************************

            /// <summary>
            /// Contient les différentes méthodes pour bien lancer le jeu
            /// </summary>
            BowGame game;

            /// <summary>
            /// Stocke 2 joueur
            /// </summary>
            Players players;

            /// <summary>
            /// Joueur 1
            /// </summary>
            Player player1;

            /// <summary>
            /// Joueur 2
            /// </summary>
            Player player2;

            /// <summary>
            /// Stocke 2 tours
            /// </summary>
            Towers towers;

            /// <summary>
            /// Tour 1
            /// </summary>
            Tower tower1;

            /// <summary>
            /// Tour 2
            /// </summary>
            Tower tower2;


            // Programme principal ***************************************************************************

            // Initialisation des variables utilisées dans le jeu ***********************
            // Initialisation des joueurs
            player1 = new Player(AMOUNT_OF_LIFE_PER_PLAYER, X_POSITION_PLAYER_1, Y_POSITION_PLAYER_1_AND_2, COLOR_PLAYER_1, PLAYER_NUMBER_FOR_PLAYER_ONE);    
            player2 = new Player(AMOUNT_OF_LIFE_PER_PLAYER, X_POSITION_PLAYER_2, Y_POSITION_PLAYER_1_AND_2, COLOR_PLAYER_2, PLAYER_NUMBER_FOR_PLAYER_TWO);
            players = new Players(player1, player2);

            // Iniialisation des tours
            tower1 = new Tower(TOWER_HEIGHT, TOWER_WIDTH, X_POSITION_TOWER_ONE, Y_POSITION_TOWER_ONE_AND_TWO); 
            tower2 = new Tower(TOWER_HEIGHT, TOWER_WIDTH, X_POSITION_TOWER_TWO, Y_POSITION_TOWER_ONE_AND_TWO);             
            towers = new Towers(tower1, tower2); 
            
            // Initialisation du jeu en lui-même
            game = new BowGame(players, towers);

            // Charge les options du jeu (changement de fenêtre, enlève le curseur...)
            Config.SetGameOptions();        
            
            // Commence le jeu
            game.Initialize();

            // Boucle de jeu
            game.GameLoop();

            // Fin du jeu
            game.EndGame();
        }
    }
}
