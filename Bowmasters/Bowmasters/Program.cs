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
    /// <summary>
    /// Contient le code principal utile au bon fonctionnement du jeu. C'est ici qu'on initialise, qu'on lance la boucle et qu'on termine le jeu
    /// </summary>
    internal class Program
    {
        static void Main()
        {
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

            // boucle permettant de recommencer le jeu
            do
            {
                // Efface la console
                Console.Clear();

                // Initialisation des variables utilisées dans le jeu ***********************
                // Initialisation des joueurs
                player1 = new Player(Config.AMOUNT_OF_LIFE_PER_PLAYER, Config.X_POSITION_PLAYER_1, Config.Y_POSITION_PLAYER_1_AND_2, Config.COLOR_PLAYER_1, Config.PLAYER_NUMBER_FOR_PLAYER_ONE);
                player2 = new Player(Config.AMOUNT_OF_LIFE_PER_PLAYER, Config.X_POSITION_PLAYER_2, Config.Y_POSITION_PLAYER_1_AND_2, Config.COLOR_PLAYER_2, Config.PLAYER_NUMBER_FOR_PLAYER_TWO);
                players = new Players(player1, player2);

                // Iniialisation des tours
                tower1 = new Tower(Config.TOWER_HEIGHT, Config.TOWER_WIDTH, Config.X_POSITION_TOWER_ONE, Config.Y_POSITION_TOWER_ONE_AND_TWO);
                tower2 = new Tower(Config.TOWER_HEIGHT, Config.TOWER_WIDTH, Config.X_POSITION_TOWER_TWO, Config.Y_POSITION_TOWER_ONE_AND_TWO);
                towers = new Towers(tower1, tower2);

                // Initialisation du jeu en lui-même
                game = new BowGame(players, towers);

                // Charge les options du jeu (changement de fenêtre, enlève le curseur...)
                Config.SetGameOptions();

                // Commence le jeu
                game.Initialize();

                // Boucle de jeu
                game.GameLoop();

                // Fin du jeu et demande de recommencement
                game.EndGame();

            } while (game.PlayAgain); // tant que les joueurs ne veulent pas recommencer

            Console.Clear();
        }
    }
}
