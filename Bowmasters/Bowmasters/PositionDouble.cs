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
        /// <summary>
        /// Attributs
        /// </summary>
        private double _x; //position x
        private double _y; //position y

        /// <summary>
        /// Position X
        /// </summary>
        public double X
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
        public double Y
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
        public PositionDouble(double xPosition, double yPosition)
        {
            X = xPosition;
            Y = yPosition;
        }
    }
}
