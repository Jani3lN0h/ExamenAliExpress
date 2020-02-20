using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using AliExpress.Services.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.Services.Strategy
{
    public class FedexStrategy : IParcelLogistics
    {
        public List<ITransport> lstTransport { get; set; }

        public string cParcel { get { return "Fedex"; } }

        public decimal dUtility { get { return 50; } }

        private readonly IProcessMessagesServices _processMessages;

        public FedexStrategy(IProcessMessagesServices processMessages)
        {
            this._processMessages = processMessages ?? throw new ArgumentNullException(nameof(processMessages));
        }

        public bool ProcessPackage(IPackageInfoDTO packageDTO)
        {
            bool lReturn = false;
            if (packageDTO == null)
            {
                throw new ArgumentNullException(nameof(packageDTO));
            }

            ITransport transport = GetTransport(packageDTO.cTransport);
            if (transport == null)
            {
                _processMessages.GetInvalidTransportMessage(packageDTO.cParcel, packageDTO.cTransport);
            }
            else
            {
                SetDeliveryDate(packageDTO, transport);
                packageDTO.dShippingCost = transport.GetShippingCost(Convert.ToDecimal(packageDTO.cDistance), dUtility);
                lReturn = true;
            }
            return lReturn;
        }

        private void SetDeliveryDate(IPackageInfoDTO packageDTO, ITransport transport)
        {
            double dShippingTime = Convert.ToDouble(packageDTO.cDistance) / transport.dVelocity;
            packageDTO.dtDeliveryDate = packageDTO.dtSend.AddHours(dShippingTime);
        }

        private ITransport GetTransport(string cTransport)
        {
            ITransport transport = null;
            if (lstTransport != null && lstTransport.Any())
            {
                transport = lstTransport.Where(x => x.cTransport.ToUpper() == cTransport.ToUpper()).FirstOrDefault();
            }
            return transport;
        }
    }
}
