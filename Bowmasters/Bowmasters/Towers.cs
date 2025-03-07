///*******************************************************
/// EMTL
/// Auteur : Maël Naudet
/// Date : 04.03.2025
///*******************************************************

namespace Bowmasters
{
    /// <summary>
    /// Permet de stocker 2 tours ni plus ni moins
    /// </summary>
    internal struct Towers
    {
        // Déclaration des attributs *****************************************

        /// <summary>
        /// Tour numéro une
        /// </summary>
        private Tower _tower1;

        /// <summary>
        /// Tour numéro deux
        /// </summary>
        private Tower _tower2;

        // Déclaration des propriétés ****************************************

        /// <summary>
        /// Obtient la tour numéro une
        /// </summary>
        public Tower Tower1
        {
            get
            {
                return _tower1;
            }
        }

        /// <summary>
        /// Obtient la tour numéro deux
        /// </summary>
        public Tower Tower2
        {
            get
            {
                return _tower2;
            }
        }
        // Déclaration du constructeur ***************************************

        /// <summary>
        /// Constructeur qui permet de stocker 2 tours 
        /// </summary>
        /// <param name="tower1">tour numéro une</param>
        /// <param name="tower2">tour numéro deux</param>
        public Towers(Tower tower1, Tower tower2)
        {
            _tower1 = tower1;
            _tower2 = tower2;
        }
    }
}
