///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 03.02.2025
///*******************************************************

using System.Collections.Generic;

namespace Bowmasters
{
    /// <summary>
    /// Liste de position qui permet de gérer les collisions entre les différents objets (uniquement en rectangle)
    /// </summary>
    public class Hitbox
    {
        // liste de positions définissant la hitbox
        private List<PositionByte> _hitBoxes = new List<PositionByte>();

        public List<PositionByte> HitBoxes
        {
            get
            {
                return _hitBoxes;
            }
        }
        /* private byte _length;
        private byte _height;

        public byte Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public byte Height
        {
            get { return _height; }
            set { _height = value; }
        } */

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="length">longueur de la hitbox</param>
        /// <param name="height">hauteur de la hitbox</param>
        /// <param name="xPosition">position initiale x</param>
        /// <param name="yPosition">position initiale y</param>
        public Hitbox(byte length, byte height, byte xPosition, byte yPosition)
        {           
            for (int i = 0; i < length; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    // On ajoute une position pour chaque coordonnée qui compose le rectangle de la hitbox
                    _hitBoxes.Add(new PositionByte((byte)(xPosition + i), (byte)(yPosition + j)));
                }
            }
        }
    }
}
