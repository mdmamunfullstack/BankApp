using System;
using Xunit;
using BankApp;

namespace BankApp.Tests
{
    public class ParkingLotTests
    {
        [Fact]
        public void Constructor_WithPositiveTotalSpots_SetsProperties()
        {
            // Arrange
            int totalSpots = 5;

            // Act
            var lot = new ParkingLot(totalSpots);

            // Assert
            Assert.Equal(totalSpots, lot.TotalSpots);
            Assert.Equal(0, lot.OccupiedSpots);
            Assert.Equal(totalSpots, lot.AvailableSpots);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WithNonPositiveTotalSpots_ThrowsArgumentException(int invalidTotal)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new ParkingLot(invalidTotal));
        }

        [Fact]
        public void ParkVehicle_WhenNotFull_IncrementsOccupiedAndDecrementsAvailable()
        {
            // Arrange
            var lot = new ParkingLot(2);

            // Act
            lot.ParkVehicle();

            // Assert
            Assert.Equal(1, lot.OccupiedSpots);
            Assert.Equal(1, lot.AvailableSpots);
        }

        [Fact]
        public void ParkVehicle_WhenFull_ThrowsInvalidOperationException()
        {
            // Arrange
            var lot = new ParkingLot(1);
            lot.ParkVehicle();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => lot.ParkVehicle());
        }

        [Fact]
        public void RemoveVehicle_WhenNotEmpty_DecrementsOccupiedAndIncrementsAvailable()
        {
            // Arrange
            var lot = new ParkingLot(2);
            lot.ParkVehicle();
            lot.ParkVehicle();

            // Act
            lot.RemoveVehicle();

            // Assert
            Assert.Equal(1, lot.OccupiedSpots);
            Assert.Equal(1, lot.AvailableSpots);
        }

        [Fact]
        public void RemoveVehicle_WhenEmpty_ThrowsInvalidOperationException()
        {
            // Arrange
            var lot = new ParkingLot(3);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => lot.RemoveVehicle());
        }

        [Fact]
        public void AvailableSpots_UpdatesCorrectly_AfterMultipleOperations()
        {
            // Arrange
            var lot = new ParkingLot(3);

            // Act
            lot.ParkVehicle(); // occupied 1
            lot.ParkVehicle(); // occupied 2
            lot.RemoveVehicle(); // occupied 1

            // Assert
            Assert.Equal(1, lot.OccupiedSpots);
            Assert.Equal(2, lot.AvailableSpots);
        }
    }
}
