using AliExpress.Services.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Domain.Entities.Interfaces
{
    public interface IParcelInfo
    {
        List<ITransport> GetDHLTransport();
        List<ITransport> GetEstafetaTransport();
        List<ITransport> GetFedexTransport();
    }
}
