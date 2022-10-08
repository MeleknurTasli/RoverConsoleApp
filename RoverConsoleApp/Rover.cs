using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverConsoleApp
{
    class Rover : IRover
    {
        public char getLetterOfDirection(int angle)
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

        public int getAngle(char letterOfDirection)
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
                    roverPosition.LetterOfDirection = getLetterOfDirection(roverPosition.Angle); //get the direction according to angle
                }
                else if (moveInputs[i] == 'R')
                {
                    roverPosition.Angle = roverPosition.Angle + angleChange;  //when right, it turns 90 degree to clockwise. It means degree will increase by 90.
                    if (roverPosition.Angle == 360)
                    {
                        roverPosition.Angle = 0;  //360 degree means 0 degree in coordinate axis
                    }
                    roverPosition.LetterOfDirection = getLetterOfDirection(roverPosition.Angle); //get the direction according to angle
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

        public void LimitsOfPlateau(string upperRightInput)
        {
            int parsedUpperCorner, parsedRightCorner;
            Plateau plateau = new Plateau();
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
                }
            }
        }

    }
}
