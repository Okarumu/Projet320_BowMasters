///*******************************************************
///ETML
///Auteur : Maël Naudet
///Date : 17.01.2025
///*******************************************************

using System;

namespace Bowmasters
{
    /// <summary>
    /// Permet de faire une pièce d'une tour
    /// </summary>
    public class TowerPiece
    {
        // Déclaration et initialisation des constantes **********************************
        private const string _TOWERPIECEMODEL = "█";                    // Modèle d'une pièce
        private const ConsoleColor _COLOR = ConsoleColor.DarkGray;      // couleur de la pièce

        // Déclaration des attributs *****************************************************
        private readonly PositionByte _position;                        // position de la pièce
        private bool _isDestroyed;                                      // savoir si une pièce est détruite ou non

        // Déclaration des propriétés ****************************************************
        public PositionByte Position            // position de la pièce
        {
            get
            {
                return _position;
            }
        }
        public bool IsDestroyed                 // savoir si une pièce est détruite ou non
        {
            get { return _isDestroyed; }
            set { _isDestroyed = value; }
        }     

        // Déclaration des constructeurs *************************************************
        /// <summary>
        /// permet de faire une pièce en indiquant sa position
        /// </summary>
        /// <param name="xPosition">position x de la pièce</param>
        /// <param name="yPosition">position y de la pièce</param>
        public TowerPiece(byte xPosition, byte yPosition)
        {
            _position = new PositionByte(xPosition, yPosition);
            IsDestroyed = false;
        }

        // Déclaration et implémentation des méthodes ************************************
        /// <summary>
        /// Affiche la pièce
        /// </summary>
        public void DisplayPiece()
        {
            // met la couleur de la pièce
            Console.ForegroundColor = _COLOR;
            //se met à la position de la pièce et l'affiche
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(_TOWERPIECEMODEL);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// enlève la pièce
        /// </summary>
        public void DestroyPiece()
        {
            //se met à la position de la pièce et l'enlève
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(" ");
        }
    }
}
