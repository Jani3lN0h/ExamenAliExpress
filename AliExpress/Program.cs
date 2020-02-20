using AliExpress.Domain.Entities;
using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services;
using AliExpress.Services.Factory;
using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using System;
using System.IO;

namespace AliExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InitApp();
            }
            catch (Exception ex)
            {
                Console.ResetColor();
                Console.WriteLine(ex.Message);
                Console.WriteLine("\r\n Press any key to exit...");
                System.Console.ReadKey();
            }
        }

        private static void InitApp()
        {

            DateTime dtToday = new DateTime(2020, 1, 23, 14, 00, 00);

            //Se obtiene la ruta del archivo.
            string cPath = string.Format("{0}{1}", Directory.GetCurrentDirectory(), @"\AppData\shippings.csv");

            IParcelInfo parcelInfo = new ParcelInfo();
            IProcessMessagesServices processMessages = new ProcessMessagesServices();
            IGetFileInfoServices getFileInfoServices = new GetFileInfoService();
            ICalculatePastDelivery calculatePastDelivery = new CalculatePastDelivery();
            ISetInfoDTOServices setInfoDTOServices = new SetInfoDTOServices(calculatePastDelivery);
            IGetListPackagesServices getListPackagesServices = new GetListPackagesServices(getFileInfoServices);
            IDetermineParcelFactory determineParcelFactory = new DetermineParcelFactory(processMessages, parcelInfo);
            IParcelAvailablesServices parcelAvailablesServices = new ParcelAvailableService(determineParcelFactory);
            ICalculateLowCost calculateLowCost = new CalculateLowCost(parcelAvailablesServices);
            IGetPackagesMessages getPackagesMessages = new GetPackagesMessages(getListPackagesServices, determineParcelFactory, processMessages, setInfoDTOServices, calculateLowCost);
            getPackagesMessages.GetMessage(cPath, dtToday);
            Console.ResetColor();
            Console.WriteLine("\r\n Press any key to exit...");
            System.Console.ReadKey();
        }
    }
}
