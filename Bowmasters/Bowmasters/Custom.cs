using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowmasters
{
    static class Custom
    {
        //liste des couleurs possibles
        static public ConsoleColor[] colors = {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Gray,
            ConsoleColor.DarkGray,
            ConsoleColor.Blue
        };

        public static ConsoleColor GetRandomColor()
        {
            return colors[new Random().Next(colors.Length)];
        }
    }
}
