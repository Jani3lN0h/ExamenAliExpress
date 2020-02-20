using AliExpress.Domain.Entities.DTO;
using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using AliExpress.Services.Strategy.Interfaces;
using System;
using System.Collections.Generic;

namespace AliExpress.Services
{
    public class GetPackagesMessages : IGetPackagesMessages
    {
        private readonly IGetListPackagesServices _getListPackagesServices;
        private readonly IDetermineParcelFactory _determineParcelFactory;
        private readonly IProcessMessagesServices _processMessagesServices;
        private readonly ISetInfoDTOServices _setInfoDTOServices;
        private readonly ICalculateLowCost _calculateLowCost;

        public GetPackagesMessages(IGetListPackagesServices getListPackagesServices, IDetermineParcelFactory determineParcelFactory, IProcessMessagesServices processMessagesServices, ISetInfoDTOServices setInfoDTOServices, ICalculateLowCost calculateLowCost)
        {
            _getListPackagesServices = getListPackagesServices ?? throw new ArgumentNullException(nameof(getListPackagesServices));
            _determineParcelFactory = determineParcelFactory ?? throw new ArgumentNullException(nameof(determineParcelFactory));
            _processMessagesServices = processMessagesServices ?? throw new ArgumentNullException(nameof(processMessagesServices));
            _setInfoDTOServices = setInfoDTOServices ?? throw new ArgumentNullException(nameof(setInfoDTOServices));
            _calculateLowCost = calculateLowCost ?? throw new ArgumentNullException(nameof(calculateLowCost));
        }
        public void GetMessage(string path, DateTime dtToday)
        {
            List<IPackage> lstPackages = _getListPackagesServices.GetListPackages(path);
            CalculateMessagePackage(lstPackages, dtToday);
        }

        private void CalculateMessagePackage(List<IPackage> lstPackages, DateTime dtToday)
        {
            foreach (IPackage item in lstPackages)
            {
                IParcelLogistics parcelLogistic = _determineParcelFactory.DetermineParcel(item.cParcel);
                if (parcelLogistic != null)
                {
                    PackageInfoDTO packageInfoDTO = new PackageInfoDTO(item);
                    packageInfoDTO.dtToday = dtToday;

                    if (parcelLogistic.ProcessPackage(packageInfoDTO))
                    {
                        IPackageInfoDTO itemDTO = SetInfoDTO(packageInfoDTO);
                        _processMessagesServices.GetProcessMessage(itemDTO);
                        IPackageLowCostDTO packageLowCostDTO = _calculateLowCost.GetPackageLowCostDTO(itemDTO);
                        if (packageLowCostDTO != null)
                        {
                            _processMessagesServices.GetLowCostMessage(packageLowCostDTO);
                        }
                    }
                }
                else
                {
                    _processMessagesServices.GetInvalidParcelMeesage(item.cParcel);
                }
            }
        }

        private IPackageInfoDTO SetInfoDTO(IPackageInfoDTO itemDTO)
        {
            _setInfoDTOServices.CompleteDTOInfo(itemDTO);
            return itemDTO;
        }
    }
}
