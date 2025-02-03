using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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
            // displays all players
            for(byte i =  0; i < _players.Count; i++)
            {
                _players[i].Display();
                _players[i].DisplayInfo();
            }

            // displays all towers
            for(byte i = 0; i < _towers.Count; i++)
            {
                _towers[i].Display();
            }
        }

        public void GameLoop()
        {
            do
            {
                BallPowerAndAngle(_players[0], true);
                BallPowerAndAngle(_players[1], false);

            } while (_players.Any(v => v.Life != 0));
        }

        private bool CollisionsTower(Ball ball, Tower tower)
        {
            if(ball.ActualPosition.X < (tower.TowerPosition.X + tower.HitBox.Length) && ball.ActualPosition.X >= tower.TowerPosition.X
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

        private Ball BallPowerAndAngle(Player player, bool throwRight)
        {
            ShootAngle angle = new ShootAngle(player, throwRight);

            if (throwRight)
            {                
                double ballAngle = angle.UpdateBallAngle();
                double velocity = new PressSpace(player, 2, player.Color).Start();

                return new Ball(velocity, ballAngle, (byte)(player.Position.X + 3), player.Position.Y);
            }
            else
            {
                double ballAngle = angle.UpdateBallAngle();
                double velocity = new PressSpace(player, 2, player.Color).Start();

                return new Ball(velocity, ballAngle, (byte)(player.Position.X + 3), player.Position.Y);
            }
        }

        private void ThrowBall(Ball ball, Player ennemy, Tower myTower, Tower ennemyTower)
        {
            double time = 0;

            while (true)
                ball.UpdateBallPosition(time);
        }
    }
}
