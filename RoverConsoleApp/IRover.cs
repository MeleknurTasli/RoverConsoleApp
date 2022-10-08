using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverConsoleApp
{
    interface IRover
    {
        char FindLetterOfDirection(int angle);
        int FindAngle(char letterOfDirection);
        void MoveRover(string moveInputs, RoverPosition roverPosition, Plateau plateau);
        void CreateLimitsOfPlateau(string upperRightInput);
        void CreateCurrentPosition(string currentPosition);
        void MoveWithInputs(string moveInputs);
        void MoveWithCurrentPositionAndMoveInputs();
    }
}
