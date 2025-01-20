using System;
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
        static void Main(string[] args)
        {
            //Déclaration des constantes *****************************************************************************

            //Déclaration des variables ******************************************************************************

            //Changement de taille de la fenêtre de jeu
            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);

            //Bloque la taille de l'écran
            Console.BufferWidth = Config.SCREEN_WIDTH;
            Console.BufferHeight = Config.SCREEN_HEIGHT;

            Console.CursorVisible = false;

            Player player1 = new Player(life: 3, xPosition: 20, yPosition: 37) ;

            Player player2 = new Player(life: 3, xPosition: 127, yPosition: 37);

            Tower tower1 = new Tower(towerHeight: 6, towerWidth: 3, xPosition: 40, yPosition: 34);
            Tower tower2 = new Tower(towerHeight: 6, towerWidth: 3, xPosition: 107, yPosition: 34);

            Ball ball = new Ball(velocity: 28, angle: 0.785398, initialXPosition: 24, initialYPosition: 35);

            player1.Display();
            player2.Display();
            tower1.DisplayTower();
            tower2.DisplayTower();

            double time = 0;

            for(int i = 0; i < 200; i++)
            {
                ball.UpdateBallPosition(time);
                Thread.Sleep(50);
                time += 0.05;

                if(Math.Round(time % 0.01, 1) == 0)
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
