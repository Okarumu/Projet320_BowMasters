///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 17.01.2025
///*******************************************************

namespace Bowmasters
{
    /// <summary>
    /// Tours des joueurs composées de pièces de tour
    /// </summary>
    public class Tower
    {
        // Déclaration des attributs *********************************************

        /// <summary>
        /// position de la tour
        /// </summary>
        private readonly PositionByte _towerPosition;

        /// <summary>
        /// tableau de toutes les pièces
        /// </summary>
        private TowerPiece[,] _pieces;

        // Déclaration des propriétés ********************************************

        /// <summary>
        /// obtient la position de la tour
        /// </summary>
        public PositionByte TowerPosition               
        {
            get
            {
                return _towerPosition;
            }
        }

        /// <summary>
        /// obtient et peut modifier le tableau de toutes les pièces
        /// </summary>
        public TowerPiece[,] Pieces                     
        {
            get
            {
                return _pieces;
            }
            set
            {
                _pieces = value;
            }
        }

        // Déclaration du constructeur *******************************************
        /// <summary>
        /// Créer la tour et le tableau de pièces qu'on va utiliser
        /// </summary>
        /// <param name="towerHeight">hauteur</param>
        /// <param name="towerWidth">largeur</param>
        /// <param name="xPosition">position x</param>
        /// <param name="yPosition">position y</param>
        public Tower(byte towerHeight, byte towerWidth, byte xPosition, byte yPosition)
        {
            // initialise la position de la tour
            _towerPosition = new PositionByte(xPosition, yPosition);

            // initialise le tableau des pièces
            _pieces = new TowerPiece[towerWidth, towerHeight];

            // parcourt le tableau des pièces
            for (byte i = 0; i < towerWidth; i++)
            {
                for (int j = 0; j < towerHeight; j++)
                {
                    // crée des pièces pour chaque case dans le tableau
                    _pieces[i, j] = new TowerPiece(xPosition: (byte)(this.TowerPosition.X + i), yPosition: (byte)(this.TowerPosition.Y + j));
                }
            }
        }
        // Déclaration et implémentation des méthodes ****************************
        /// <summary>
        /// Affiche toutes les pièces de la tour
        /// </summary>
        public void Display()
        {
            // parcourt la liste de pièces
            for (int i = 0; i < _pieces.GetLength(0); i++)
            {
                for (int j = 0; j < _pieces.GetLength(1); j++)
                {
                    // les affiche
                    _pieces[i, j].DisplayPiece();
                }
            }
        }
    }
}
