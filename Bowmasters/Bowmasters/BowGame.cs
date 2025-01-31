using System;
using System.Collections.Generic;
using System.Linq;
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
                


            } while (_players.Any(v => v.Life != 0));
        }

        private bool checkCollisionsBallTower(Ball ball, Tower tower)
        {
            if(ball.ActualPosition.X <= (tower.TowerPosition.X + 3) && ball.ActualPosition.X >= tower.TowerPosition.X
                && ball.ActualPosition.Y <= tower.TowerPosition.Y + 10 && ball.ActualPosition.Y >= tower.TowerPosition.X) 
            {
                return true;
            }
            else
            {
                return false;
            }           
        }
    }
}
