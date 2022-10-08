using RoverConsoleApp;

namespace UnitTestsForRover.cs
{
    [TestClass]
    public class UnitTestsForRover
    {
        [TestMethod]
        public void TestMoveRover()
        {
            // Arrange
            string moveInputs = "LMLMLMLMM";
            RoverPosition roverPosition = new RoverPosition() { Xcoordinate = 1, Ycoordinate = 2,
                                                                LetterOfDirection='N', Angle = 0};
            Plateau platea = new Plateau() { RightCorner = 5, UpperCorner = 5};
            RoverPosition expected = new RoverPosition()
            {
                Xcoordinate = 1,
                Ycoordinate = 3,
                LetterOfDirection = 'N',
                Angle = 0
            };
            Rover rover = new Rover();

            // Act
            rover.MoveRover(roverPosition, platea, moveInputs);

            // Assert
            Assert.AreEqual(expected.Xcoordinate, roverPosition.Xcoordinate);
            Assert.AreEqual(expected.Ycoordinate, roverPosition.Ycoordinate);
            Assert.AreEqual(expected.LetterOfDirection, roverPosition.LetterOfDirection);
            Assert.AreEqual(expected.Angle, roverPosition.Angle);
        }

        [TestMethod]
        public void TestFindAngle()
        {
            // Arrange
            char letter = 'N';
            char letter2 = 'S';
            char letter3= 'W';
            char letter4 = 'E';
            Rover rover = new Rover();
            int expectedAngle = 0;
            int expectedAngle2 = 180;
            int expectedAngle3 = 270;
            int expectedAngle4 = 90;

            // Act
            int actualAngle = rover.FindAngle(letter);
            int actualAngle2 = rover.FindAngle(letter2);
            int actualAngle3 = rover.FindAngle(letter3);
            int actualAngle4 = rover.FindAngle(letter4);

            // Assert
            Assert.AreEqual(expectedAngle, actualAngle);
            Assert.AreEqual(expectedAngle2, actualAngle2);
            Assert.AreEqual(expectedAngle3, actualAngle3);
            Assert.AreEqual(expectedAngle4, actualAngle4);
        }

        [TestMethod]
        public void TestFindLetterOfDirection()
        {
            // Arrange
            Rover rover = new Rover();
            int Angle = 0;
            int Angle2 = 180;
            int Angle3 = 270;
            int Angle4 = 90;
            char expectedletter = 'N';
            char expectedletter2 = 'S';
            char expectedletter3 = 'W';
            char expectedletter4 = 'E';

            // Act
            int actualLetter = rover.FindLetterOfDirection(Angle);
            int actualLetter2 = rover.FindLetterOfDirection(Angle2);
            int actualLetter3 = rover.FindLetterOfDirection(Angle3);
            int actualLetter4 = rover.FindLetterOfDirection(Angle4);

            // Assert
            Assert.AreEqual(expectedletter, actualLetter);
            Assert.AreEqual(expectedletter2, actualLetter2);
            Assert.AreEqual(expectedletter3, actualLetter3);
            Assert.AreEqual(expectedletter4, actualLetter4);
        }

        [TestMethod]
        public void TestCreateLimitsOfPlateau()
        {
            // Arrange
            Rover rover = new Rover();
            string upperRightInput = "5 5";
            int expected_upper = 5;
            int expected_right = 5;

            // Act
            rover.CreateLimitsOfPlateau(upperRightInput);

            // Assert
            int actual_upper = rover.plateau.UpperCorner;
            int actual_right = rover.plateau.RightCorner;
            Assert.AreEqual(expected_upper, actual_upper);
            Assert.AreEqual(expected_right, actual_right);
        }

        [TestMethod]
        public void TestMoveWithInputs()
        {
            // Arrange
            Rover rover = new Rover();
            rover.roverPosition = new RoverPosition()
            {
                Xcoordinate = 1,
                Ycoordinate = 2,
                LetterOfDirection = 'N',
                Angle = 0
            };
            rover.plateau = new Plateau() { RightCorner = 5, UpperCorner = 5 };
            string expectedLastPosition = "1 3 N";
            string moveInputs = "LMLMLMLMM";

            // Act
            rover.MoveWithInputs(moveInputs);

            // Assert
            string actualLastPosition = rover.lastPosition;
            Assert.AreEqual(expectedLastPosition, actualLastPosition);
        }

        [TestMethod]
        public void TestCreateCurrentPosition()
        {
            // Arrange
            Rover rover = new Rover();
            rover.plateau = new Plateau() { RightCorner = 5, UpperCorner = 5 };
            string currentpos = "3 2 N";
            int expected_X = 3;
            int expected_Y = 2;
            char expected_dir = 'N';
            int expectedAngle = 0;

            // Act
            rover.CreateCurrentPosition(currentpos);

            // Assert
            int actual_X = rover.roverPosition.Xcoordinate;
            int actual_Y = rover.roverPosition.Ycoordinate;
            char actualDir = rover.roverPosition.LetterOfDirection;
            int actualAngle = rover.roverPosition.Angle;
            Assert.AreEqual(expected_X, actual_X);
            Assert.AreEqual(expected_Y, actual_Y);
            Assert.AreEqual(expected_dir, actualDir);
            Assert.AreEqual(expectedAngle, actualAngle);
        }
    }
}