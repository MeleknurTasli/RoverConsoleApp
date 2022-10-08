using RoverConsoleApp;

Rover rover = new Rover();

Console.WriteLine("Upper-Right Corners Of The Plateau: ");
string upperRightInput = Console.ReadLine();
rover.CreateLimitsOfPlateau(upperRightInput);

bool isContinued = true;
while (isContinued)
{
    Console.WriteLine("Current position: ");
    string currentPosition = Console.ReadLine();
    rover.CreateCurrentPosition(currentPosition);
    Console.WriteLine("Move Inputs:");
    string moveInputs = Console.ReadLine();
    rover.MoveWithInputs(moveInputs);
    Console.WriteLine("Do you want to exit? 1:Yes, Any Key:No");
    if (Console.ReadLine() == "1")
    {
        isContinued = false;
    }
}






