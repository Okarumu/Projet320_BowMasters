///*******************************************************
///ETML
///Auteur : Maël Naudet
///Date : 24.01.2025
///*******************************************************

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Bowmasters
{
    /// <summary>
    /// permet de faire une méthode qui peut afficher des points et donner un angle en fonction de ces points
    /// </summary>
    internal class ShootAngle
    {
        // Déclaration et initialisation des constantes *********************************************************
        private const int VK_SPACE = 0x20;
        private const char _MODEL = '.';           // modèle graphique du point
        // Déclaration et initialisation des attributs **********************************************************
        private readonly PositionByte[] _position;    // positions possibles des points
        private double _angle;           // angle à retourner
        private bool _isRight;
        private byte rightPosition = 0;
        private byte previousPosition = 0;
        private bool _goingUp;
        // Déclaration des propriété ****************************************************************************
        public PositionByte[] Position 
        { 
            get 
            { 
                return _position; 
            }
        }
        // Déclaration des constructeurs ************************************************************************
        // Déclaration et implémentation des méthodes ***********************************************************
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        
        

        
        


        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="isRight"></param>
        public ShootAngle(Player player, bool isRight)
        {
            _isRight = isRight;
            _goingUp = true;
            if (isRight)
            {
                // création des positions des points
                _position = new PositionByte[] {
                new PositionByte(Convert.ToByte(player.Position.X + 5), Convert.ToByte(player.Position.Y + 0)),
                new PositionByte(Convert.ToByte(player.Position.X + 5), Convert.ToByte(player.Position.Y - 1)),
                new PositionByte(Convert.ToByte(player.Position.X + 5), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X + 3), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X + 1), Convert.ToByte(player.Position.Y - 2))
                };
            }
            else
            {
                // création des positions des points
                _position = new PositionByte[] {
                new PositionByte(Convert.ToByte(player.Position.X + 2), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X + 0), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X - 2), Convert.ToByte(player.Position.Y - 2)),
                new PositionByte(Convert.ToByte(player.Position.X - 2), Convert.ToByte(player.Position.Y - 1)),
                new PositionByte(Convert.ToByte(player.Position.X - 2), Convert.ToByte(player.Position.Y))
                };
            }
        }

        /// <summary>
        /// Displays the points
        /// </summary>
        private void DisplayModel()
        {
            Console.SetCursorPosition(_position[rightPosition].X, _position[rightPosition].Y);
            previousPosition = rightPosition;
            if (_goingUp)
            {
                rightPosition++;
            }
            else
            {
                rightPosition--;
            }

            // affiche le point
            Console.Write(_MODEL);

        }

        /// <summary>
        /// efface les points de l'endroits où ils sont censé être.
        /// </summary>
        internal void EraseModel()
        {

            Console.SetCursorPosition(_position[previousPosition].X, _position[previousPosition].Y);
            // on écrit un ensemble vide
            Console.Write(" ");

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
                    _goingUp = true;
                    // de 0 à 90 degré
                    for (_angle = 0; _angle < 90; _angle += 0.5)
                    {

                        if ((GetAsyncKeyState(VK_SPACE) & 0x8000) != 0)
                        {
                            return _angle;
                        }
                        
                        /*// si on appuie sur la touche espace
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                // on retourne l'angle
                                return _angle;
                            }
                        }*/
                        if (_angle % 22.5 == 0)
                        {
                            EraseModel();
                            // on affiche le modèle si l'angle le permet
                            DisplayModel();
                        }
                        Thread.Sleep(10);
                    }
                    _goingUp = false;
                    // de 90 à 0 degré
                    for (_angle = 90; _angle > 0; _angle -= 0.5)
                    {
                        if ((GetAsyncKeyState(VK_SPACE) & 0x8000) != 0)
                        {
                            return _angle;
                        }
                        // si on appuie sur la touche espace
                        /*if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                // on retourne l'angle
                                return _angle;
                            }
                        }*/
                        if (_angle % 22.5 == 0)
                        {
                            // TODO : FAIRE EN SORTE QUE CA EFFACE BIEN LE BON TRUC
                            EraseModel();
                            // on affiche le modèle si l'angle le permet
                            DisplayModel();
                        }
                        Thread.Sleep(10);
                    }
                }
            }
            // si on tire à gauche
            else
            {
                // boucle
                while (true)
                {
                    _goingUp = true;
                    // de 90 à 180 degrés
                    for (_angle = 90; _angle < 180; _angle += 0.5)
                    {

                        if ((GetAsyncKeyState(VK_SPACE) & 0x8000) != 0)
                        {
                            return _angle;
                        }
                        // si on appuie sur la touche espace
                        /*if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                // on retourne l'angle
                                return _angle;
                            }
                        }*/
                        if (_angle % 22.5 == 0)
                        {
                            // TODO : FAIRE EN SORTE QUE CA EFFACE BIEN LE BON TRUC
                            EraseModel();
                            // on affiche le modèle si l'angle le permet
                            DisplayModel();
                        }
                        Thread.Sleep(10);
                    }
                    _goingUp = false;
                    // de 180 à 90 degré
                    for (_angle = 180; _angle > 90; _angle -= 0.5)
                    {

                        if ((GetAsyncKeyState(VK_SPACE) & 0x8000) != 0)
                        {
                            return _angle;
                        }
                        // si on appuie sur la touche espace
                        /*if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                // on retourne l'angle
                                return _angle;
                            }
                        }*/
                        if (_angle % 22.5 == 0)
                        {
                            EraseModel();
                            // on affiche le modèle si l'angle le permet
                            DisplayModel();
                        }
                        Thread.Sleep(10);
                    }
                }
            }
        }
    }
}
