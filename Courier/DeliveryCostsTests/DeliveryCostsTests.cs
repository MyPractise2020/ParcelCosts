using DeliveryCosts;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;

namespace DeliveryCostsTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateParcleBySizeTestForXLParcel()
        {
            //Arrange
            var parcel = new Parcel()
            {
                Height = 300,
                Length = 50,
                Width = 60
            };

            //Act
            var costCalculation = new DeliveryCostsCalculation();
            var targetParcel = costCalculation.CalculateDeliveryCostByParcelSize(parcel);

            //Assert
            Assert.AreEqual(25, targetParcel.Cost);
        }

        [Test]
        public void CalculateParcleBySizeTestForLargeParcel()
        {
            //Arrange
            var parcel = new Parcel()
            {
                Height = 90,
                Length = 50,
                Width = 60
            };

            //Act
            var costCalculation = new DeliveryCostsCalculation();
            var targetParcel = costCalculation.CalculateDeliveryCostByParcelSize(parcel);

            //Assert
            Assert.AreEqual(15, targetParcel.Cost);
        }

        [Test]
        public void CalculateParcleBySizeTestForMediumParcel()
        {
            //Arrange
            var parcel = new Parcel()
            {
                Height = 10,
                Length = 30,
                Width = 40
            };
            //Act
            var costCalculation = new DeliveryCostsCalculation();
            var targetParcel = costCalculation.CalculateDeliveryCostByParcelSize(parcel);

            //Assert
            Assert.AreEqual(8, targetParcel.Cost);
        }

        [Test]
        public void CalculateParcleBySizeTestForSmallParcel()
        {
            //Arrange
            var parcel = new Parcel()
            {
                Height = 6,
                Length = 7,
                Width = 9
            };

            //Act
            var cost = new DeliveryCostsCalculation();
            var targetParcel = cost.CalculateDeliveryCostByParcelSize(parcel);

            //Assert
            Assert.AreEqual(3, targetParcel.Cost);
        }

        [Test]
        public void CalculateOrderCostTestWithoutSpeedyShippingTest()
        {
            //Arrange
            List<Parcel> parcels = new List<Parcel>();
            parcels.Add(new Parcel
            {
                Height = 6,
                Length = 7,
                Width = 9
            });
            parcels.Add(new Parcel
            {
                Height = 10,
                Length = 30,
                Width = 40
            });


            //Act
            var cost = new DeliveryCostsCalculation();
            var order = cost.CalculateOrderCost(parcels);

            //Assert
            Assert.AreEqual(11, order.TotalCost);
        }

        //to Do add parcel type check and more edge cases

        [Test]
        public void CalculateOrderCostTestWithSpeedyShippingTest()
        {
            //Arrange
            List<Parcel> parcels = new List<Parcel>();
            parcels.Add(new Parcel
            {
                Height = 6,
                Length = 7,
                Width = 9
            });
            parcels.Add(new Parcel
            {
                Height = 10,
                Length = 30,
                Width = 40
            });

            //Act
            var cost = new DeliveryCostsCalculation();
            var order = cost.CalculateOrderCost(parcels, true);
            //Assert
            Assert.AreEqual(11, order.TotalCost);
            Assert.AreEqual(22, order.TotalCostWithSpeedyShipping);
        }

        //add more edge cases

        [Test]
        public void CalculateOverWeightParcelForSmallSize()
        {
            //Arrange
            List<Parcel> parcels = new List<Parcel>();
            parcels.Add(new Parcel
            {
                Height = 6,
                Length = 7,
                Width = 9,
                Weight = 11
            });

            //Act
            var cost = new DeliveryCostsCalculation();
            var order = cost.CalculateOrderCost(parcels, true);
            //Assert
            Assert.AreEqual(23, order.TotalCost);
        }

        
        //To Do add test for XL, large , medium size  parcels

        //To Do add test for over weight parcel cost calculation
       
    }

}