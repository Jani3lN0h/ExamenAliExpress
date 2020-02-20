using System;

namespace AliExpress.Services.Interfaces
{
    public interface ICalculatePastDelivery
    {
        bool CalculateIsDelivered(DateTime dtToday, DateTime dtDelivery);
    }
}
