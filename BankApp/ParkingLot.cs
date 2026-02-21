using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class ParkingLot
    {
        public int TotalSpots { get; private set; }
        public int OccupiedSpots { get; private set; }
        public int AvailableSpots => TotalSpots - OccupiedSpots;

        public ParkingLot(int totalSpots)
        {
            if (totalSpots <= 0)
                throw new ArgumentException("Total spots must be greater than zero.");
            TotalSpots = totalSpots;
        }

        public void ParkVehicle()
        {
            if (OccupiedSpots >= TotalSpots)
                throw new InvalidOperationException("Parking lot is full.");
            OccupiedSpots++;
        }

        public void RemoveVehicle()
        {
            if (OccupiedSpots == 0)
                throw new InvalidOperationException("Parking lot is already empty.");
            OccupiedSpots--;
        }
    }

}
