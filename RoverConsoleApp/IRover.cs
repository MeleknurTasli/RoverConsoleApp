using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverConsoleApp
{
    interface IRover
    {
        char getLetterOfDirection(int angle);
        int getAngle(char letterOfDirection);
        void MoveRover(string moveInputs, RoverPosition roverPosition, Plateau plateau);
        void LimitsOfPlateau(string upperRightInput);
    }
}
