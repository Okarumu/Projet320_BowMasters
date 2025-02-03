namespace Bowmasters
{
    public class HitBox
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

        public HitBox(byte length, byte height)
        {
            Length = length;
            Height = height;
        }
    }
}
