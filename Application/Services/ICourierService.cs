using Application.DTOs.CourierDTOs;
using Domain.Entities;

namespace Application.Services;
public interface ICourierService
{
    Task<IEnumerable<GetCourierDTO>> GetAllCouriersAsync();
    Task<GetCourierDTO?> GetCourierByIdAsync(int id);
    Task AddCourierAsync(CreateCourierDTO courierDto);
    Task UpdateCourierAsync(int id, UpdateCourierDTO courierDTO);
    Task DeleteCourierAsync(int id);
}
