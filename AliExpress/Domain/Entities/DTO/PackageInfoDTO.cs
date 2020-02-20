using AliExpress.Domain.Entities.Interfaces;
using System;

namespace AliExpress.Domain.Entities.DTO
{
    public class PackageInfoDTO : IPackageInfoDTO
    {
        public string cFrom { set; get; }
        public string cTo { set; get; }
        public string cDistance { set; get; }
        public string cParcel { set; get; }
        public string cTransport { set; get; }
        public DateTime dtSend { set; get; }
        public DateTime dtToday { set; get; }
        public decimal dShippingCost { set; get; }
        public bool lDelivered { set; get; }
        public DateTime dtDeliveryDate { set; get; }

        public PackageInfoDTO(IPackage package)
        {
            cFrom = package.cFrom;
            cTo = package.cTo;
            cDistance = package.cDistance;
            cParcel = package.cParcel;
            cTransport = package.cTransport;
            dtSend = package.dtSend;
        }
    }
}
