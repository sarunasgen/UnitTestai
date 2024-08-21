namespace MathOperations.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            //Arrange
            IMathOperationsWith2Digits operations = new MathOperationsWith2Digits();
            int a = 7;
            int b = 12;
            int result = 19;
            //Act
            int actualResult = operations.Add(a, b);
            //Assert
            Assert.Equal(result, actualResult);
        }
        [Fact]
        public void TestSubtract()
        {
            //Arrange
            IMathOperationsWith2Digits operations = new MathOperationsWith2Digits();
            int a = 7;
            int b = 12;
            int result = -5;
            //Act
            int actualResult = operations.Subtract(a, b);
            //Assert
            Assert.Equal(result, actualResult);
        }
    }
}