using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AirportService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAirportService" in both code and config file together.
    [ServiceContract]
    public interface IAirportService
    {
        [OperationContract]
        Airport GetAirport(string airportICAOCode);

        [OperationContract]
        void SaveAirport(Airport airport);

    }
}
