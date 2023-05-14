using Microsoft.EntityFrameworkCore;
using Drones.Model.Context;
using Drones.Model.Repository.Interface;

namespace Drones.Model.Repository;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DroneContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(DroneContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task AddAsync(T data)
    {
        await _dbSet.AddAsync(data);        
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}

