using AliExpress.Services.Interfaces;

namespace AliExpress.Services
{
    public class Ship : ITransport
    {
        public decimal dKmCostPerKm { get { return 1; } }

        public double dVelocity { get { return 46; } }

        public string cTransport { get { return "Barco"; } }

        public decimal GetShippingCost(decimal dDistance, decimal dUtility)
        {
            decimal dShippingCost = 0;
            dShippingCost = (dKmCostPerKm * dDistance) * (1 + (dUtility / 100));
            return dShippingCost;
        }
    }
}
