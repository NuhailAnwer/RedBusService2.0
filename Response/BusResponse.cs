namespace RedBusService2._0.Response
{
    public class BusResponse
    {

        public int Id { get; set; }
        public int Capacity { get; set; }
        public string RouteNumber { get; set; }
        public string Condition { get; set; }
        public string fuelLevel { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public string MaintainenceStates { get; set; }

        public int? DriverId { get; set; }   
        public bool IsAssociated {  get; set; }
       
    }
}
