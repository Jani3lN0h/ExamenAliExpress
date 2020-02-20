using System;

namespace AliExpress.Domain.Entities.Interfaces
{
    public interface IPackage
    {
        string cFrom { set; get; }
        string cTo { set; get; }
        string cDistance { set; get; }
        string cParcel { set; get; }
        string cTransport { set; get; }
        DateTime dtSend { set; get; }
    }
}
