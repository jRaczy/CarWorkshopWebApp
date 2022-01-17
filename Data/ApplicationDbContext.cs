using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.Models;

namespace CarWorkshop.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Car> Car { get; set; }
        

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        
        //    builder.Entity<Car>()
        //        .HasOne(x => x.Client)
        //        .WithMany(x => x.Cars)
        //        .HasForeignKey(x => x.ClientId)
        //        ;
        //}
    }
}
