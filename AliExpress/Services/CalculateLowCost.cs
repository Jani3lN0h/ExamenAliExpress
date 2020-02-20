using AliExpress.Domain.Entities.DTO;
using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using AliExpress.Services.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.Services
{
    public class CalculateLowCost : ICalculateLowCost
    {
        private readonly IParcelAvailablesServices _parcelAvailablesServices;
        public CalculateLowCost(IParcelAvailablesServices parcelAvailablesServices)
        {
            _parcelAvailablesServices = parcelAvailablesServices ?? throw new ArgumentNullException(nameof(parcelAvailablesServices));
        }

        public IPackageLowCostDTO GetPackageLowCostDTO(IPackageInfoDTO packageDTO)
        {
            if (packageDTO == null)
            {
                throw new ArgumentNullException(nameof(packageDTO));
            }

            return GetLowCost(packageDTO);
        }

        private IPackageLowCostDTO GetLowCost(IPackageInfoDTO package)
        {
            IPackageLowCostDTO packageLowCostDTO = null;
            decimal dShippingCost = 0, dLowCost = 0;
            bool lFirst = true;
            List<IParcelLogistics> lstParcels = _parcelAvailablesServices.GetParcelsAvailables();
            ITransport transport = null;
            if (lstParcels.Any())
            {
                foreach (IParcelLogistics item in lstParcels.Where(x => x.cParcel.ToUpper() != package.cParcel.ToUpper()))
                {
                    transport = item.lstTransport.Where(x => x.cTransport.ToUpper() == package.cTransport.ToUpper()).FirstOrDefault();
                    if (transport != null)
                    {
                        if (lFirst)
                        {
                            dLowCost = package.dShippingCost;
                            lFirst = false;
                        }

                        dShippingCost = decimal.MaxValue;

                        dShippingCost = transport.GetShippingCost(Convert.ToDecimal(package.cDistance), item.dUtility);

                        if (dShippingCost < dLowCost)
                        {
                            decimal dDifference = package.dShippingCost - dShippingCost;
                            packageLowCostDTO = SetPackageLowCost(item.cParcel, dDifference);
                            dLowCost = dShippingCost;
                        }
                    }
                }
            }
            return packageLowCostDTO;
        }

        private IPackageLowCostDTO SetPackageLowCost(string cParcel, decimal dCosto)
        {
            IPackageLowCostDTO packageLowCostDTO = new PackageLowCostDTO();
            packageLowCostDTO.cParcel = cParcel;
            packageLowCostDTO.dShippingCost = dCosto;
            return packageLowCostDTO;
        }
    }
}
