using RoverConsoleApp;

namespace UnitTestsForRover.cs
{
    [TestClass]
    public class UnitTest1
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
    }
}