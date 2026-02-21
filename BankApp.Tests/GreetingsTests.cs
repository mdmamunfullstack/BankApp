using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Tests
{
    public class GreetingsTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(8)]
        [InlineData(11)]
        public void GetGreeting_MorningHours_ReturnsGoodMorning(int hour)
        {
            var result = Greetings.GetGreeting(hour);

            Assert.Equal("Good Morning", result);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(15)]
        [InlineData(16)]
        public void GetGreeting_AfternoonHours_ReturnsGoodAfternoon(int hour)
        {
            var result = Greetings.GetGreeting(hour);

            Assert.Equal("Good Afternoon", result);
        }

        [Theory]
        [InlineData(17)]
        [InlineData(19)]
        [InlineData(20)]
        public void GetGreeting_EveningHours_ReturnsGoodEvening(int hour)
        {
            var result = Greetings.GetGreeting(hour);

            Assert.Equal("Good Evening", result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(21)]
        [InlineData(23)]
        public void GetGreeting_NightHours_ReturnsGoodNight(int hour)
        {
            var result = Greetings.GetGreeting(hour);

            Assert.Equal("Good Night", result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(24)]
        public void GetGreeting_InvalidHour_ThrowsException(int hour)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Greetings.GetGreeting(hour));
        }
    }
}
