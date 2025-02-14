using System;

namespace Bowmasters
{
    public class Tower
    {
        //Propriétés *************************************************************
        private readonly Hitbox _hitboxTower;

        public Hitbox HitboxTower 
        { 
            get { return _hitboxTower; } 
        }

        private TowerPiece[,] _pieces;      //liste de toutes les pièces
        public TowerPiece[,] Pieces
        {
            get { 
                return _pieces; 
            }
            set {
                _pieces = value; 
            }
        }

        private readonly PositionByte _towerPosition;

        public PositionByte TowerPosition
        {
            get
            {
                return _towerPosition;
            }
        }

        //Constructeur de Tower ****************************************************

        /// <summary>
        /// Créer la tour et le tableau de pièces qu'on va utiliser
        /// </summary>
        /// <param name="towerHeight">hauteur</param>
        /// <param name="towerWidth">largeur</param>
        /// <param name="xPosition">position x</param>
        /// <param name="yPosition">position y</param>
        public Tower(byte towerHeight, byte towerWidth, byte xPosition, byte yPosition)
        {
            _hitboxTower = new Hitbox(towerWidth, towerHeight);
            _towerPosition = new PositionByte(xPosition, yPosition);

            //déclare la liste des pièces
            _pieces = new TowerPiece[towerWidth, towerHeight];

            for (byte i = 0; i < HitboxTower.Length; i++)
            {
                for (int j = 0; j < HitboxTower.Height; j++)
                {
                    _pieces[i, j] = new TowerPiece(xPosition: (byte)(this.TowerPosition.X + i), yPosition: (byte)(this.TowerPosition.Y + j));
                }
            }

        }

        //Méthodes ******************************************************************

        /// <summary>
        /// Affiche la tour
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < HitboxTower.Length; i++)
            {
                for (int j = 0; j < HitboxTower.Height; j++)
                {
                    _pieces[i, j].DisplayPiece();
                }
            }
        }
    }
}
