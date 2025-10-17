using StringManipulation;
namespace StringManipulationTests

{
    public class StringOperationsTest
    {
        [Fact]
        public void ConcatenateStrings() { 
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Fonzi");

            // Assert
            Assert.Equal("Hello Fonzi", result);
        }

        [Fact]
        public void IsPalindrome_True() {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("hello");

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("hello", false)]
        [InlineData("arepera", true)]
        public void IsPalindrome_InlineData(string word, bool expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome(word);

            // Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void QuantintyInWords() {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.QuantintyInWords("manzanas", 2);

            // Assert
            Assert.StartsWith("dos", result);
            Assert.EndsWith("manzanas", result);
            Assert.Contains(" ", result);
            Assert.Equal("dos manzanas", result);
        }

        [Fact]
        public void GetStringLength_Length()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.GetStringLength("Hello");

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void GetStringLength_Exception() 
        { 
            // Arrange
            var strOperations = new StringOperations();

            // Act
            // Assert
            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("XIII", 13)]
        [InlineData("XVI", 16)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            // Arrange
            var strOperations = new StringOperations();
            
            // Act
            var result = strOperations.FromRomanToNumber(romanNumber);
            
            // Assert
            Assert.Equal(expected, result);
        }

    }
}
