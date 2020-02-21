using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AliExpress.Services.UTests
{
    [TestClass()]
    public class GetPackagesMessagesUTests
    {
        public void GetPackagesMessages_IGetListPackagesServicesNull_ArgumentNullException()
        {
            //Arrange
            Mock<IDetermineParcelFactory> determineParcelFactory = new Mock<IDetermineParcelFactory>();
            Mock<IProcessMessagesServices> processMessagesServices = new Mock<IProcessMessagesServices>();
            Mock<ISetInfoDTOServices> setInfoDTOServices = new Mock<ISetInfoDTOServices>();
            Mock<ICalculateLowCost> calculateLowCost = new Mock<ICalculateLowCost>();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GetPackagesMessages(null, determineParcelFactory.Object, processMessagesServices.Object, setInfoDTOServices.Object, calculateLowCost.Object));
        }

        public void GetPackagesMessages_IDetermineParcelFactoryNull_ArgumentNullException()
        {
            //Arrange
            Mock<IGetListPackagesServices> getListPackagesServices = new Mock<IGetListPackagesServices>();
            Mock<IProcessMessagesServices> processMessagesServices = new Mock<IProcessMessagesServices>();
            Mock<ISetInfoDTOServices> setInfoDTOServices = new Mock<ISetInfoDTOServices>();
            Mock<ICalculateLowCost> calculateLowCost = new Mock<ICalculateLowCost>();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GetPackagesMessages(getListPackagesServices.Object, null, processMessagesServices.Object, setInfoDTOServices.Object, calculateLowCost.Object));
        }

        public void GetPackagesMessages_IProcessMessagesServicesNull_ArgumentNullException()
        {
            //Arrange
            Mock<IGetListPackagesServices> getListPackagesServices = new Mock<IGetListPackagesServices>();
            Mock<IDetermineParcelFactory> determineParcelFactory = new Mock<IDetermineParcelFactory>();
            Mock<ISetInfoDTOServices> setInfoDTOServices = new Mock<ISetInfoDTOServices>();
            Mock<ICalculateLowCost> calculateLowCost = new Mock<ICalculateLowCost>();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GetPackagesMessages(getListPackagesServices.Object, determineParcelFactory.Object, null, setInfoDTOServices.Object, calculateLowCost.Object));
        }

        public void GetPackagesMessages_ISetInfoDTOServicesNull_ArgumentNullException()
        {
            //Arrange
            Mock<IGetListPackagesServices> getListPackagesServices = new Mock<IGetListPackagesServices>();
            Mock<IDetermineParcelFactory> determineParcelFactory = new Mock<IDetermineParcelFactory>();
            Mock<IProcessMessagesServices> processMessagesServices = new Mock<IProcessMessagesServices>();
            Mock<ICalculateLowCost> calculateLowCost = new Mock<ICalculateLowCost>();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GetPackagesMessages(getListPackagesServices.Object, determineParcelFactory.Object, processMessagesServices.Object, null, calculateLowCost.Object));
        }

        public void GetPackagesMessages_ICalculateLowCostNull_ArgumentNullException()
        {
            //Arrange
            Mock<IGetListPackagesServices> getListPackagesServices = new Mock<IGetListPackagesServices>();
            Mock<IDetermineParcelFactory> determineParcelFactory = new Mock<IDetermineParcelFactory>();
            Mock<IProcessMessagesServices> processMessagesServices = new Mock<IProcessMessagesServices>();
            Mock<ISetInfoDTOServices> setInfoDTOServices = new Mock<ISetInfoDTOServices>();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GetPackagesMessages(getListPackagesServices.Object, determineParcelFactory.Object, processMessagesServices.Object, setInfoDTOServices.Object, null));
        }

        public void GetPackagesMessages_AllParametersCorrect_CreateInstance()
        {
            //Arrange
            Mock<IGetListPackagesServices> getListPackagesServices = new Mock<IGetListPackagesServices>();
            Mock<IDetermineParcelFactory> determineParcelFactory = new Mock<IDetermineParcelFactory>();
            Mock<IProcessMessagesServices> processMessagesServices = new Mock<IProcessMessagesServices>();
            Mock<ISetInfoDTOServices> setInfoDTOServices = new Mock<ISetInfoDTOServices>();
            Mock<ICalculateLowCost> calculateLowCost = new Mock<ICalculateLowCost>();

            //Act
            var result = new GetPackagesMessages(getListPackagesServices.Object, determineParcelFactory.Object, processMessagesServices.Object, setInfoDTOServices.Object, calculateLowCost.Object);

            //Assert
            Assert.IsInstanceOfType(result, typeof(GetPackagesMessages));
        }

        [TestMethod()]
        public void GetMessageTest_PathEmpty_ArgumentNullException()
        {
            //Arrange
            Mock<IGetListPackagesServices> getListPackagesServices = new Mock<IGetListPackagesServices>();
            Mock<IDetermineParcelFactory> determineParcelFactory = new Mock<IDetermineParcelFactory>();
            Mock<IProcessMessagesServices> processMessagesServices = new Mock<IProcessMessagesServices>();
            Mock<ISetInfoDTOServices> setInfoDTOServices = new Mock<ISetInfoDTOServices>();
            Mock<ICalculateLowCost> calculateLowCost = new Mock<ICalculateLowCost>();

            var SUT = new GetPackagesMessages(getListPackagesServices.Object, determineParcelFactory.Object, processMessagesServices.Object, setInfoDTOServices.Object, calculateLowCost.Object);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => SUT.GetMessage(null, DateTime.Now));
        }
    }
}