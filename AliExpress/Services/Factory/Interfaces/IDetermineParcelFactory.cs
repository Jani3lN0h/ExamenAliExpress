using AliExpress.Services.Strategy.Interfaces;

namespace AliExpress.Services.Factory.Interfaces
{
    public interface IDetermineParcelFactory
    {
        IParcelLogistics DetermineParcel(string cParcel);
    }
}
