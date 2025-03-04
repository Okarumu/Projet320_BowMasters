///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 24.01.2025
///*******************************************************

namespace Bowmasters
{
    /// <summary>
    /// Permet de sotcker une position avec des coordonnées x et y avec des double
    /// </summary>
    public class PositionDouble
    {
        // Déclaration des attributs **************************************************
        private double _x; // position x
        private double _y; // position y

        // Déclaration des propriétés *******************************************
        public double X         // position x
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

        public double Y         // position y
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
        /// Constructeur à utiliser permettant de choisir une position x et y avec des doubles
        /// </summary>
        /// <param name="xPosition">position x</param>
        /// <param name="yPosition">position y</param>
        public PositionDouble(double xPosition, double yPosition)
        {
            X = xPosition;
            Y = yPosition;
        }
    }
}
