using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private byte _xPosition;                        //position x de la pièce
        private byte _yPosition;                        //position y de la pièce

        //Constructeur **************************************************

        /// <summary>
        /// permet de faire une pièce en indiquant sa position
        /// </summary>
        /// <param name="xPosition">position x de la pièce</param>
        /// <param name="yPosition">position y de la pièce</param>
        public TowerPiece(byte xPosition, byte yPosition)
        {
            this._xPosition = xPosition;
            this._yPosition = yPosition;
        }

        //Méthodes ******************************************************

        /// <summary>
        /// Affiche la pièce
        /// </summary>
        public void DisplayPiece()
        {
            //se met à la position de la pièce et l'affiche
            Console.SetCursorPosition(_xPosition, _yPosition);
            Console.Write(_TOWERPIECEMODEL);
        }

        /// <summary>
        /// enlève la pièce
        /// </summary>
        public void DestroyPiece()
        {
            //se met à la position de la pièce et l'enlève
            Console.SetCursorPosition(_xPosition, _yPosition);
            Console.Write(" ");
        }
    }
}
