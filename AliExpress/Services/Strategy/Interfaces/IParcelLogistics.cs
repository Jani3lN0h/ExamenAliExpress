using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Services.Strategy.Interfaces
{
    public interface IParcelLogistics
    {
        List<ITransport> lstTransport { get; set; }
        string cParcel { get; }
        decimal dUtility { get; }
        bool ProcessPackage(IPackageInfoDTO package);
    }
}
