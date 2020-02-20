using AliExpress.Services.Strategy.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Services.Interfaces
{
    public interface IParcelAvailablesServices
    {
        List<IParcelLogistics> GetParcelsAvailables();
    }
}
