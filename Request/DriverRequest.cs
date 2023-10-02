using RedBusService2._0.Entities;

namespace RedBusService2._0.Request
{
    public class DriverRequest
    {

        public string DriverName { get; set; }
        public string DriverLicense { get; set; }
        public DateOnly DateOfExpiry { get; set; }
        public bool TrafficRuleViolation { get; set; }
        public int YearOfExperience { get; set; }

        public DrivingDetails DrivingDetails { get; set; }
      
    }
}
