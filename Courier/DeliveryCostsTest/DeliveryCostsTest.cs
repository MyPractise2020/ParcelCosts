using System;
using DeliveryCosts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeliveryCostsTest
{
    [TestClass]
    public class DeliveryCostsTest
    {
        [TestMethod]
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
            var costCalculation = new DeliveryCosts();
            var targetParcel = costCalculation.CalculateDeliveryCostByParcelSize(parcel);

            //Assert
            Assert.AreEqual(25, targetParcel.Cost);
        }
    }
}
