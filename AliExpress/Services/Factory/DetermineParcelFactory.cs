using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using AliExpress.Services.Strategy;
using AliExpress.Services.Strategy.Interfaces;
using System;

namespace AliExpress.Services.Factory
{
    public class DetermineParcelFactory : IDetermineParcelFactory
    {
        private readonly IParcelInfo _parcelInfo;
        private readonly IProcessMessagesServices _processMessages;
        public DetermineParcelFactory(IProcessMessagesServices processMessages, IParcelInfo parcelInfo)
        {
            _parcelInfo = parcelInfo ?? throw new ArgumentNullException(nameof(parcelInfo));
            _processMessages = processMessages ?? throw new ArgumentNullException(nameof(processMessages));
        }

        public IParcelLogistics DetermineParcel(string cParcel)
        {
            IParcelLogistics parcel = null;
            switch (cParcel.ToUpper())
            {
                case "DHL":
                    parcel = new DHLStrategy(_processMessages);
                    parcel.lstTransport = _parcelInfo.GetDHLTransport();
                    break;
                case "ESTAFETA":
                    parcel = new EstafetaStrategy(_processMessages);
                    parcel.lstTransport = _parcelInfo.GetEstafetaTransport();
                    break;
                case "FEDEX":
                    parcel = new FedexStrategy(_processMessages);
                    parcel.lstTransport = _parcelInfo.GetFedexTransport();
                    break;
                default:
                    break;
            }
            return parcel;
        }
    }
}
