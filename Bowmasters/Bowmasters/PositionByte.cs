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

        // Déclaration des attributs **************************************************

        /// <summary>
        /// position x dans la console
        /// </summary>
        private byte _x;

        /// <summary>
        /// position y dans la console
        /// </summary>
        private byte _y;

        // Déclaration des propriétés *****************************************

        /// <summary>
        /// Obtient et peut modifier la position x dans la console
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
        /// Obtient et peut modifier la position y dans la console
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

        // Déclaration du constructeur ****************************************

        /// <summary>
        /// Constructeur à utiliser permettant de choisir une position x et y avec des bytes
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
