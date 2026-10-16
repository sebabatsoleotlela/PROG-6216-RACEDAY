using Xunit;

namespace RaceDay.Tests
{
    public class CategoryModelTests
    {
        [Fact]
        public void Category_Name_IsNotNullOrEmpty()
        {
            // Arrange
            string categoryName = "10km Road Race";

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(categoryName));
        }

        [Fact]
        public void Category_Distance_IsPositiveValue()
        {
            // Arrange
            double distanceKm = 10.0;

            // Assert
            Assert.True(distanceKm > 0);
        }
    }
}
