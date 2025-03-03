///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 24.01.2025
///*******************************************************

namespace Bowmasters
{
    /// <summary>
    /// Permet de stocker une position x et y avec des bytes
    /// </summary>
    public class PositionByte
    {

        // Déclaration des attributs ******************************************
        private byte _x; //position x
        private byte _y; //position y
        
        // Déclaration des propriétés *****************************************
        public byte X           // position x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public byte Y           // position y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// Constructeur à utiliser permettant de choisir une position x et y
        /// </summary>
        /// <param name="xPosition">position x</param>
        /// <param name="yPosition">position y</param>
        public PositionByte(byte xPosition, byte yPosition)
        {
            X = xPosition;
            Y = yPosition;
        }
    }
}
