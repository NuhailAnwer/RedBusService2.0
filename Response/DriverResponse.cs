namespace RedBusService2._0.Response
{
    public class DriverResponse
    {

        public int Id { get; set; }
        public string DriverName { get; set; }
        public string DriverLicense { get; set; }
        public DateOnly DateOfExpiry { get; set; }
        public bool TrafficRuleViolation { get; set; }
        public int YearOfExperience { get; set; }

        public string DrivingDetails { get; set; }



    }
}
