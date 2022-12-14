
namespace RoverConsoleApp
{
    public class RoverPosition
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
