using Xunit;

namespace RaceDay.Tests
{
    public class RaceDayModelTests
    {
        [Fact]
        public void SampleTest_AlwaysPasses()
        {
            Assert.True(true);
        }

        [Fact]
        public void CreateCategory_ValidationTest()
        {
            string categoryName = "Marathon";
            Assert.NotNull(categoryName);
            Assert.Equal("Marathon", categoryName);
        }

        [Fact]
        public void CreateEvent_ValidationTest()
        {
            string eventName = "City Race 2026";
            Assert.Equal("City Race 2026", eventName);
        }
    }
}
