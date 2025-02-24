using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private const int AMOUNT_OF_DAMAGE = 1;

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
            SoundEffect.PreloadSound("throw", "SoundEffect/Bow Shot (Minecraft Sound) - Sound Effect for editingCUT.wav");
            SoundEffect.PreloadSound("hitPlayer", "SoundEffect/Minecraft-Damage-_Oof_-Sound-Effect-_HD_Cut.wav");
            SoundEffect.PreloadSound("hitTower", "SoundEffect/getting_thrown_againsed_something_(sound_effect)_outCut.wav");
        }

        public void GameLoop()
        {

            do
            {
                // Player 1
                ShootAngle anglePlayerOne = new ShootAngle(player: _players[0], isRight: true);
                PressSpace velocityBarPlayerOne = new PressSpace(_players[0], 2, _players[0].Color);
                Ball ballPlayerOne = BallPowerAndAngle(anglePlayerOne, velocityBarPlayerOne, true);
                SoundEffect.PlaySound("throw");
                Thread.Sleep(150);
                ThrowBall(ballPlayerOne, _players[0], _players[1], _towers[0], _towers[1]);
                anglePlayerOne.EraseModel();
                velocityBarPlayerOne.EraseBar();
                DisplayPlayers(_players);

                if (_players[1].Life > 0)
                {
                    // Player 2
                    ShootAngle anglePlayerTwo = new ShootAngle(player: _players[1], isRight: false);
                    PressSpace velocityBarPlayerTwo = new PressSpace(_players[1], 2, _players[1].Color);
                    Ball ballPlayerTwo = BallPowerAndAngle(anglePlayerTwo, velocityBarPlayerTwo, false);
                    SoundEffect.PlaySound("throw");
                    Thread.Sleep(150);
                    ThrowBall(ballPlayerTwo, _players[1], _players[0], _towers[1], _towers[0]);
                    anglePlayerTwo.EraseModel();
                    velocityBarPlayerTwo.EraseBar();
                }
            } while (_players.All(v => v.Life != 0));

            Console.Clear();
            Console.WriteLine("FINITO");
        }

        public void EndGame()
        {

        }

        private bool CollisionsTower(Ball ball, Tower tower)
        {
            /*if (ball.ActualPosition.X < (tower.TowerPosition.X + tower.HitBox.Length) && ball.ActualPosition.X >= tower.TowerPosition.X
                && ball.ActualPosition.Y < tower.TowerPosition.Y + tower.HitBox.Height && ball.ActualPosition.Y >= tower.TowerPosition.Y)
            {*/
            foreach (TowerPiece piece in tower.Pieces)
            {
                if (ball.ActualPosition.X == piece.Position.X && ball.ActualPosition.Y == piece.Position.Y && !piece.IsDestroyed)
                {
                    piece.DestroyPiece();
                    piece.IsDestroyed = true;
                    return true;
                }
            }
            // }
            return false;
        }

        private bool CollisionsPlayer(Ball ball, Player ennemy)
        {
            foreach (PositionByte position in ennemy.Hitbox.HitBoxes)
            {
                if(ball.ActualPosition.X == position.X && ball.ActualPosition.Y == position.Y)
                {
                    return true;
                }
            }
            /*if (ball.ActualPosition.X <= ennemy.Position.X + ennemy.Hitbox.Length && ball.ActualPosition.X > ennemy.Position.X
                && ball.ActualPosition.Y <= ennemy.Position.Y + ennemy.Hitbox.Height && ball.ActualPosition.Y > ennemy.Position.Y)
            {
                
            }*/
            return false;
        }

        private bool CheckBallInGame(Ball ball)
        {
            if (ball.ActualPosition.X <= Console.WindowWidth && ball.ActualPosition.X > 1 &&
                ball.ActualPosition.Y <= Console.WindowHeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Ball BallPowerAndAngle(ShootAngle angle, PressSpace ballVelocity, bool throwRight)
        {

            double ballAngle = angle.UpdateBallAngle();

            double velocity = ballVelocity.Start();
            Debug.Write(" angle : " + ballAngle + " || vitesse :  " + velocity);

            if (throwRight)
            {
                //return new Ball(velocity, ballAngle, (byte)(angle.Position[(int)Math.Round(ballAngle / 22.5)].X + 1), (byte)(angle.Position[(int)Math.Round(ballAngle / 22.5)].Y));
                
                // à décommenter si on veut tester pour toucher directement le joueur 2
                return new Ball(32, 45, (byte)(angle.Position[(int)Math.Round(90 / 22.5)].X + 1), (byte)(angle.Position[(int)Math.Round(90 / 22.5)].Y));
                
            }
            else
            { 
                return new Ball(velocity, ballAngle, (byte)(angle.Position[(int)Math.Round((ballAngle - 90) / 22.5)].X - 1), (byte)(angle.Position[(int)Math.Round((ballAngle - 90) / 22.5)].Y));
            }


        }

        /// <summary>
        /// Lance la balle selon le joueur et arrête le tour en fonction de si la balle touche une tour, un joueur ou sort des limites du terrain
        /// </summary>
        /// <param name="ball">balle à lancer</param>
        /// <param name="thrower">le joueur qui lance la balle</param>
        /// <param name="ennemy">le joueur adverse</param>
        /// <param name="myTower">la tour du lancer</param>
        /// <param name="ennemyTower">la tour de l'ennemi</param>
        private void ThrowBall(Ball ball, Player thrower, Player ennemy, Tower myTower, Tower ennemyTower)
        {
            // bool de controle pour terminer le tour
            bool endTurn = false;
            // début du timer (référence à quand il a commencé)
            DateTime startTime = DateTime.Now;
            // le timer est égal à 0
            double time = 0;
            
            // boucle do...while qui affiche la balle en fonction du temps et l'arrete si elle touche un élément
            do
            {
                // on update la position de la balle en fonction du temps
                ball.UpdateBallPosition(time);
                // on augment le timer
                time = (DateTime.Now - startTime).TotalSeconds;
                // on affiche la balle
                ball.DisplayBallInTime();

                // on réaffiche les informations des personnages au cas où la balle les a effacés
                ennemy.DisplayInfo();
                thrower.DisplayInfo();

                // s'il y a une collision avec l'ennemy
                if (CollisionsPlayer(ball, ennemy))
                {
                    // on fait le son de hit
                    SoundEffect.PlaySound("hitPlayer");
                    Thread.Sleep(100);

                    // on raffiche le joueur en lui enlevant de la vie
                    ennemy.Display();
                    ennemy.TakeDamage(AMOUNT_OF_DAMAGE);
                    // on rajoute du score au lanceur
                    thrower.Score += 15;

                    // on raffiche les infos des joueurs updatés
                    ennemy.DisplayInfo();
                    thrower.DisplayInfo();

                    // on indique que le tour est fini
                    endTurn = true;
                }
                // s'il y a une collision avec sa propre tour
                else if (CollisionsTower(ball, myTower))
                {
                    // on fait le son de cassage de tour
                    SoundEffect.PlaySound("hitTower");
                    Thread.Sleep(100);
                    // on enlève du score au joueur et on le remontre
                    thrower.Score -= 5;
                    thrower.DisplayInfo();

                    // on indique que le tour est fini
                    endTurn = true;
                }
                // s'il y a une collision avec la tour ennemie
                else if (CollisionsTower(ball, ennemyTower))
                {
                    // on fait le son de cassage de tour
                    SoundEffect.PlaySound("hitTower");
                    Thread.Sleep(100);

                    // on ajoute du score au lanceur et on l'update
                    thrower.Score += 5;                   
                    thrower.DisplayInfo();

                    // on indique que le tour est fini
                    endTurn = true;
                }

                Thread.Sleep(10);

                // on efface la balle
                ball.ErasePreviousBall();

            } // tant que la balle est dans le jeu et que le tour n'est pas fini 
            while (CheckBallInGame(ball) && !endTurn);

        }

        /// <summary>
        /// Affiche tous les joueurs d'une liste
        /// </summary>
        /// <param name="players"></param>
        private void DisplayPlayers(List<Player> players)
        {
            // affiche tous les joueurs et leurs infos
            for (byte i = 0; i < players.Count; i++)
            {
                players[i].Display();
                players[i].DisplayInfo();
            }
        }

        /// <summary>
        /// Affiche toutes les tours d'une liste
        /// </summary>
        /// <param name="towers">list of tower</param>
        private void DisplayTower(List<Tower> towers)
        {
            // affiche toutes les tours
            for (byte i = 0; i < towers.Count; i++)
            {
                towers[i].Display();
            }
        }
    }
}