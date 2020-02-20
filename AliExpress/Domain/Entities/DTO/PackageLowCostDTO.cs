using AliExpress.Domain.Entities.Interfaces;

namespace AliExpress.Domain.Entities.DTO
{
    public class PackageLowCostDTO : IPackageLowCostDTO
    {
        public string cParcel { get; set; }
        public decimal dShippingCost { get; set; }
    }
}
