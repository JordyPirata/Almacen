using Xunit;
using Almacen.Helpers;

public class Md5PasswordTests
{
    [Fact]
    public void GetMd5Hash_ReturnsCorrectHash()
    {
        // Arrange
        var input = "password123";
        var expectedHash = "482c811da5d5b4bc6d497ffa98491e38";

        // Act
        var actualHash = Md5Encryption.GetMd5Hash(input);

        // Assert
        Assert.Equal(expectedHash, actualHash);
    }

    [Fact]
    public void VerifyMd5Hash_ReturnsTrueForCorrectHash()
    {
        // Arrange
        var input = "password123";
        var hash = "482c811da5d5b4bc6d497ffa98491e38";

        // Act
        var result = Md5Encryption.VerifyMd5Hash(input, hash);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void VerifyMd5Hash_ReturnsFalseForIncorrectHash()
    {
        // Arrange
        var input = "password123";
        var hash = "incorrecthash";

        // Act
        var result = Md5Encryption.VerifyMd5Hash(input, hash);

        // Assert
        Assert.False(result);
    }
}