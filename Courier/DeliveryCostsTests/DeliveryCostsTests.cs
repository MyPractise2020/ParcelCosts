using DeliveryCosts;
using NUnit.Framework;
using System.Collections.Generic;


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
    }
}