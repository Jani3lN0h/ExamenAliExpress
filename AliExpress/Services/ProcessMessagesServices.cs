using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System;

namespace AliExpress.Services
{
    public class ProcessMessagesServices : IProcessMessagesServices
    {
        public void GetInvalidParcelMeesage(string cParcel)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string cMensaje = string.Format("La  Paquetería: {0} no se encuentra registrada en nuestra red de distribución.", cParcel);
            Console.WriteLine(cMensaje);
        }

        public void GetInvalidTransportMessage(string cParcel, string cTransport)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string cMensaje = string.Format("{0} no ofrece el servicio de transporte {1}, te recomendamos cotizar en otra empresa.", cParcel, cTransport);
            Console.WriteLine(cMensaje);
        }

        public void GetLowCostMessage(IPackageLowCostDTO packageLowCost)
        {
            Console.ResetColor();
            string cMensaje = string.Format("Si hubieras pedido en {0} te hubiera costado {1} más barato.", packageLowCost.cParcel, packageLowCost.dShippingCost.ToString("C"));
            Console.WriteLine(cMensaje);
        }

        public void GetProcessMessage(IPackageInfoDTO package)
        {
            GetForegroundColor(package.lDelivered);
            string cExpression1 = GetExpression1(package.lDelivered);
            string cExpression2 = GetExpression2(package.lDelivered);
            string cExpression3 = GetExpression3(package.lDelivered);
            string cMessage = "Tu paquete {0} de {1} y {2} a {3} el {4} y {5} un costo de {6} (Cualquier reclamación con {7}).";
            cMessage = string.Format(cMessage, cExpression1, package.cFrom, cExpression2, package.cTo, package.dtDeliveryDate, cExpression3, package.dShippingCost.ToString("C"), package.cParcel);
            Console.WriteLine(cMessage);
        }

        private string GetExpression1(bool lDelivered)
        {
            return (lDelivered ? "salió" : "ha salido");
        }

        private string GetExpression2(bool lDelivered)
        {
            return (lDelivered ? "llegó" : "llegará");
        }

        private string GetExpression3(bool lDelivered)
        {
            return (lDelivered ? "tuvo" : "tendrá");
        }

        private void GetForegroundColor(bool lDelivered)
        {
            if (lDelivered)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
    }
}
