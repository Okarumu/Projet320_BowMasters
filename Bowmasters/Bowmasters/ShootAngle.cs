using System;
using System.Threading;

namespace Bowmasters
{
    static class ShootAngle
    {
        private static char _model = '.';
        private static PositionByte[] _position;
        private static double _angle = 0;

        private static void DisplayModel()
        {
            if (Math.Round(Balistic.RadToDeg(_angle), 1) % 22.5 == 0)
            {
                if (Balistic.RadToDeg(_angle) < 91)
                {
                    Console.SetCursorPosition(_position[Convert.ToInt16(Math.Round(Balistic.RadToDeg(_angle), 1) / 22.5)].X, _position[Convert.ToInt16(Math.Round(Balistic.RadToDeg(_angle), 1) / 22.5)].Y);
                }
                else
                {
                    Console.SetCursorPosition(_position[Convert.ToInt16((Math.Round(Balistic.RadToDeg(_angle), 1) - 90) / 22.5)].X, _position[Convert.ToInt16((Math.Round(Balistic.RadToDeg(_angle), 1) - 90) / 22.5)].Y);
                }

                Console.Write(_model);
                Thread.Sleep(100);
                EraseModel();
            }
        }

        private static void EraseModel()
        {
            if (Math.Round(Balistic.RadToDeg(_angle), 1) % 22.5 == 0)
            {
                if (Balistic.RadToDeg(_angle) < 91)
                {
                    Console.SetCursorPosition(_position[Convert.ToInt16(Math.Round(Balistic.RadToDeg(_angle), 1) / 22.5)].X, _position[Convert.ToInt16(Math.Round(Balistic.RadToDeg(_angle), 1) / 22.5)].Y);
                }
                else
                {
                    Console.SetCursorPosition(_position[Convert.ToInt16((Math.Round(Balistic.RadToDeg(_angle), 1) - 90) / 22.5)].X, _position[Convert.ToInt16((Math.Round(Balistic.RadToDeg(_angle), 1) - 90) / 22.5)].Y);
                }
                Console.Write(" ");
            }
        }

        public static double UpdateBallAngle(byte xPosition, byte yPosition, bool isRight)
        {
            if (isRight)
            {
                _position = new PositionByte[] {
                new PositionByte(Convert.ToByte(xPosition + 3), Convert.ToByte(yPosition + 3)),
                new PositionByte(Convert.ToByte(xPosition + 3), Convert.ToByte(yPosition + 2)),
                new PositionByte(Convert.ToByte(xPosition + 3), Convert.ToByte(yPosition + 1)),
                new PositionByte(Convert.ToByte(xPosition + 2), Convert.ToByte(yPosition + 1)),
                new PositionByte(Convert.ToByte(xPosition + 1), Convert.ToByte(yPosition + 1))
                };
                while (true)
                {

                    for (_angle = 0; _angle < Math.PI / 2; _angle += 0.001)
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                return _angle;
                            }
                        }
                        DisplayModel();
                    }
                    for (_angle = Math.PI / 2; _angle > 0; _angle -= 0.001)
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                return _angle;
                            }
                        }
                        DisplayModel();
                    }
                }
            }
            else if(!isRight)
            {
                _position = new PositionByte[] {
                new PositionByte(Convert.ToByte(xPosition + 1), Convert.ToByte(yPosition - 1)),
                new PositionByte(Convert.ToByte(xPosition), Convert.ToByte(yPosition - 1)),
                new PositionByte(Convert.ToByte(xPosition - 1), Convert.ToByte(yPosition)),
                new PositionByte(Convert.ToByte(xPosition - 2), Convert.ToByte(yPosition + 1)),
                new PositionByte(Convert.ToByte(xPosition - 2), Convert.ToByte(yPosition + 2))
                };
                while (true)
                {

                    for (_angle = Math.PI / 2; _angle < Math.PI; _angle += 0.001)
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                return _angle;
                            }
                        }
                        DisplayModel();
                    }
                    for (_angle = Math.PI; _angle > Math.PI / 2; _angle -= 0.001)
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                return _angle;
                            }
                        }
                        DisplayModel();
                    }
                }
            }
            return 0;
        }
    }
}
