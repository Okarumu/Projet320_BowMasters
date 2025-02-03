using System;

namespace Bowmasters
{
    public class Tower
    {
        //Propriétés *************************************************************
        private readonly HitBox _hitBox;

        public HitBox HitBox 
        { 
            get { return _hitBox; } 
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
            _hitBox = new HitBox(towerWidth, towerHeight);
            _towerPosition = new PositionByte(xPosition, yPosition);

            //déclare la liste des pièces
            _pieces = new TowerPiece[towerWidth, towerHeight];

            for (byte i = 0; i < HitBox.Length; i++)
            {
                for (int j = 0; j < HitBox.Height; j++)
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
            for (int i = 0; i < HitBox.Length; i++)
            {
                for (int j = 0; j < HitBox.Height; j++)
                {
                    _pieces[i, j].DisplayPiece();
                }
            }
        }
    }
}
