using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using AliExpress.Services.Strategy.Interfaces;
using System;
using System.Collections.Generic;

namespace AliExpress.Services
{
    public class ParcelAvailableService : IParcelAvailablesServices
    {
        private readonly IDetermineParcelFactory _determineParcelFactory;

        public ParcelAvailableService(IDetermineParcelFactory determineParcelFactory)
        {
            _determineParcelFactory = determineParcelFactory ?? throw new ArgumentNullException(nameof(determineParcelFactory));
        }

        public List<IParcelLogistics> GetParcelsAvailables()
        {
            List<IParcelLogistics> lstParcels = new List<IParcelLogistics>();
            lstParcels.Add(_determineParcelFactory.DetermineParcel("DHL"));
            lstParcels.Add(_determineParcelFactory.DetermineParcel("Estafeta"));
            lstParcels.Add(_determineParcelFactory.DetermineParcel("Fedex"));

            return lstParcels;
        }
    }
}
