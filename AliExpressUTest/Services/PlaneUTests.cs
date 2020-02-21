using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace AliExpress.Services.UTests
{
    [TestClass()]
    public class PlaneUTests
    {
        [DataRow(10,40,140)]
        [TestMethod()]
        public void GetShippingCost_DistanceUtility_GetCorrectValue(int dDistance,int dUtility, int dResult)
        {
            //Arrange
            Plane plane = new Plane();

            //Act
            var result = plane.GetShippingCost(Convert.ToDecimal(dDistance), Convert.ToDecimal(dUtility));

            //Assert
            Assert.AreEqual(dResult, Convert.ToDecimal(result));
        }
    }
}