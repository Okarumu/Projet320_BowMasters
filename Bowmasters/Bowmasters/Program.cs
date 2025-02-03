﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Diagnostics;
[assembly:InternalsVisibleTo("BowMastersTests")]

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

            List<Player> players = new List<Player>();

            Player player1 = new Player(life: 3, xPosition: 20, yPosition: 37, color: ConsoleColor.Green, 1);

            Player player2 = new Player(life: 3, xPosition: 127, yPosition: 37, color: ConsoleColor.Red, 2);

            players.Add(player1);
            players.Add(player2);

            List<Tower> tones = new List<Tower>();
            Tower tower1 = new Tower(towerHeight: 6, towerWidth: 3, xPosition: 40, yPosition: 34);
            Tower tower2 = new Tower(towerHeight: 6, towerWidth: 3, xPosition: 107, yPosition: 34);
            tones.Add(tower1);
            tones.Add(tower2);

            BowGame game = new BowGame(players, tones);

            game.Initialize();
            game.GameLoop();
            
            /*PressSpace testSpace = new PressSpace(5, 0, 10);

            player1.Display();
            player2.Display();
            player1.DisplayInfo();
            player2.DisplayInfo();
            tower1.Display();
            tower2.Display();

            double time = 0;

            

            double test = ShootAngle.UpdateBallAngle(Convert.ToByte(player1.Position.X + 2), Convert.ToByte(player1.Position.Y - 3), true);
            
            float timeSpace = testSpace.Start();

            float velocity = timeSpace * 9;
            Ball ball = new Ball(velocity: velocity, angle: test, initialXPosition: 24, initialYPosition: 34);

            while (ball.ActualPosition.X > 0 && ball.ActualPosition.X < Console.WindowWidth && ball.ActualPosition.Y < Console.WindowHeight)
            {
                
                ball.UpdateBallPosition(time);
                time += 0.05;

                if((ball.ActualPosition.X > tower2.TowerPosition.X - 1 && ball.ActualPosition.X < tower2.TowerPosition.X + 3) 
                    && (ball.ActualPosition.Y > tower2.TowerPosition.Y - 1 && ball.ActualPosition.Y < tower2.TowerPosition.Y + 7))
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

            testSpace.EraseBar();

            double test2 = ShootAngle.UpdateBallAngle(Convert.ToByte(player2.Position.X - 2), Convert.ToByte(player2.Position.Y), false);

            Ball ball2 = new Ball(velocity: 28, angle: test2, initialXPosition: (Convert.ToByte(player2.Position.X - 2)), initialYPosition: Convert.ToByte(player2.Position.Y - 3));
            time = 0;

            while (ball2.ActualPosition.X > 0 && ball2.ActualPosition.X < Console.WindowWidth && ball2.ActualPosition.Y < Console.WindowHeight)
            {
                
                ball2.UpdateBallPosition(time);
                time += 0.05;

                if ((ball2.ActualPosition.X > tower1.TowerPosition.X - 1 && ball2.ActualPosition.X < tower1.TowerPosition.X + 3)
                    && (ball2.ActualPosition.Y > tower1.TowerPosition.Y - 1 && ball2.ActualPosition.Y < tower1.TowerPosition.Y + 7))
                {
                    foreach (TowerPiece piece in tower1.Pieces)
                    {
                        if (ball2.ActualPosition.X == piece.Position.X && ball2.ActualPosition.Y == piece.Position.Y)
                        {
                            piece.DestroyPiece();
                        }
                    }
                    break;
                }

                if (Math.Round(time % 0.2, 1) == 0)
                {
                    ball2.DisplayBallInTime();
                    Thread.Sleep(100);
                    ball2.ErasePreviousBall();
                }
            }
            */
            Console.ReadLine();

            

            tower1.Pieces[2, 2].DestroyPiece();
            Console.ReadLine();
        }
    }
}
