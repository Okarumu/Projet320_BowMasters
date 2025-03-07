///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 24.01.2025
///*******************************************************

namespace Bowmasters
{
    /// <summary>
    /// Permet de stocker une position avec des coordonnées x et y avec des double
    /// </summary>
    public class PositionDouble
    {
        // Déclaration des attributs **************************************************

        /// <summary>
        /// position x
        /// </summary>
        private double _x;

        /// <summary>
        /// position y
        /// </summary>
        private double _y;

        // Déclaration des propriétés *******************************************

        /// <summary>
        /// Obtient et peut modifier la position x
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
        /// Obtient et peut modifier la position y
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

        // Déclaration du constructeur ****************************************

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
