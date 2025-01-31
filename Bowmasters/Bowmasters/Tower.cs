using System;

namespace Bowmasters
{
    public class Tower
    {
        //Propriétés *************************************************************
        private byte _towerHeight;          //hauteur de la tour
        public byte TowerHeight
        {
            get
            {
                return _towerHeight;
            }
            set
            {
                _towerHeight = value;
            }
        }

        private byte _towerWidth;           //largeur de la tour
        public byte TowerWidth
        {
            get
            {
                return _towerWidth;
            }
            set
            {
                _towerWidth = value;
            }
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
            this._towerHeight = towerHeight;
            this._towerWidth = towerWidth;
            _towerPosition = new PositionByte(xPosition, yPosition);

            //déclare la liste des pièces
            _pieces = new TowerPiece[towerWidth, towerHeight];

            for (int i = 0; i < _towerWidth; i++)
            {
                for (int j = 0; j < _towerHeight; j++)
                {
                    _pieces[i, j] = new TowerPiece(xPosition: Convert.ToByte(this.TowerPosition.X + i), yPosition: Convert.ToByte(this.TowerPosition.Y + j));
                }
            }

        }

        //Méthodes ******************************************************************

        /// <summary>
        /// Affiche la tour
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < _towerWidth; i++)
            {
                for (int j = 0; j < _towerHeight; j++)
                {
                    _pieces[i, j].DisplayPiece();
                }
            }
        }
    }
}
