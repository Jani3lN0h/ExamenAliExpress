using AliExpress.Services.Interfaces;
using System;

namespace AliExpress.Services
{
    public class CalculatePastDelivery : ICalculatePastDelivery
    {
        public bool CalculateIsDelivered(DateTime dtToday, DateTime dtDelivery)
        {
            return (dtDelivery.CompareTo(dtToday) < 0 ? true : false);
        }
    }
}
