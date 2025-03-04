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
        private Player _player1;
        private Player _player2;

        // Déclaration des propriétés ****************************************
        public Player Player1 
        { 
            get 
            { 
                return _player1; 
            } 
        }

        public Player Player2
        {
            get
            {
                return _player2;
            }
        }
        // Déclaration du constructeur ***************************************
        public Players(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }
    }
}
