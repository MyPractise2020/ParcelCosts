using System;
using System.Collections.Generic;

namespace DeliveryCosts
{
    public class Order
    {
        public List<Parcel> ParcelList { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalCostWithSpeedyShipping { get; set; }
    }
}
