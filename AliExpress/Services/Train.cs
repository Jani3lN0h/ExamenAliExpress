using AliExpress.Services.Interfaces;

namespace AliExpress.Services
{
    public class Train : ITransport
    {
        public decimal dKmCostPerKm { get { return 5; } }

        public double dVelocity { get { return 80; } }

        public string cTransport { get { return "Tren"; } }

        public decimal GetShippingCost(decimal dDistance, decimal dUtility)
        {
            decimal dShippingCost = 0;
            dShippingCost = (dKmCostPerKm * dDistance) * (1 + (dUtility / 100));
            return dShippingCost;
        }
    }
}
