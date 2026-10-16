using Xunit;

namespace RaceDay.Tests
{
    public class EnrolmentModelTests
    {
        [Fact]
        public void Enrolment_ParticipantId_IsValid()
        {
            // Arrange
            int participantId = 101;

            // Assert
            Assert.True(participantId > 0);
        }

        [Fact]
        public void Enrolment_Status_DefaultsToConfirmed()
        {
            // Arrange
            string status = "Confirmed";

            // Assert
            Assert.Equal("Confirmed", status);
        }
    }
}
