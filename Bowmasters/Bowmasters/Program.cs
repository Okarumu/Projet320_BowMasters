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
            //Déclaration des constantes *****************************************************************************
            

            //Déclaration des variables ******************************************************************************

            //Changement de taille de la fenêtre de jeu
            Config.SetWindowSize();

            Console.CursorVisible = false;

            List<Player> players = new List<Player>();

            Player player1 = new Player(life: 3, xPosition: 20, yPosition: 37, color: ConsoleColor.Green, 1);

            Player player2 = new Player(life: 3, xPosition: 127, yPosition: 37, color: ConsoleColor.Red, 2);

            players.Add(player1);
            players.Add(player2);

            List<Tower> towers = new List<Tower>();
            Tower tower1 = new Tower(towerHeight: 6, towerWidth: 3, xPosition: 40, yPosition: 34);
            Tower tower2 = new Tower(towerHeight: 6, towerWidth: 3, xPosition: 107, yPosition: 34);
            towers.Add(tower1);
            towers.Add(tower2);

            BowGame game = new BowGame(players, towers);

            game.Initialize();
            game.GameLoop();
            game.EndGame();


            

        }
    }
}
