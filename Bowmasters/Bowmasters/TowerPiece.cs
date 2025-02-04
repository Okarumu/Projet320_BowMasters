using System;

///ETML
///Auteur : Maël Naudet
///Date : 17.01.2025

namespace Bowmasters
{
    /// <summary>
    /// Permet de faire une pièce d'une tour
    /// </summary>
    public class TowerPiece
    {
        //Propriétés ****************************************************

        private const string _TOWERPIECEMODEL = "█";  //modèle d'une pièce
        private readonly PositionByte _position;
        private bool _isDestroyed;
        private const ConsoleColor _COLOR = ConsoleColor.DarkGray;

        public bool IsDestroyed
        {
            get { return _isDestroyed; }
            set { _isDestroyed = value; }
        }

        public PositionByte Position
        {
            get 
            { 
                return _position; 
            }
        }

        //Constructeur **************************************************

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

        //Méthodes ******************************************************

        /// <summary>
        /// Affiche la pièce
        /// </summary>
        public void DisplayPiece()
        {
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
