///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 03.02.2025
///*******************************************************

namespace Bowmasters
{
    /// <summary>
    /// Liste de position qui permet de gérer les collisions entre les différents objets (uniquement en rectangle)
    /// </summary>
    public class Hitbox
    {
        // Déclaration des attributs **************************************************      
        private readonly PositionByte[,] _hitBoxes;

        // Déclaration des propriétés *************************************************
        public PositionByte[,] HitBoxes
        {
            get { return _hitBoxes; }
        }

        // Déclaration du constructeur *************************************************
        /// <summary>
        /// Constructeur qui crée la liste de position en fonction du rectangle donné
        /// </summary>
        /// <param name="length">longueur de la hitbox</param>
        /// <param name="height">hauteur de la hitbox</param>
        /// <param name="xPosition">position initiale x</param>
        /// <param name="yPosition">position initiale y</param>
        public Hitbox(byte length, byte height, byte xPosition, byte yPosition)
        {
            _hitBoxes = new PositionByte[length, height];
            for (int i = 0; i < length; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    // On ajoute une position pour chaque coordonnée qui compose le rectangle de la hitbox
                    _hitBoxes[i, j] = new PositionByte((byte)(xPosition + i), (byte)(yPosition + j));
                }
            }
        }
    }
}
