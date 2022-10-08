using RoverConsoleApp;

Rover rover = new Rover();
Console.WriteLine("Upper-Right Corners Of The Plateau: ");
string upperRightInput = Console.ReadLine();
rover.LimitsOfPlateau(upperRightInput);

