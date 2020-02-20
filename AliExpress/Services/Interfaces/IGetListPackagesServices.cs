using AliExpress.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Services.Interfaces
{
    public interface IGetListPackagesServices
    {
        List<IPackage> GetListPackages(string path);
    }
}
