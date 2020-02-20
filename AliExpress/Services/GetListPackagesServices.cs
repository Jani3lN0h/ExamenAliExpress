using AliExpress.Domain.Entities;
using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AliExpress.Services
{
    public class GetListPackagesServices : IGetListPackagesServices
    {
        private readonly IGetFileInfoServices _getFileInfo;

        public GetListPackagesServices(IGetFileInfoServices getFileInfoServices)
        {
            _getFileInfo = getFileInfoServices ?? throw new ArgumentNullException(nameof(getFileInfoServices));
        }
        public List<IPackage> GetListPackages(string path)
        {
            List<IPackage> lstPackages = new List<IPackage>();
            string[] arrPackages = _getFileInfo.ReadFile(path);
            if (arrPackages != null)
            {
                lstPackages = SetPackage(arrPackages);
            }
            return lstPackages;
        }

        private List<IPackage> SetPackage(string[] arrPackages)
        {
            List<IPackage> lstPackages = new List<IPackage>();
            foreach (string item in arrPackages)
            {
                string[] arrValues = SplitValues(item);
                IPackage evento = SetValues(arrValues);
                lstPackages.Add(evento);
            }
            return lstPackages;
        }

        private IPackage SetValues(string[] arrValues)
        {
            IPackage package = new Package();
            switch (arrValues.Length)
            {
                case 1:
                    package.cFrom = arrValues[0];
                    break;
                case 2:
                    package.cFrom = arrValues[0];
                    package.cTo = arrValues[1];
                    break;
                case 3:
                    package.cFrom = arrValues[0];
                    package.cTo = arrValues[1];
                    package.cDistance = arrValues[2];
                    break;
                case 4:
                    package.cFrom = arrValues[0];
                    package.cTo = arrValues[1];
                    package.cDistance = arrValues[2];
                    package.cParcel = arrValues[3];
                    break;
                case 5:
                    package.cFrom = arrValues[0];
                    package.cTo = arrValues[1];
                    package.cDistance = arrValues[2];
                    package.cParcel = arrValues[3];
                    package.cTransport = arrValues[4];
                    break;
                case 6:
                    package.cFrom = arrValues[0];
                    package.cTo = arrValues[1];
                    package.cDistance = arrValues[2];
                    package.cParcel = arrValues[3];
                    package.cTransport = arrValues[4];
                    package.dtSend = Convert.ToDateTime(arrValues[5]);
                    break;
                default:
                    break;
            }
            return package;
        }

        private string[] SplitValues(string item)
        {
            return item.Split(',');
        }
    }
}
