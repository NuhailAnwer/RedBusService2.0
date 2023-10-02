namespace RedBusService2._0.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string DriverLicense { get; set; }
        public DateOnly DateOfExpiry { get; set; }
        public bool TrafficRuleViolation { get; set; }
        public int YearOfExperience { get; set; }

        public DrivingDetails DrivingDetails { get; set; }
        
        public Bus? Bus { get; set; }


    }
    public enum DrivingDetails
    {
        Starter = 1,
        Average, Professional
    }
}
