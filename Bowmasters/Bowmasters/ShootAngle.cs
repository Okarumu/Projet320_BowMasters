using System;
using System.Threading;
///ETML
///Auteur : Maël Naudet
///Date : 24.01.2025


namespace Bowmasters
{
    /// <summary>
    /// permet de faire une méthode qui peut afficher des points et donner un angle en fonction de ces points
    /// </summary>
    internal class ShootAngle
    {
        /// <summary>
        /// propreties
        /// </summary>
        private char _model = '.';           // modèle graphique du point
        private readonly Player _player;
        public PositionByte[] _position;    // positions possibles des points
        private double _angle;           // angle à retourner
        private bool _isRight;


        public ShootAngle(Player player, bool isRight)
        {
            _player = player;
            _isRight = isRight;
            if (isRight)
            {
                // création des positions des points
                _position = new PositionByte[] {
                new PositionByte(Convert.ToByte(player.Position.X + 5), Convert.ToByte(player.Position.Y - 3)),
                new PositionByte(Convert.ToByte(player.Position.X + 5), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X + 5), Convert.ToByte(player.Position.Y - 1)),
                new PositionByte(Convert.ToByte(player.Position.X + 3), Convert.ToByte(player.Position.Y - 1)),
                new PositionByte(Convert.ToByte(player.Position.X + 1), Convert.ToByte(player.Position.Y - 1))
                };
            }
            else
            {
                // création des positions des points
                _position = new PositionByte[] {
                new PositionByte(Convert.ToByte(player.Position.X + 4), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X + 2), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X), Convert.ToByte(player.Position.Y - 1)),
                new PositionByte(Convert.ToByte(player.Position.X ), Convert.ToByte(player.Position.Y))
                };
            }
        }

        /// <summary>
        /// Displays the points
        /// </summary>
        private void DisplayModel()
        {
            //si l'angle de la balle le permet
            if (Math.Round(_angle, 1) % 22.5 == 0)
            {
                // angle plus petit que 91 (pour tirer à droite)
                if (_isRight)
                {
                    //on prend la bonne position en fonction de l'angle
                    Console.SetCursorPosition(_position[(int)(Math.Round(_angle, 1) / 22.5)].X, _position[(int)(Math.Round(_angle, 1) / 22.5)].Y);
                }
                // angle plus grand que 91 (pour tirer à gauche)
                else
                {
                    //on prend la bonne position en fonction de l'angle
                    Console.SetCursorPosition(_position[(int)((Math.Round(_angle, 1) - 90) / 22.5)].X, _position[(int)((Math.Round(_angle, 1) - 90) / 22.5)].Y);
                }
                // affiche le point
                Console.Write(_model);
            }
        }

        /// <summary>
        /// efface les points de l'endroits où ils sont censé être.
        /// </summary>
        /// TODO REBIEN FAIRE FRR
        internal void EraseModel()
        {
            // si l'angle le permet
            if (Math.Round(_angle, 1) % 22.5 == 0)
            {
                // pour tirer à droite
                if (_isRight)
                {
                    // position en fonction de l'angle
                    Console.SetCursorPosition(_position[(int)((Math.Round(_angle, 1) / 22.5) - 1)].X, _position[(int)(Math.Round(_angle, 1) / 22.5)].Y);
                }
                // tirer à gauche
                else
                {
                    // position en fonction de l'angle
                    Console.SetCursorPosition(_position[(int)(((Math.Round(_angle, 1) - 90) / 22.5) - 1)].X, _position[(int)((Math.Round(_angle, 1) - 90) / 22.5)].Y);
                }
                // on écrit un ensemble vide
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Affiche des points et retourne un angle en fonction d'un input utilisateur
        /// </summary>
        /// <param name="xPosition">position x des points originaux</param>
        /// <param name="yPosition">position y des points originaux</param>
        /// <param name="isRight">il faut tirer à droite (angle entre 0 et 90)</param>
        /// <returns>retourne l'angle en double</returns>
        public double UpdateBallAngle()
        {
            Console.ForegroundColor = ConsoleColor.White;
            // en fonction de si on tire à droite ou non
            // on tire à droite
            if (_isRight)
            {

                // boucle
                while (true)
                {
                    // de 0 à 90 degré
                    for (_angle = 0; _angle < 90; _angle += 0.5)
                    {
                        // si on appuie sur la touche espace
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                // on retourne l'angle
                                return _angle;
                            }
                        }
                        // TODO : FAIRE EN SORTE QUE CA EFFACE BIEN LE BON TRUC
                        EraseModel();
                        // on affiche le modèle si l'angle le permet
                        DisplayModel();
                        Thread.Sleep(50);
                    }
                    // de 90 à 0 degré
                    for (_angle = 90; _angle > 0; _angle -= 0.5)
                    {
                        // si on appuie sur la touche espace
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                EraseModel();
                                DisplayModel();
                                // on retourne l'angle
                                return _angle;
                            }
                        }
                        EraseModel();
                        // on affiche le modèle
                        DisplayModel();
                        Thread.Sleep(50);
                    }
                }
            }
            // si on tire à gauche
            else
            {
                // boucle
                while (true)
                {
                    // de 90 à 180 degrés
                    for (_angle = 90; _angle < 180; _angle += 0.5)
                    {
                        // si on appuie sur la touche espace
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                // on retourne l'angle
                                return _angle;
                            }
                        }
                        EraseModel();
                        // on affiche le modèle
                        DisplayModel();
                    }
                    // de 180 à 90 degré
                    for (_angle = 180; _angle > 90; _angle -= 0.5)
                    {
                        // on appuie sur la touche espace
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                // on retourne l'angle
                                return _angle;
                            }
                        }
                        EraseModel() ;
                        // on affiche le modèle
                        DisplayModel();
                    }
                }
            }
        }
    }
}
