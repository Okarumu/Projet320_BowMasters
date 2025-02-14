namespace Bowmasters
{
    public class Hitbox
    {
        private byte _length;
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
        }

        public Hitbox(byte length, byte height)
        {
            Length = length;
            Height = height;
        }
    }
}
