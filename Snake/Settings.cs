using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Settings
    {
        public static int width { get; set; }
        public static int height { get; set; }

        public static string direction;

        public Settings()
        {
            width = 16; height = 16;
            direction = "left";
        }
    }
}
