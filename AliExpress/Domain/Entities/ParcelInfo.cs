using AliExpress.Domain.Entities.Interfaces;
using AliExpress.Services;
using AliExpress.Services.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Domain.Entities
{
    public class ParcelInfo : IParcelInfo
    {
        public List<ITransport> GetDHLTransport()
        {
            List<ITransport> lstTransport = new List<ITransport>();
            Plane plane = new Plane();
            lstTransport.Add(plane);
            Ship ship = new Ship();
            lstTransport.Add(ship);
            return lstTransport;
        }

        public List<ITransport> GetEstafetaTransport()
        {
            List<ITransport> lstTransport = new List<ITransport>();
            Train train = new Train();
            lstTransport.Add(train);
            Ship ship = new Ship();
            lstTransport.Add(ship);
            return lstTransport;
        }

        public List<ITransport> GetFedexTransport()
        {
            List<ITransport> lstTransport = new List<ITransport>();
            Ship ship = new Ship();
            lstTransport.Add(ship);
            return lstTransport;
        }
    }
}
