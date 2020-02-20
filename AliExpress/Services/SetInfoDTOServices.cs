using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System;

namespace AliExpress.Services
{
    public class SetInfoDTOServices : ISetInfoDTOServices
    {
        private readonly ICalculatePastDelivery _calculatePastDelivery;
        public SetInfoDTOServices(ICalculatePastDelivery calculatePastDelivery)
        {
            _calculatePastDelivery = calculatePastDelivery ?? throw new ArgumentNullException(nameof(calculatePastDelivery));
        }
        public void CompleteDTOInfo(IPackageInfoDTO packageDTO)
        {
            if (packageDTO == null)
            {
                throw new ArgumentNullException(nameof(packageDTO));
            }

            packageDTO.lDelivered = _calculatePastDelivery.CalculateIsDelivered(packageDTO.dtToday, packageDTO.dtDeliveryDate);
        }
    }
}
