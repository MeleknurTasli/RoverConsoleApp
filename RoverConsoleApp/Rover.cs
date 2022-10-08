using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverConsoleApp
{
    class Rover : IRover
    {
        Plateau plateau = new Plateau();
        RoverPosition roverPosition = new RoverPosition();
        public char FindLetterOfDirection(int angle)
        // get the direction according to angle with given info
        {
            if (angle == 0)
                return 'N';
            else if (angle == 90)
                return 'E';
            else if (angle == 180)
                return 'S';
            else // (angle == 270)
                return 'W';
        }

        public int FindAngle(char letterOfDirection)
        // get the angle according to direction with given info
        {
            if (letterOfDirection == 'N')
                return 0;
            else if (letterOfDirection == 'E')
                return 90;
            else if (letterOfDirection == 'S')
                return 180;
            else //(letterOfDirection == 'W')
                return 270;
        }

        public void MoveRover(string moveInputs, RoverPosition roverPosition, Plateau plateau)
        {
            int angleChange = 90;
            int moveStep = 1;

            for (int i = 0; i < moveInputs.Length; i++) //check each char in str MoveInputs
            {
                if (moveInputs[i] == 'L')
                {
                    roverPosition.Angle = roverPosition.Angle - angleChange; //when left, it turns 90 degree to counter clockwise. It means degree will decrease by 90.
                    if (roverPosition.Angle < 0) //when angle is lower than zero, sum with 360 degree because for example -90 degree is equal to 270 degree in coordinate axis
                    {
                        roverPosition.Angle = roverPosition.Angle + 360;
                    }
                    roverPosition.LetterOfDirection = FindLetterOfDirection(roverPosition.Angle); //get the direction according to angle
                }
                else if (moveInputs[i] == 'R')
                {
                    roverPosition.Angle = roverPosition.Angle + angleChange;  //when right, it turns 90 degree to clockwise. It means degree will increase by 90.
                    if (roverPosition.Angle == 360)
                    {
                        roverPosition.Angle = 0;  //360 degree means 0 degree in coordinate axis
                    }
                    roverPosition.LetterOfDirection = FindLetterOfDirection(roverPosition.Angle); //get the direction according to angle
                }
                else if (moveInputs[i] == 'M')
                {
                    //According to directions, move 1 step in the direction axises.
                    //When in the limits of the plateau, do not go further.
                    if (roverPosition.LetterOfDirection == 'N')
                    {
                        roverPosition.Ycoordinate += moveStep;
                        if (roverPosition.Ycoordinate > plateau.UpperCorner) roverPosition.Ycoordinate = plateau.UpperCorner;
                    }
                    else if (roverPosition.LetterOfDirection == 'S')
                    {
                        roverPosition.Ycoordinate -= moveStep;
                        if (roverPosition.Ycoordinate < 0) roverPosition.Ycoordinate = 0;
                    }
                    else if (roverPosition.LetterOfDirection == 'W')
                    {
                        roverPosition.Xcoordinate -= moveStep;
                        if (roverPosition.Xcoordinate < 0) roverPosition.Xcoordinate = 0;
                    }
                    else if (roverPosition.LetterOfDirection == 'E')
                    {
                        roverPosition.Xcoordinate += moveStep;
                        if (roverPosition.Xcoordinate > plateau.RightCorner) roverPosition.Xcoordinate = plateau.RightCorner;
                    }
                }
            }
        }

        public void CreateLimitsOfPlateau(string upperRightInput)
        {
            int parsedUpperCorner, parsedRightCorner;
            bool isEnteringNumber = true;
            while (isEnteringNumber) //until user gives input in the correct format
            {
                if (upperRightInput != null)
                {
                    try //In any case
                    {
                        string[] upperRightInputSplitted = upperRightInput.Split(' ');
                        if (upperRightInputSplitted.Length == 2 && // must be only 2 inputs
                            Int32.TryParse(upperRightInputSplitted[0], out parsedUpperCorner) &&//if it is int, returns 1 and parsedUpperCorner is the int value of it
                            Int32.TryParse(upperRightInputSplitted[1], out parsedRightCorner))
                        {
                            plateau.UpperCorner = parsedUpperCorner;
                            plateau.RightCorner = parsedRightCorner;
                            isEnteringNumber = false;
                        }
                        else
                        {
                            Console.WriteLine("There should be 2 inputs and the numbers must be integer.");
                            Console.WriteLine("Upper-Right Corners Of The Plateau: ");
                            upperRightInput = Console.ReadLine();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Cannot be null.");
                    Console.WriteLine("Upper-Right Corners Of The Plateau: ");
                    upperRightInput = Console.ReadLine();
                }
            }
        }

        public void CreateCurrentPosition(string currentPosition)
        {
            bool isEnteringPos = true;
            bool ContinueEnterMoveInput;
            int parsedPositionX, parsedPositionY;

            while (isEnteringPos) //loop until user exit
            {
                if (currentPosition != null)
                {
                    try //In any case
                    {
                        string[] currentPositionSplitted = currentPosition.Split(' '); //Split string according to space
                        if (currentPositionSplitted.Length == 3 &&
                            Int32.TryParse(currentPositionSplitted[0], out parsedPositionX) && //if it is int, returns 1 and parsedPositionX is the int value of it
                            Int32.TryParse(currentPositionSplitted[1], out parsedPositionY) && //if it is int, returns 1 and parsedPositionY is the int value of it
                            parsedPositionX <= plateau.RightCorner && parsedPositionY <= plateau.UpperCorner &&  //Current position cannot be lower or higher than limits
                            parsedPositionX >= plateau.LeftCorner && parsedPositionY >= plateau.LowerCorner)
                        {
                            roverPosition.Xcoordinate = parsedPositionX;
                            roverPosition.Ycoordinate = parsedPositionY;
                            if (currentPositionSplitted[2].Length == 1)
                            {
                                roverPosition.LetterOfDirection = currentPositionSplitted[2].ToCharArray()[0];
                                if (roverPosition.LetterOfDirection != '-')
                                {
                                    roverPosition.Angle = FindAngle(roverPosition.LetterOfDirection);
                                    isEnteringPos = false;
                                }
                                else
                                {
                                    Console.WriteLine("The letter of direction must be W or E or N or S.");
                                    Console.WriteLine("Current position: ");
                                    currentPosition = Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("The letter of direction must be one letter.");
                                Console.WriteLine("Current position: ");
                                currentPosition = Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There should be 3 input and the first two numbers must be integer and in the plateau limits. Limits are:" + plateau.UpperCorner + ", " + plateau.RightCorner);
                            Console.WriteLine("Current position: ");
                            currentPosition = Console.ReadLine();
                        }
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine(E.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Cannot be null.");
                    continue;
                }
            }
        }

        public void MoveWithInputs(string moveInputs)
        {
            string moveInputsChars = "LRM";//Move inputs should only have L,R,M
            bool ContinueEnterMoveInput = true;
            while (ContinueEnterMoveInput)//until user gives input in the correct format
            {
                if (moveInputs != null && moveInputs.All(c => moveInputsChars.Contains(c))) //("LRM".Contains) Checks every char in moveInput if they are in moveInputChars
                {
                    MoveRover(moveInputs, roverPosition, plateau); //Apply the algorithm
                    Console.WriteLine(roverPosition.Xcoordinate + " " + roverPosition.Ycoordinate + " " + roverPosition.LetterOfDirection);
                    ContinueEnterMoveInput = false;
                }
                else
                {
                    Console.WriteLine("Move inputs can only be R, L, M");
                    Console.WriteLine("Move Inputs:");
                    moveInputs = Console.ReadLine();
                }
            }
        }

        public void MoveWithCurrentPositionAndMoveInputs()
        {
            RoverPosition roverPosition = new RoverPosition();
            bool isContinued = true;
            bool ContinueEnterMoveInput;
            string currentPosition;
            int parsedPositionX, parsedPositionY;
            string moveInputsChars = "LRM";//Move inputs should only have L,R,M

            while (isContinued) //loop until user exit
            {
                Console.WriteLine("Current position: ");
                currentPosition = Console.ReadLine(); //3 3 E
                if (currentPosition != null)
                {
                    try //In any case
                    {
                        string[] currentPositionSplitted = currentPosition.Split(' '); //Split string according to space
                        if (currentPositionSplitted.Length == 3 &&
                            Int32.TryParse(currentPositionSplitted[0], out parsedPositionX) && //if it is int, returns 1 and parsedPositionX is the int value of it
                            Int32.TryParse(currentPositionSplitted[1], out parsedPositionY) && //if it is int, returns 1 and parsedPositionY is the int value of it
                            parsedPositionX <= plateau.RightCorner && parsedPositionY <= plateau.UpperCorner &&  //Current position cannot be lower or higher than limits
                            parsedPositionX >= plateau.LeftCorner && parsedPositionY >= plateau.LowerCorner)
                        {
                            roverPosition.Xcoordinate = parsedPositionX;
                            roverPosition.Ycoordinate = parsedPositionY;
                            if (currentPositionSplitted[2].Length == 1)
                            {
                                roverPosition.LetterOfDirection = currentPositionSplitted[2].ToCharArray()[0];
                                if (roverPosition.LetterOfDirection != '-')
                                {
                                    roverPosition.Angle = FindAngle(roverPosition.LetterOfDirection);
                                    ContinueEnterMoveInput = true;
                                    while (ContinueEnterMoveInput)//until user gives input in the correct format
                                    {
                                        Console.WriteLine("Move Inputs:");
                                        string moveInputs = Console.ReadLine(); //MMRMMRMRRM
                                        if (moveInputs != null && moveInputs.All(c => moveInputsChars.Contains(c))) //("LRM".Contains) Checks every char in moveInput if they are in moveInputChars
                                        {
                                            MoveRover(moveInputs, roverPosition, plateau); //Apply the algorithm
                                            Console.WriteLine(roverPosition.Xcoordinate + " " + roverPosition.Ycoordinate + " " + roverPosition.LetterOfDirection);
                                            ContinueEnterMoveInput = false;
                                            Console.WriteLine("Do you want to exit? 1:Yes, Any Key:No");
                                            if (Console.ReadLine() == "1")
                                            {
                                                isContinued = false;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Move inputs can only be R, L, M");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("The letter of direction must be W or E or N or S.");
                                    continue;//until user gives input in the correct format
                                }
                            }
                            else
                            {
                                Console.WriteLine("The letter of direction must be one letter.");
                                continue;//until user gives input in the correct format
                            }
                        }
                        else
                        {
                            Console.WriteLine("There should be 3 input and the first two numbers must be integer and in the plateau limits. Limits are:" + plateau.UpperCorner + ", " + plateau.RightCorner);
                            continue;//until user gives input in the correct format
                        }
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine(E.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Cannot be null.");
                    continue;
                }
            }
        }
    }
}
