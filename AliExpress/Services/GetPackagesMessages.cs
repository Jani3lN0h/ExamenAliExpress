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

        /// <summary>
        /// Constructor de la clase GetPackagesMessages.
        /// </summary>
        /// <param name="getListPackagesServices">Dependencia de tipo IGetListPackagesServices.</param>
        /// <param name="determineParcelFactory">Dependencia de tipo IDetermineParcelFactory.</param>
        /// <param name="processMessagesServices">Dependencia de tipo IProcessMessagesServices.</param>
        /// <param name="setInfoDTOServices">Dependencia de tipo ISetInfoDTOServices.</param>
        /// <param name="calculateLowCost">Dependencia de tipo ICalculateLowCost</param>
        public GetPackagesMessages(IGetListPackagesServices getListPackagesServices, IDetermineParcelFactory determineParcelFactory, IProcessMessagesServices processMessagesServices, ISetInfoDTOServices setInfoDTOServices, ICalculateLowCost calculateLowCost)
        {
            _getListPackagesServices = getListPackagesServices ?? throw new ArgumentNullException(nameof(getListPackagesServices));
            _determineParcelFactory = determineParcelFactory ?? throw new ArgumentNullException(nameof(determineParcelFactory));
            _processMessagesServices = processMessagesServices ?? throw new ArgumentNullException(nameof(processMessagesServices));
            _setInfoDTOServices = setInfoDTOServices ?? throw new ArgumentNullException(nameof(setInfoDTOServices));
            _calculateLowCost = calculateLowCost ?? throw new ArgumentNullException(nameof(calculateLowCost));
        }

        /// <summary>
        /// Método que se encargará de obtener el mensaje a mostrar.
        /// </summary>
        /// <param name="path">Ruta del archivo donde se obtiene la lista de paquetes.</param>
        /// <param name="dtToday">Fecha con la que se está evaluando el envío (Puede ser hoy).</param>
        public void GetMessage(string path, DateTime dtToday)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            List<IPackage> lstPackages = _getListPackagesServices.GetListPackages(path);
            CalculateMessagePackage(lstPackages, dtToday);
        }

        /// <summary>
        /// Método que calcula el mensaje a mostrar, dependiente si existe una paquetería o no.
        /// </summary>
        /// <param name="lstPackages">Lista de paquetes que se obtienen del archivo csv.</param>
        /// <param name="dtToday">Fecha con la cual se hace la comparación del envío.</param>
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

        /// <summary>
        /// Método que se encarga de completar la información del DTO llamando al servicio.
        /// </summary>
        /// <param name="itemDTO">Objeto del DTO que se va a completar.</param>
        /// <returns></returns>
        private IPackageInfoDTO SetInfoDTO(IPackageInfoDTO itemDTO)
        {
            _setInfoDTOServices.CompleteDTOInfo(itemDTO);
            return itemDTO;
        }
    }
}
