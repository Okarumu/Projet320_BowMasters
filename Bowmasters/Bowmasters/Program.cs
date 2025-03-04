///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 17.01.2024
/// Description : Jeu où 2 joueurs, séparés par 2 tours s'affrontent en se lançant des balles chacun à leur tour.
///*******************************************************

using System;
using System.Collections.Generic;
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
            const byte X_POSITION_PLAYER_1 = 20;                        // position x du joueur 1
            const byte X_POSITION_PLAYER_2 = 127;                       // position x du joueur 2
            const byte Y_POSITION_PLAYER_1_AND_2 = 37;                  // position y des joueurs 1 et 2
            const ConsoleColor COLOR_PLAYER_1 = ConsoleColor.Green;     // couleur du joueur 1
            const ConsoleColor COLOR_PLAYER_2 = ConsoleColor.Red;       // couleur du joueur 2
            const byte TOWER_HEIGHT = 6;                                // hauteur des tours
            const byte TOWER_WITDH = 3;                                 // largeur des tours
            const byte X_POSITION_TOWER_ONE = 40;                       // position x de la tour du joueur 1
            const byte X_POSITION_TOWER_TWO = 107;                      // position x de la tour du joueur 2
            const byte Y_POSITION_TOWER_ONE_AND_TWO = 34;               // position y des tours du joueur 1 et 2


            // Déclaration et initialisation des variables ********************************************************************
            BowGame game;                                       // variable pour lancer le jeu
            List<Player> players = new List<Player>();          // liste des joueurs
            Player player1 = new Player(AMOUNT_OF_LIFE_PER_PLAYER, X_POSITION_PLAYER_1, Y_POSITION_PLAYER_1_AND_2, COLOR_PLAYER_1, PLAYER_NUMBER_FOR_PLAYER_ONE);    // joueur 1
            Player player2 = new Player(AMOUNT_OF_LIFE_PER_PLAYER, X_POSITION_PLAYER_2, Y_POSITION_PLAYER_1_AND_2, COLOR_PLAYER_2, PLAYER_NUMBER_FOR_PLAYER_TWO);    // joueur 2
            List<Tower> towers = new List<Tower>();             // liste des tours
            Tower tower1 = new Tower(TOWER_HEIGHT, TOWER_WITDH, X_POSITION_TOWER_ONE, Y_POSITION_TOWER_ONE_AND_TWO); // tour du joueur 1
            Tower tower2 = new Tower(TOWER_HEIGHT, TOWER_WITDH, X_POSITION_TOWER_TWO, Y_POSITION_TOWER_ONE_AND_TWO); // tour du joueur 2


            // Programme principal ***************************************************************************
            players.Add(item: player1);       // ajoute les joueurs dans la liste
            players.Add(item: player2);
            towers.Add(item: tower1);         // ajoute les tours dans la liste
            towers.Add(item: tower2);

            // Initialise la variable de jeu
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
