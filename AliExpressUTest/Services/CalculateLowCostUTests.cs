using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AliExpress.Services.Interfaces;
using AliExpress.Domain.Entities.Interfaces;

namespace AliExpress.Services.UTests
{
    [TestClass()]
    public class CalculateLowCostUTests
    {
        [TestMethod()]
        public void CalculateLowCostTest_IParcelAvailablesServicesNull_ArgumentNullException()
        {
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CalculateLowCost(null));
        }

        [TestMethod()]
        public void CalculateLowCostTest_IParcelAvailablesServicesCorrect_CreateInstance()
        {
            //Arrange
            Mock<IParcelAvailablesServices> parcelAvailablesServices = new Mock<IParcelAvailablesServices>();

            //Act
            var resultado = new CalculateLowCost(parcelAvailablesServices.Object);

            //Assert
            Assert.IsInstanceOfType(resultado, typeof(CalculateLowCost));
        }

        [TestMethod()]
        public void GetPackageLowCostDTO_IPackageInfoDTONull_ArgumentNullException()
        {
            //Arrange
            Mock<IParcelAvailablesServices> parcelAvailablesServices = new Mock<IParcelAvailablesServices>();

            var SUT = new CalculateLowCost(parcelAvailablesServices.Object);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => SUT.GetPackageLowCostDTO(null));
        }

        [TestMethod()]
        public void GetPackageLowCostDTO_IPackageInfoDTOCorrect_ReturnPackageLowCost()
        {
            //Arrange
            Mock<IParcelAvailablesServices> parcelAvailablesServices = new Mock<IParcelAvailablesServices>();
            Mock<IPackageInfoDTO> packageLowCostDTO = new Mock<IPackageInfoDTO>(); 

            var SUT = new CalculateLowCost(parcelAvailablesServices.Object);

            //Act
            var result = SUT.GetPackageLowCostDTO(packageLowCostDTO.Object);

            //Assert
            Assert.IsTrue(result.cParcel == "");
        }
    }
}