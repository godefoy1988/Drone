using Microsoft.EntityFrameworkCore;
using Drones.Model.Context;
using Drones.Model.Repository.Interface;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

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
    public T Update(T data)
    {
        return _dbSet.Update(data).Entity;
    }
    public Task<T> GetById(int id)
    {
        return _dbSet.SingleAsync(x => x.Id == id);
    }
    public async Task<IEnumerable<T>> GetAllAsync(IEnumerable<int> ids)
    {
        return await _dbSet.Where( t => ids.Contains(t.Id)).ToListAsync();
    }
    public IEnumerable<T> Where(Func<T, bool> filter, string include, string include2 )
    {
        return _dbSet.Include(include).Include(include2).Where(filter);
    }
}

