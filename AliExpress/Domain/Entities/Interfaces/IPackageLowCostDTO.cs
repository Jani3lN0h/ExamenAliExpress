namespace AliExpress.Domain.Entities.Interfaces
{
    public interface IPackageLowCostDTO
    {
        string cParcel { set; get; }
        decimal dShippingCost { set; get; }
    }
}
