using Xunit;
using Almacen.Helpers;

public class CustomComparerTests
{
    [Fact]
    public void Compare_ReturnsNegativeValue_WhenFirstStringIsLessThanSecondString()
    {
        // Arrange
        var comparer = new CustomComparer();
        var x = "apple1";
        var y = "banana2";

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void Compare_ReturnsPositiveValue_WhenFirstStringIsGreaterThanSecondString()
    {
        // Arrange
        var comparer = new CustomComparer();
        var x = "banana2";
        var y = "apple1";

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void Compare_ReturnsZero_WhenBothStringsAreEqual()
    {
        // Arrange
        var comparer = new CustomComparer();
        var x = "apple1";
        var y = "apple1";

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Compare_ThrowsArgumentNullException_WhenFirstStringIsNull()
    {
        // Arrange
        var comparer = new CustomComparer();
        string x = null;
        var y = "banana2";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => comparer.Compare(x, y));
    }

    [Fact]
    public void Compare_ThrowsArgumentNullException_WhenSecondStringIsNull()
    {
        // Arrange
        var comparer = new CustomComparer();
        var x = "apple1";
        string y = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => comparer.Compare(x, y));
    }

    [Fact]
    public void CompareTo_ReturnsNegativeValue_WhenCurrentStringIsLessThanOtherString()
    {
        // Arrange
        var comparer = new CustomComparer();
        var current = "apple1";
        var other = "banana2";

        // Act
        var result = comparer.CompareTo(other);

        // Assert
        Assert.True(result < 0);
    }

}