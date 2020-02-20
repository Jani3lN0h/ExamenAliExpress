using System;

namespace AliExpress.Domain.Entities.Interfaces
{
    public interface IPackageInfoDTO
    {
        string cFrom { set; get; }
        string cTo { set; get; }
        string cDistance { set; get; }
        string cParcel { set; get; }
        string cTransport { set; get; }
        DateTime dtSend { set; get; }
        DateTime dtToday { set; get; }
        decimal dShippingCost { set; get; }
        bool lDelivered { set; get; }
        DateTime dtDeliveryDate { set; get; }
    }
}
