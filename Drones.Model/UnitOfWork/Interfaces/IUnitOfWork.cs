using Drones.Model.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Drone> GetDroneRepo();
        IRepository<Medication> GetMedicationRepo();
        IRepository<Load> GetLoadRepo();
        Task<int> SaveChangesAsync();
    }
}
