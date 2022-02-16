using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarWorkshop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Appointment> Appointment {get;set;}
        
    }
}
