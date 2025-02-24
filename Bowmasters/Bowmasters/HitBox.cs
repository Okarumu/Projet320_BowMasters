using System.Collections.Generic;

namespace Bowmasters
{
    public class Hitbox
    {
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

        public Hitbox(byte length, byte height, byte xPosition, byte yPosition)
        {
            for (int i = 0; i < length; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    _hitBoxes.Add(new PositionByte((byte)(xPosition + i), (byte)(yPosition + j)));
                }
            }
        }
    }
}
