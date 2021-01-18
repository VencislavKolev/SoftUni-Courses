﻿
namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal InitialPricePerPersonInside = 2.50m;
        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, InitialPricePerPersonInside)
        {
        }
    }
}
