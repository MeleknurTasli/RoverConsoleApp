using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverConsoleApp
{
    class RoverPosition
    {
        public int Xcoordinate { get; set; }
        public int Ycoordinate { get; set; }

        private char _letterOfDirection;
        public char LetterOfDirection 
        { 
            get { return _letterOfDirection; }
            set 
            {
                if (value == 'N' || value == 'S' || value == 'W' || value == 'E')
                {
                    _letterOfDirection = value;
                }
                else _letterOfDirection = '-';
            }
        }
        public int Angle { get; set; }
    }
}
