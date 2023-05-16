using Drones.Model.Context;
using Drones.Model.Repository.Interface;
using Drones.Model.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model.UnitOfWork;

public class UnitOfWork:IUnitOfWork
{
    private readonly IRepository<Drone> _droneRepo;
    private readonly IRepository<Medication> _medicationRepo;
    private readonly IRepository<Load> _loadRepo;
    private readonly DbContext _dbContext;
    public UnitOfWork(DroneContext dbContext ,IRepository<Drone> droneRepo, IRepository<Medication> medicationRepo, IRepository<Load> loadRepo)
    {
        _dbContext = dbContext;
        _droneRepo = droneRepo;
        _medicationRepo = medicationRepo;
        _loadRepo = loadRepo;
    }

    public IRepository<Drone> GetDroneRepo()
    {
        return _droneRepo;
    }

    public IRepository<Medication> GetMedicationRepo()
    {
        return _medicationRepo;
    }

    public IRepository<Load> GetLoadRepo()
    {
        return _loadRepo;
    }
    

    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}
