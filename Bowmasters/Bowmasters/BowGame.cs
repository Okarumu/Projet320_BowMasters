using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;

///EMTL
///Auteur : Maël Naudet
///Date : 31.01.2025

namespace Bowmasters
{
    /// <summary>
    /// Jeu principal de BowMasters
    /// </summary>
    internal class BowGame
    {
        private List<Player> _players;
        private List<Tower> _towers;

        public BowGame(List<Player> players, List<Tower> _towers)
        {
            this._players = players;
            this._towers = _towers;
        }

        /// <summary>
        /// Initialize the game
        /// </summary>
        public void Initialize()
        {
            DisplayPlayers(_players);
            DisplayTower(_towers);
        }

        public void GameLoop()
        {
            do
            {
                // Player 1
                ShootAngle anglePlayerOne = new ShootAngle(player: _players[0], isRight: true);
                PressSpace velocityBarPlayerOne = new PressSpace(_players[0], 3, _players[0].Color);
                Ball ballPlayerOne = BallPowerAndAngle(_players[0], anglePlayerOne, velocityBarPlayerOne);
                ThrowBall(ballPlayerOne, _players[0], _players[1], _towers[0], _towers[1]);
                anglePlayerOne.EraseModel();
                velocityBarPlayerOne.EraseBar();
                DisplayPlayers(_players);

                // Player 2
                ShootAngle anglePlayerTwo = new ShootAngle(player: _players[1], isRight: false);
                PressSpace velocityBarPlayerTwo = new PressSpace(_players[1], 3, _players[1].Color);
                Ball ballPlayerTwo = BallPowerAndAngle(_players[1], anglePlayerTwo, velocityBarPlayerTwo);
                ThrowBall(ballPlayerTwo, _players[1], _players[0], _towers[1], _towers[0]);
                anglePlayerTwo.EraseModel();
                velocityBarPlayerTwo.EraseBar();

            } while (_players.Any(v => v.Life != 0));
        }

        private bool CollisionsTower(Ball ball, Tower tower)
        {
            if (ball.ActualPosition.X < (tower.TowerPosition.X + tower.HitBox.Length) && ball.ActualPosition.X >= tower.TowerPosition.X
                && ball.ActualPosition.Y < tower.TowerPosition.Y + tower.HitBox.Height && ball.ActualPosition.Y >= tower.TowerPosition.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CollisionsPlayer(Ball ball, Player ennemy)
        {
            if (ball.ActualPosition.X <= ennemy.Position.X + ennemy.Hitbox.Length && ball.ActualPosition.X > ennemy.Position.X
                && ball.ActualPosition.Y <= ennemy.Position.Y + ennemy.Hitbox.Height && ball.ActualPosition.Y > ennemy.Position.Y)
            {
                return true;
            }
            return false;
        }

        private bool CheckBallInGame(Ball ball)
        {
            if (ball.ActualPosition.X <= Console.WindowWidth && ball.ActualPosition.X > 0 &&
                ball.ActualPosition.Y <= Console.WindowHeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Ball BallPowerAndAngle(Player player, ShootAngle angle, PressSpace ballVelocity)
        {

            double ballAngle = angle.UpdateBallAngle();
            double velocity = ballVelocity.Start();
            Debug.Write(" angle : " + ballAngle + " || vitesse :  " + velocity);

            return new Ball(velocity, ballAngle, (byte)(player.Position.X + 3), player.Position.Y);

        }

        private void ThrowBall(Ball ball, Player thrower, Player ennemy, Tower myTower, Tower ennemyTower)
        {
            double time = 0;

            do
            {
                ball.UpdateBallPosition(time);
                time += 0.05;
                ball.DisplayBallInTime();
                Thread.Sleep(50);
                ball.ErasePreviousBall();

                if(CollisionsPlayer(ball, ennemy))
                {
                    DisplayPlayers(_players);
                    ennemy.Life--;
                    ennemy.DisplayInfo();
                }

                if(CollisionsTower(ball, myTower))
                {
                    DestroyPiece(myTower, ball);
                    thrower.Score -= 5;
                    thrower.DisplayInfo();
                }

                if(CollisionsTower(ball, ennemyTower))
                {
                    DestroyPiece(ennemyTower, ball);
                    thrower.Score += 5;
                    thrower.DisplayInfo();
                }

            } while (CheckBallInGame(ball) && !CollisionsPlayer(ball, ennemy) && !CollisionsTower(ball, myTower) && !CollisionsTower(ball, ennemyTower));

        }

        private void DisplayPlayers(List<Player> players)
        {
            // displays all players
            for (byte i = 0; i < players.Count; i++)
            {
                players[i].Display();
                players[i].DisplayInfo();
            }
        }

        private void DisplayTower(List<Tower> towers)
        {
            // displays all towers
            for (byte i = 0; i < towers.Count; i++)
            {
                towers[i].Display();
            }
        }

        private void DestroyPiece(Tower tower, Ball ball)
        {
            foreach (TowerPiece piece in tower.Pieces)
            {
                if (ball.ActualPosition.X == piece.Position.X && ball.ActualPosition.Y == piece.Position.Y && !piece.IsDestroyed)
                {
                    piece.DestroyPiece();
                    piece.IsDestroyed = true;
                }
            }
        }
    }
}
