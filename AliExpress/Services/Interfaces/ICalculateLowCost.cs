using AliExpress.Domain.Entities.Interfaces;

namespace AliExpress.Services.Interfaces
{
    public interface ICalculateLowCost
    {
        IPackageLowCostDTO GetPackageLowCostDTO(IPackageInfoDTO packageDTO);
    }
}
