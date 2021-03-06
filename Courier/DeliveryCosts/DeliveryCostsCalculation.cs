﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCosts
{
    public class DeliveryCostsCalculation
    {
        public const decimal smallParcelDimentionLimit = 10;
        public const decimal mediumParcelDimentionLimit = 50;
        public const decimal largeParcelDimentionLimit = 100;
        public const decimal smallParcelWeightLimit = 1;
        public const decimal mediumParcelWeightLimit = 3;
        public const decimal largeParcelWeightLimit = 6;
        public const decimal xLParcelWeightLimit = 10;
        public const decimal overChargePerKg = 2;
        public const decimal overWeightParcelCost = 50;
        public const decimal overWeightParcelWeightLimit = 50;
        public const decimal overWeightParcelExcessCharge = 1;

        /// <summary>
        /// This is the data to be presented to the end user
        /// </summary>
        /// <param name="parcels">The parcels to be delivered</param>
        /// <returns>order information as required, 
        /// i.e. individual parcel cost, parcel type and total cost of all the parcels in the order</returns>
        public Order CalculateOrderCost(List<Parcel> parcels, bool isSpeedyShipping = false)
        {
            var order = new Order();
            order.ParcelList = new List<Parcel>();
            foreach (var parcel in parcels)
            {
                var targetParcel = CalculateDeliveryCostByParcelSize(parcel);
                order.ParcelList.Add(targetParcel);
                order.TotalCost += targetParcel.Cost;
            }
            if (isSpeedyShipping)
                order.TotalCostWithSpeedyShipping = order.TotalCost * 2;
            return order;
        }

        /// <summary>
        /// This is to calculate the cost and type for each parcel
        /// </summary>
        /// <param name="parcel">The parcel to be delievered</param>
        /// <returns>The parcel information including cost and type</returns>
        public Parcel CalculateDeliveryCostByParcelSize(Parcel parcel)
        {
            if(parcel.IsOverweight)
            {
                parcel.Cost = overWeightParcelCost;
                if (parcel.Weight > 50)
                    parcel.Cost += overWeightParcelExcessCharge * (parcel.Weight - overWeightParcelWeightLimit);
            }

            if (parcel.Length >= largeParcelDimentionLimit ||
                parcel.Width >= largeParcelDimentionLimit ||
                parcel.Height >= largeParcelDimentionLimit)
            {
                parcel.Cost = 25;
                parcel.Type = ParcelSize.XLarge;
                if (parcel.Weight > xLParcelWeightLimit)
                    parcel.Cost += overChargePerKg * (parcel.Weight - xLParcelWeightLimit);                
            }

            else if(parcel.Length >= mediumParcelDimentionLimit && parcel.Length < largeParcelDimentionLimit &&
                parcel.Width >= mediumParcelDimentionLimit && parcel.Width <  largeParcelDimentionLimit &&
                parcel.Height >= mediumParcelDimentionLimit && parcel.Height < largeParcelDimentionLimit)
            {
                parcel.Cost = 15;
                parcel.Type = ParcelSize.Large;
                if (parcel.Weight > largeParcelWeightLimit)
                    parcel.Cost += overChargePerKg * (parcel.Weight - largeParcelWeightLimit);
            }

            else if (parcel.Length >= smallParcelDimentionLimit && parcel.Length < mediumParcelDimentionLimit &&
                parcel.Width >= smallParcelDimentionLimit && parcel.Width < mediumParcelDimentionLimit &&
                parcel.Height >= smallParcelDimentionLimit && parcel.Height < mediumParcelDimentionLimit)
            {
                parcel.Cost = 8;
                parcel.Type = ParcelSize.Medium;
                if (parcel.Weight > mediumParcelWeightLimit)
                    parcel.Cost += overChargePerKg * (parcel.Weight - mediumParcelWeightLimit);
            }
            else
            {
                parcel.Cost = 3;
                parcel.Type = ParcelSize.Small;
                if (parcel.Weight > smallParcelWeightLimit)
                    parcel.Cost += overChargePerKg * (parcel.Weight - smallParcelWeightLimit);
            }

            return parcel;
        }
     }
}
