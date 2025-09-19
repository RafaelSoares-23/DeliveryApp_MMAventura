using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CourierRepository : ICourierRepository
{
    private readonly AppDbContext _context;
    public CourierRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Courier?> GetByIdAsync(int id) => 
        await _context.Couriers.FirstOrDefaultAsync(c => c.Id == id);
    public async Task<IEnumerable<Courier>> GetAllAsync() => 
        await _context.Couriers.ToListAsync();
    public async Task AddAsync(Courier courier) 
    {
        _context.Couriers.Add(courier);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Courier courier) 
    {
        _context.Couriers.Update(courier);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id) 
    {
        var courier = await GetByIdAsync(id);
        if (courier != null) 
        {
            _context.Couriers.Remove(courier);
            await _context.SaveChangesAsync();
        }
    }
}
