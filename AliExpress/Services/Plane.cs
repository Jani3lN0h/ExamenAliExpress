using AliExpress.Services.Interfaces;

namespace AliExpress.Services
{
    public class Plane : ITransport
    {
        public decimal dKmCostPerKm { get { return 10; } }

        public double dVelocity { get { return 600; } }

        public string cTransport { get { return "Avión"; } }

        public decimal GetShippingCost(decimal dDistance, decimal dUtility)
        {
            decimal dShippingCost = 0;
            dShippingCost = (dKmCostPerKm * dDistance) * (1 + (dUtility / 100));
            return dShippingCost;
        }
    }
}
