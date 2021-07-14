using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipIt.Models.ApiModels
{
    public class OutboundOrderResponse: Response
    {
        public int TruckRequired { get; set; }
        public OutboundOrderResponse(int truckRequired)
        {
            TruckRequired = truckRequired;
            Success = true;
        }
    }
}
