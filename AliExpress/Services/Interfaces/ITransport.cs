namespace AliExpress.Services.Interfaces
{
    public interface ITransport
    {
        decimal dKmCostPerKm { get; }
        double dVelocity { get; }
        string cTransport { get; }
        decimal GetShippingCost(decimal dDistance, decimal dUtility);
    }
}
