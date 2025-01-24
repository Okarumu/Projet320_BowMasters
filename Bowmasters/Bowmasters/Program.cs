﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// ETML
/// Auteur : Maël Naudet
/// Date : 17.01.2024
/// Description : Jeu où 2 joueurs, séparés par 2 tours s'affrontent en se lançant des balles chacun à leur tour.
/// *******************************************************************************************************************************

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

            Player player1 = new Player(life: 3, xPosition: 20, yPosition: 37, color: ConsoleColor.Green) ;

            Player player2 = new Player(life: 3, xPosition: 127, yPosition: 37, color: ConsoleColor.Red);

            Tower tower1 = new Tower(towerHeight: 6, towerWidth: 3, xPosition: 40, yPosition: 34);
            Tower tower2 = new Tower(towerHeight: 6, towerWidth: 3, xPosition: 107, yPosition: 34);

            Ball ball = new Ball(velocity: 28, angle: 0.785398, initialXPosition: 24, initialYPosition: 34);

            player1.Display();
            player2.Display();
            tower1.DisplayTower();
            tower2.DisplayTower();

            double time = 0;

            while(true)
            {
                ball.UpdateBallPosition(time);
                time += 0.05;

                if((ball.ActualPosition.X > tower2.TowerPosition.X - 1 && ball.ActualPosition.X < tower2.TowerPosition.X + 4) 
                    && (ball.ActualPosition.Y > tower2.TowerPosition.Y - 1 && ball.ActualPosition.Y < tower2.TowerPosition.Y + 8))
                {
                    foreach (TowerPiece piece in tower2.Pieces){
                        if (ball.ActualPosition.X == piece.Position.X && ball.ActualPosition.Y == piece.Position.Y)
                        {
                            piece.DestroyPiece();
                        }
                    }
                    break;
                }

                if(Math.Round(time % 0.2, 1) == 0)
                {
                    ball.DisplayBallInTime();
                    Thread.Sleep(100);
                    ball.ErasePreviousBall();
                }               
            }

            Console.ReadLine();

            

            tower1.Pieces[2, 2].DestroyPiece();
            Console.ReadLine();
        }
    }
}
