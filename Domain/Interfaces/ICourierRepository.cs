using Domain.Entities;

namespace Domain.Interfaces;
public interface ICourierRepository
{
    Task<Courier> GetByIdAsync(int id);
    Task<IEnumerable<Courier>> GetAllAsync();
    Task AddAsync(Courier courier);
    Task UpdateAsync(Courier courier);
    Task DeleteAsync(int id);
}
