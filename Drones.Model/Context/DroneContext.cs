using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model.Context;

public class DroneContext : DbContext
{
    private readonly string connectionString;
    public DbSet<Drone> Drones { get; set; }
    public DbSet<Medication> Medication { get; set; }
    public DbSet<Load> Loads { get; set; }

    public DroneContext()                    
    {
        this.connectionString = "DroneInMemoryDatabase";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(this.connectionString);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);       

    //    modelBuilder.Entity<Load>().
    //}
}


