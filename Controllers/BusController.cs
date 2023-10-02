using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedBusService2._0.Entities;
using RedBusService2._0.Request;

using RedBusService2._0.Response;
namespace RedBusService2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
       BDbContext BusServicedbContext;
        IConfiguration configuration;
        public BusController(IConfiguration configuration, BDbContext dbContext)
        {
            this.configuration = configuration;
            this.BusServicedbContext = dbContext;
        }
        [HttpGet]

        [AllowAnonymous]
        public List<BusResponse> Get()
        {
            var Response = BusServicedbContext.Buses.Select(bus => new BusResponse
            {
                Id = bus.Id,
                RouteNumber = bus.RouteNumber.ToString(),
                Capacity = bus.Capacity,
                Condition = bus.Condition,
                fuelLevel = bus.fuelLevel.ToString(),
                TimeOfArrival = bus.TimeOfArrival,
                MaintainenceStates = bus.MaintainenceStates.ToString(),
                DriverId=bus.DriverId,
                IsAssociated = bus.DriverId != null

            }).ToList();

            return Response;

        }


        [HttpGet("BusesWithoutDrivers")]

        public ActionResult<BusResponse> GetBusWithoutDrivers()
        {
            var bus = BusServicedbContext.Buses.Where(bd => bd.DriverId == null).Select(bus => new BusResponse
            {
                Id = bus.Id,
                RouteNumber = bus.RouteNumber.ToString(),
                Capacity = bus.Capacity,
                Condition = bus.Condition,
                fuelLevel = bus.fuelLevel.ToString(),
                TimeOfArrival = bus.TimeOfArrival,
                MaintainenceStates = bus.MaintainenceStates.ToString(),

            }).ToList();
            if (bus == null) return NotFound("bus not found");
            //Where(any => any.bus.busdriver.DriverId == 0)
            return Ok(bus);

        }

        [HttpGet("BusesWithDrivers")]

        public ActionResult<BusResponse> GetBusWithDrivers()
        {
            var bus = BusServicedbContext.Buses.Where(bd => bd.DriverId == bd.Driver.Id).Select(bus => new BusResponse
            {
                Id = bus.Id,
                RouteNumber = bus.RouteNumber.ToString(),
                Capacity = bus.Capacity,
                Condition = bus.Condition,
                fuelLevel = bus.fuelLevel.ToString(),
                TimeOfArrival = bus.TimeOfArrival,
                MaintainenceStates = bus.MaintainenceStates.ToString(),
                
            }).ToList();
            if (bus == null) return NotFound("bus not found");
            //Where(any => any.bus.busdriver.DriverId == 0)
            return Ok(bus);

        }

       

        [HttpPost]

      //  [Authorize(Roles = $"{UserRoles.Admin}")]

        public bool Post(BusRequest request)
        {
            var busPost = new Bus
            {
                Capacity = request.Capacity,
                Condition = request.Condition,
                fuelLevel = request.fuelLevel,
                RouteNumber = request.RouteNumber,
                MaintainenceStates = request.MaintainenceStates,
                TimeOfArrival = request.TimeOfArrival

            };
            BusServicedbContext.Buses.Add(busPost);
            BusServicedbContext.SaveChanges();

            return true;
        }

        [HttpPut("{id}")]

      //  [Authorize(Roles = $"{UserRoles.Admin}")]

        public ActionResult<bool> Put(int id, BusRequest request)
        {
            var Update = BusServicedbContext.Buses.FirstOrDefault(i => i.Id == id);

            if (Update == null) return NotFound("Bus not Found");

            Update.Capacity = request.Capacity;
            Update.Condition = request.Condition;
            Update.fuelLevel = request.fuelLevel;
            Update.RouteNumber = request.RouteNumber;
            Update.MaintainenceStates = request.MaintainenceStates;
            Update.TimeOfArrival = request.TimeOfArrival;


            BusServicedbContext.Add(Update);
            BusServicedbContext.SaveChanges();


            return Ok(true);
        }
        [HttpDelete("{id}")]

      //  [Authorize(Roles = $"{UserRoles.Admin}")]

        public ActionResult<bool> Delete(int id)
        {
            var DeleteBus = BusServicedbContext.Buses.FirstOrDefault(i => i.Id == id);
            if (DeleteBus == null)
                return NotFound("Bus not Found");

            BusServicedbContext.Remove(DeleteBus);
            BusServicedbContext.SaveChanges();


            return Ok(true);
        }


    }

}
