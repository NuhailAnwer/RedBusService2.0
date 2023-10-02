using RedBusService2._0.Entities;

namespace RedBusService2._0.Request
{


        public class BusRequest
        {
            public int Capacity { get; set; }
            public routeNumber RouteNumber { get; set; }
            public string Condition { get; set; }
            public fuelLevel fuelLevel { get; set; }
            public DateTime TimeOfArrival { get; set; }
            public maintainenceStates MaintainenceStates { get; set; }

            public int DriverId { get; set; }
        
        }

    
}

