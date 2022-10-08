using RoverConsoleApp;

char getLetterOfDirection(int angle)
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

int getAngle(char letterOfDirection)
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

