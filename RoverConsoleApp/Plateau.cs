using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverConsoleApp
{
    class Plateau
    {
        public int UpperCorner { get; set; }
        public int RightCorner { get; set; }
        public readonly int LowerCorner = 0;
        public readonly int LeftCorner = 0;

    }
}
