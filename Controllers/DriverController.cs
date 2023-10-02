using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedBusService2._0.Entities;
using RedBusService2._0.Request;
using RedBusService2._0.Response;
using RedBusService2._0.Entities;
using RedBusService2._0.Request;
using RedBusService2._0;

namespace RedBusService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class DriverController : ControllerBase
    {
        BDbContext BusServicedbContext;
        IConfiguration configuration;
        public DriverController(IConfiguration configuration, BDbContext dbContext)
        {
            this.configuration = configuration;
            this.BusServicedbContext = dbContext;
        }
        [HttpGet]
        public List<DriverResponse> Get()
        {
            var DriverGet = BusServicedbContext.Drivers.Select(mn => new DriverResponse
            {
                Id = mn.Id,
                DriverName = mn.DriverName,
                DriverLicense = mn.DriverLicense,
                DateOfExpiry = mn.DateOfExpiry,
                DrivingDetails = mn.DrivingDetails.ToString(),
                YearOfExperience = mn.YearOfExperience,
                TrafficRuleViolation = mn.TrafficRuleViolation

            }).ToList();
            return DriverGet;


        }


        [HttpPost]
       public bool PostDriverRequest(DriverRequest request)
        {
            var DriverPost = new Driver
            {
                DriverName = request.DriverName,
                DriverLicense = request.DriverLicense,
                DrivingDetails = request.DrivingDetails,
                DateOfExpiry = request.DateOfExpiry,
                TrafficRuleViolation = request.TrafficRuleViolation,
                YearOfExperience = request.YearOfExperience
            };
            BusServicedbContext.Add(DriverPost);
            BusServicedbContext.SaveChanges();

            return true;
        }


        [HttpGet("{id}")]
        public ActionResult<DriverResponse> GetSpecific(int id)
        {
            var DriverGet = BusServicedbContext.Drivers
            .Select(mn => new DriverResponse
            {
                DriverName = mn.DriverName,
                DriverLicense = mn.DriverLicense,
                DateOfExpiry = mn.DateOfExpiry,
                DrivingDetails = mn.DrivingDetails.ToString(),
                YearOfExperience = mn.YearOfExperience,
                TrafficRuleViolation = mn.TrafficRuleViolation

            }).FirstOrDefault(i => i.Id == id);
            if (DriverGet == null) return NotFound("driver not found");
            return DriverGet;


        }

        [HttpPut("{id}")]

        public ActionResult<bool> Put(int id, DriverRequest request)
        {
            var Update = BusServicedbContext.Drivers.FirstOrDefault(i => i.Id == id);

            if (Update == null) return NotFound("Bus not Found");

            Update.DriverName = request.DriverName;
            Update.DriverLicense = request.DriverLicense;
            Update.DrivingDetails = request.DrivingDetails;
            Update.DateOfExpiry = request.DateOfExpiry;
            Update.TrafficRuleViolation = request.TrafficRuleViolation;
            Update.YearOfExperience = request.YearOfExperience;

            BusServicedbContext.Add(Update);
            BusServicedbContext.SaveChanges();


            return Ok(true);
        }

        [HttpDelete("{id}")]

        public ActionResult<bool> Delete(int id)
        {
            var DeleteBus = BusServicedbContext.Drivers.FirstOrDefault(i => i.Id == id);
            if (DeleteBus == null)
                return NotFound("Bus not Found");

            BusServicedbContext.Remove(DeleteBus);
            BusServicedbContext.SaveChanges();


            return Ok(true);
        }



        [HttpPatch("Assosiate_driver_with_bus")]


        public bool Patch(BusDriverRequest request)
        {
            var Update = BusServicedbContext.Buses.FirstOrDefault(d => d.Id == request.BusId);
            Update.DriverId = request.DriverId;
            BusServicedbContext.Update(Update);
            BusServicedbContext.SaveChanges();

            return true;
        }


        [HttpDelete("Unassosiate_driver_with_bus")]


        public ActionResult<bool> DeleteDriverBus(BusDriverRequest request)
        {
            var Del = BusServicedbContext.Buses.FirstOrDefault(i => i.Id  ==  request.BusId );

            Del.DriverId = null;
            BusServicedbContext.Update(Del);
            BusServicedbContext.SaveChanges();
            return true;

        }
        
        [HttpGet("DriverssWithoutBuses")]
        public ActionResult<DriverResponse> GetDriverWithout()
        {
            var bus = BusServicedbContext.Drivers.Where(bd => bd.Id != bd.Bus.DriverId)
            .Select(mn => new DriverResponse
            {
                DriverName = mn.DriverName,
                DriverLicense = mn.DriverLicense,
                DateOfExpiry = mn.DateOfExpiry,
                DrivingDetails = mn.DrivingDetails.ToString(),
                YearOfExperience = mn.YearOfExperience,
                TrafficRuleViolation = mn.TrafficRuleViolation

            }).ToList();


            if (bus == null) return NotFound("bus not found");

            return Ok(bus);

        }
        [AllowAnonymous]
        [HttpGet("driverWithBuses")]
        public List<DriverResponse> GetBusWithDriver()
        {
            var Response = BusServicedbContext.Drivers.Where(bd => bd.Id == bd.Bus.DriverId )
           .Select(bd => new DriverResponse
           {
               Id = bd.Id,
               DriverName = bd.DriverName,
               DriverLicense = bd.DriverLicense,
               DateOfExpiry = bd.DateOfExpiry,
               DrivingDetails = bd.DrivingDetails.ToString(),
               YearOfExperience = bd.YearOfExperience,
               TrafficRuleViolation = bd.TrafficRuleViolation

           }).ToList();

            return Response;
        }




        
    }
}
