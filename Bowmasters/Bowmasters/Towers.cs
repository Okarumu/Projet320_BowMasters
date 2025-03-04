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
        private Tower _tower1;
        private Tower _tower2;

        // Déclaration des propriétés ****************************************
        public Tower Tower1
        {
            get
            {
                return _tower1;
            }
        }

        public Tower Tower2
        {
            get
            {
                return _tower2;
            }
        }
        // Déclaration du constructeur ***************************************
        public Towers(Tower tower1, Tower tower2)
        {
            _tower1 = tower1;
            _tower2 = tower2;
        }
    }
}
