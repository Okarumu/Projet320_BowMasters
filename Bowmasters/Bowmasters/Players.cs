///*******************************************************
/// EMTL
/// Auteur : Maël Naudet
/// Date : 04.03.2025
///*******************************************************

namespace Bowmasters
{
    /// <summary>
    /// Permet de pouvoir gérer 2 joueurs ensemble ni plus ni moins
    /// </summary>
    internal struct Players
    {
        // Déclaration des attributs *****************************************

        /// <summary>
        /// Joueur 1 dans le struct
        /// </summary>
        private Player _player1;

        /// <summary>
        /// Joueur 2 dans le struct
        /// </summary>
        private Player _player2;


        // Déclaration des propriétés ****************************************

        /// <summary>
        /// Permet d'obtenir le joueur 1
        /// </summary>
        public Player Player1 
        { 
            get 
            { 
                return _player1; 
            } 
        }

        /// <summary>
        /// Permet d'obtenir le joueur 2
        /// </summary>
        public Player Player2
        {
            get
            {
                return _player2;
            }
        }


        // Déclaration du constructeur ***************************************

        /// <summary>
        /// Constructeur qui permet de stocker 2 joueurs
        /// </summary>
        /// <param name="player1">joueur 1</param>
        /// <param name="player2">joueur 2</param>
        public Players(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }
    }
}
