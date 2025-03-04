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
        private readonly Hitbox _hitboxTower;           // hitbox de la tour
        private readonly PositionByte _towerPosition;   // position de la tour
        private TowerPiece[,] _pieces;                  // tableau de toutes les pièces

        // Déclaration des propriétés ********************************************
        public Hitbox HitboxTower                       // hitbox de la tour
        {
            get { return _hitboxTower; }
        }

        public PositionByte TowerPosition               // position de la tour
        {
            get
            {
                return _towerPosition;
            }
        }

        public TowerPiece[,] Pieces                     // tableau de toutes les pièces
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
            // initialise la hitbox de la tour ainsi que sa position
            _hitboxTower = new Hitbox(towerWidth, towerHeight, xPosition, yPosition);
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
            for (int i = 0; i < HitboxTower.HitBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < HitboxTower.HitBoxes.GetLength(1); j++)
                {
                    // les affiche
                    _pieces[i, j].DisplayPiece();
                }
            }
        }
    }
}
