
namespace RoverConsoleApp
{
    interface IRover
    {
        char FindLetterOfDirection(int angle);
        int FindAngle(char letterOfDirection);
        void MoveRover(RoverPosition roverPosition, Plateau plateau, string moveInputs);
        void CreateLimitsOfPlateau(string upperRightInput);
        void CreateCurrentPosition(string currentPosition);
        void MoveWithInputs(string moveInputs);
    }
}
