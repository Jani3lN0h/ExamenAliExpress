using AliExpress.Domain.Entities.Interfaces;
using System;

namespace AliExpress.Domain.Entities
{
    public class Package : IPackage
    {
        public string cFrom { set; get; }
        public string cTo { set; get; }
        public string cDistance { set; get; }
        public string cParcel { set; get; }
        public string cTransport { set; get; }
        public DateTime dtSend { set; get; }
    }
}
