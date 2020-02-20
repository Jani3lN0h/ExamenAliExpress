using AliExpress.Domain.Entities.Interfaces;

namespace AliExpress.Services.Interfaces
{
    public interface ISetInfoDTOServices
    {
        void CompleteDTOInfo(IPackageInfoDTO packageDTO);
    }
}
