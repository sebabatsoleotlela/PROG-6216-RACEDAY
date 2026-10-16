using Xunit;

namespace RaceDay.Tests
{
    public class EventModelTests
    {
        [Fact]
        public void Event_Initialization_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            string eventName = "Soweto Marathon";
            string location = "Johannesburg";

            // Assert
            Assert.Equal("Soweto Marathon", eventName);
            Assert.Equal("Johannesburg", location);
        }

        [Fact]
        public void Event_Date_IsFutureDate()
        {
            // Arrange
            System.DateTime eventDate = System.DateTime.Now.AddDays(30);

            // Assert
            Assert.True(eventDate > System.DateTime.Now);
        }
    }
}
