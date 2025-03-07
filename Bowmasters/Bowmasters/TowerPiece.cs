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

        /// <summary>
        /// Modèle d'une pièce
        /// </summary>
        private const string _TOWERPIECEMODEL = "█";

        /// <summary>
        /// couleur de la pièce
        /// </summary>
        private const ConsoleColor _COLOR = ConsoleColor.DarkGray;

        // Déclaration des attributs *****************************************************

        /// <summary>
        /// position de la pièce
        /// </summary>
        private readonly PositionByte _position;

        /// <summary>
        /// savoir si une pièce est détruite ou non
        /// </summary>
        private bool _isDestroyed;

        // Déclaration des propriétés ****************************************************

        /// <summary>
        /// Obitnet la position de la pièce
        /// </summary>
        public PositionByte Position            
        {
            get
            {
                return _position;
            }
        }

        /// <summary>
        /// Retourne si la pièce est détruite ou non
        /// </summary>
        public bool IsDestroyed                 
        {
            get 
            { 
                return _isDestroyed; 
            }
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
            _isDestroyed = false;
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
        /// enlève la pièce et ajoute qu'elle a été détruite
        /// </summary>
        public void DestroyPiece()
        {
            //se met à la position de la pièce et l'enlève
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(" ");
            _isDestroyed = true;
        }
    }
}
