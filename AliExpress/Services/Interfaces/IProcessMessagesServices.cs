using AliExpress.Domain.Entities.Interfaces;

namespace AliExpress.Services.Interfaces
{
    public interface IProcessMessagesServices
    {
        void GetInvalidParcelMeesage(string cParcel);
        void GetInvalidTransportMessage(string cParcel, string cTransport);
        void GetProcessMessage(IPackageInfoDTO package);
        void GetLowCostMessage(IPackageLowCostDTO packageLowCost);
    }
}
