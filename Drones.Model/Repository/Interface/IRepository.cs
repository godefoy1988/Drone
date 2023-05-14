namespace Drones.Model.Repository.Interface;

public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T data);
    Task<int> SaveChangesAsync();
}

