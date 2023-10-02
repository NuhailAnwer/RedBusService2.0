using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedBusService2._0.Entities;

namespace RedBusService2._0
{
    public class BDbContext : DbContext
    {

        public BDbContext(DbContextOptions<BDbContext> options) : base(options)
        { 
        
        }
         public DbSet<Bus> Buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }


    
    }



}

