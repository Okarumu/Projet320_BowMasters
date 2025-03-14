﻿///*******************************************************
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

        /// <summary>
        /// clé virtuelle de la barre espace
        /// </summary>
        private const int _VK_SPACE = 0x20;

        /// <summary>
        /// modèle graphique du point
        /// </summary>
        private const char _MODEL = '.';

        /// <summary>
        /// différence d'angle à chaque itération de la boucle
        /// </summary>
        private const double _ANGLE_DIFFERENCE = 0.5;

        /// <summary>
        /// angle à diviser (le point va être affiché en fonction de si l'angle est un multiple de ce nombre)
        /// </summary>
        private const double _ANGLE_DIVIDER = 22.5;


        // Déclaration des attributs ****************************************************************************

        /// <summary>
        /// positions possibles des points
        /// </summary>
        private readonly PositionByte[] _position;

        /// <summary>
        /// angle minimum de tir
        /// </summary>
        private readonly byte _minimum_angle;

        /// <summary>
        /// angle maximum de tir
        /// </summary>
        private readonly byte _maximum_angle;

        /// <summary>
        /// angle à retourner
        /// </summary>
        private double _angle;

        /// <summary>
        /// position actuelle du point
        /// </summary>
        private byte _rightPosition;

        /// <summary>
        /// position précédente du point
        /// </summary>
        private byte _previousPosition;

        /// <summary>
        /// savoir dans quelle direction va les points (de haut en bas ou de bas en haut)
        /// </summary>
        private bool _goingUp;


        // Déclaration des propriété ****************************************************************************

        /// <summary>
        /// positions possible des points
        /// </summary>
        public PositionByte[] Position                  
        {
            get
            {
                return _position;
            }
        }


        // Déclaration du constructeur **************************************************************************

        /// <summary>
        /// Constructeur qui initialise certaines variables et qui construit les différents points possibles
        /// </summary>
        /// <param name="player"></param>
        /// <param name="isRight"></param>
        public ShootAngle(Player player, bool isRight)
        {
            _goingUp = true;
            _rightPosition = 0;
            _previousPosition = 0;

            // tirer à droite
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
                // on met les angles pour tirer à droite
                _minimum_angle = 0;
                _maximum_angle = 90;
            }
            // tirer à gauche
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
                // on met les angles pour tirer à gauche
                _minimum_angle = 90;
                _maximum_angle = 180;
            }
        }


        // Déclaration et implémentation des méthodes ***********************************************************

        /// <summary>
        /// Récupère l'état actuel d'une touche spécifiée du clavier
        /// Utilise l'API Windows via P/Invoke.
        /// </summary>
        /// <param name="vKey">Code virtuel de la touche (VK_*) à vérifier.</param>
        /// <returns>
        /// Un entier court contenant l'état de la touche :
        /// - Le bit de poids faible indique si la touche est actuellement enfoncée.
        /// - Le bit de poids fort indique si la touche a été pressée depuis le dernier appel.
        /// </returns>
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        /// <summary>
        /// Displays the points
        /// </summary>
        private void DisplayModel()
        {
            // se positionner au bon endroit en fonction de la position actuelle
            Console.SetCursorPosition(_position[_rightPosition].X, _position[_rightPosition].Y);
            // on donne la position précédente
            _previousPosition = _rightPosition;
            // on monte
            if (_goingUp)
            {
                // on augmente la position
                _rightPosition++;
            }
            // on descend
            else
            {
                // on diminue la position
                _rightPosition--;
            }
            // affiche le point
            Console.Write(_MODEL);
        }

        /// <summary>
        /// efface les points de l'endroits où ils sont censé être.
        /// </summary>
        internal void EraseModel()
        {
            // on se met sur la position précédente
            Console.SetCursorPosition(_position[_previousPosition].X, _position[_previousPosition].Y);
            // on écrit du vide
            Console.Write(" ");

        }

        /// <summary>
        /// Affiche des points et retourne un angle en fonction d'un input utilisateur
        /// </summary>
        /// <returns>retourne l'angle en double</returns>
        public double UpdateBallAngle()
        {
            // on se met en blanc
            Console.ForegroundColor = ConsoleColor.White;

            // boucle jusqu'à ce que l'utilisateur appuie sur espace
            while (true)
            {
                // comme on commence, ça veut dire que les points montent
                _goingUp = true;
                // de l'angle min à l'angle max
                for (_angle = _minimum_angle; _angle < _maximum_angle; _angle += _ANGLE_DIFFERENCE)
                {
                    // si l'utilisateur appuie sur espace
                    if ((GetAsyncKeyState(_VK_SPACE) & 0x8000) != 0)
                    {
                        // retourne l'angle
                        return _angle;
                    }
                    // si l'angle est dans les 5 angles possibles (0, 22.5, 45, 67.5 ou 90 pour tirer à droite)
                    if (_angle % _ANGLE_DIVIDER == 0)
                    {
                        // on efface le modèle
                        EraseModel();
                        // on affiche la nouvelle position
                        DisplayModel();
                    }
                    // petit temps d'attente
                    Thread.Sleep(10);
                }

                // on indique que les points descendent maintenant
                _goingUp = false;
                // de l'angle max à l'angle min
                for (_angle = _maximum_angle; _angle > _minimum_angle; _angle -= _ANGLE_DIFFERENCE)
                {
                    // si l'utilisatuer appuie sur espace
                    if ((GetAsyncKeyState(_VK_SPACE) & 0x8000) != 0)
                    {
                        // retourne l'angle
                        return _angle;
                    }
                    // si l'angle est dans les 5 angles possibles (0, 22.5, 45, 67.5 ou 90 pour tirer à droite)
                    if (_angle % _ANGLE_DIVIDER == 0)
                    {
                        // on efface le modèle
                        EraseModel();
                        // on affiche la nouvelle position
                        DisplayModel();
                    }
                    // petit temps d'attente
                    Thread.Sleep(10);
                }
            }
        }
    }
}
