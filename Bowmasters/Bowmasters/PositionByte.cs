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
        /// <summary>
        /// Attributs
        /// </summary>
        private byte _x; //position x
        private byte _y; //position y
        
        /// <summary>
        /// Position X
        /// </summary>
        public byte X
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

        /// <summary>
        /// Position Y
        /// </summary>
        public byte Y
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
        /// Seul constructeur à utiliser permettant de choisir une position x et y
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
