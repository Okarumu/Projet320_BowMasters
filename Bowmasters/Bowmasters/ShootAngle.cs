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
    static class ShootAngle
    {
        /// <summary>
        /// propreties
        /// </summary>
        private static char _model = '.';           // modèle graphique du point
        public static PositionByte[] _position;    // positions possibles des points
        private static double _angle = 0;           // angle à retourner
        private static bool _isRight;

        /// <summary>
        /// Displays the points
        /// </summary>
        private static void DisplayModel()
        {
            //si l'angle de la balle le permet
            if (Math.Round(_angle, 1) % 22.5 == 0)
            {
                // angle plus petit que 91 (pour tirer à droite)
                if (_isRight)
                {
                    //on prend la bonne position en fonction de l'angle
                    Console.SetCursorPosition(_position[Convert.ToInt16(Math.Round(_angle, 1) / 22.5)].X, _position[Convert.ToInt16(Math.Round(_angle, 1) / 22.5)].Y);
                }
                // angle plus grand que 91 (pour tirer à gauche)
                else
                {
                    //on prend la bonne position en fonction de l'angle
                    Console.SetCursorPosition(_position[Convert.ToInt16((Math.Round(_angle, 1) - 90) / 22.5)].X, _position[Convert.ToInt16((Math.Round(_angle, 1) - 90) / 22.5)].Y);
                }
                // affiche le point
                Console.Write(_model);
                
                // attend un peu
                Thread.Sleep(500);
                // efface le point
                EraseModel();
            }
        }

        /// <summary>
        /// efface les points de l'endroits où ils sont censé être.
        /// </summary>
        private static void EraseModel()
        {
            // si l'angle le permet
            if (Math.Round(_angle, 1) % 22.5 == 0)
            {
                // pour tirer à droite
                if (_isRight)
                {
                    // position en fonction de l'angle
                    Console.SetCursorPosition(_position[Convert.ToInt16(Math.Round(_angle, 1) / 22.5)].X, _position[Convert.ToInt16(Math.Round(_angle, 1) / 22.5)].Y);
                }
                // tirer à gauche
                else
                {
                    // position en fonction de l'angle
                    Console.SetCursorPosition(_position[Convert.ToInt16((Math.Round(_angle, 1) - 90) / 22.5)].X, _position[Convert.ToInt16((Math.Round(_angle, 1) - 90) / 22.5)].Y);
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
        public static double UpdateBallAngle(byte xPosition, byte yPosition, bool isRight)
        {
            // en fonction de si on tire à droite ou non
            _isRight = isRight;
            // on tire à droite
            if (_isRight)
            {
                // création des positions des points
                _position = new PositionByte[] {
                new PositionByte(Convert.ToByte(xPosition + 5), Convert.ToByte(yPosition + 3)),
                new PositionByte(Convert.ToByte(xPosition + 5), Convert.ToByte(yPosition + 2)),
                new PositionByte(Convert.ToByte(xPosition + 5), Convert.ToByte(yPosition + 1)),
                new PositionByte(Convert.ToByte(xPosition + 3), Convert.ToByte(yPosition + 1)),
                new PositionByte(Convert.ToByte(xPosition + 1), Convert.ToByte(yPosition + 1))
                };
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
                        // on affiche le modèle si l'angle le permet
                        DisplayModel();
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
                                // on retourne l'angle
                                return _angle;
                            }
                        }
                        // on affiche le modèle
                        DisplayModel();
                    }
                }
            }
            // si on tire à gauche
            else if(!_isRight)
            {
                // création des positions des points
                _position = new PositionByte[] {
                new PositionByte(Convert.ToByte(xPosition + 4), Convert.ToByte(yPosition - 2)),
                new PositionByte(Convert.ToByte(xPosition + 2), Convert.ToByte(yPosition - 2)),
                new PositionByte(Convert.ToByte(xPosition), Convert.ToByte(yPosition - 2)),
                new PositionByte(Convert.ToByte(xPosition), Convert.ToByte(yPosition - 1)),
                new PositionByte(Convert.ToByte(xPosition ), Convert.ToByte(yPosition))
                };

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
                        // on affiche le modèle
                        DisplayModel();
                    }
                }
            }
            // chemin de retour supplémentaire
            return 0;
        }
    }
}
