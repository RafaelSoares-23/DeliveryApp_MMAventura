using Application.DTOs.CourierDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace Application.Services.Implementations;
public class CourierService : ICourierService
{
    private readonly ICourierRepository _courierRepository;
    private readonly IMapper _mapper;

    public CourierService(ICourierRepository courierRepository, IMapper mapper)
    {
        _courierRepository = courierRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetCourierDTO>> GetAllCouriersAsync()
    {
        var couriers = await _courierRepository.GetAllAsync();
        if (couriers == null || !couriers.Any())
        {
            throw new KeyNotFoundException("Não foram encontrados estafetas registados");
        }
        var couriersDto = _mapper.Map<IEnumerable<GetCourierDTO>>(couriers);
        return couriersDto;

    }
    public async Task<GetCourierDTO?> GetCourierByIdAsync(int id)
    {
        var courier = await _courierRepository.GetByIdAsync(id);
        if (courier == null) 
        { 
            throw new KeyNotFoundException("Não foram encontrado registos com esse id");
        }
        var courierDto = _mapper.Map<GetCourierDTO>(courier);
        return courierDto;
    }
    public async Task AddCourierAsync(CreateCourierDTO courierDto)
    {
        if (courierDto == null)
        {
            throw new ArgumentNullException(nameof(courierDto), "O estafeta não pode ser nulo");
        }
        var courier = _mapper.Map<Courier>(courierDto);
        await _courierRepository.AddAsync(courier);
    }
    public async Task UpdateCourierAsync(int id, UpdateCourierDTO courierDto)
    {
        var courier = await _courierRepository.GetByIdAsync(id);
        if (courier == null)
        {
            throw new KeyNotFoundException($"Estafeta com id {id} não encontrado.");
        }
        courier.Name = string.IsNullOrEmpty(courierDto.Name) ? courier.Name : courierDto.Name;
        courier.PhoneNumber = string.IsNullOrEmpty(courierDto.PhoneNumber) ? courier.PhoneNumber : courierDto.PhoneNumber;
        courier.IsActive = courierDto.isActive ?? courier.IsActive;

        await _courierRepository.UpdateAsync(courier);
    }
    public async Task DeleteCourierAsync(int id)
    {
        var courier = await _courierRepository.GetByIdAsync(id);
        if (courier == null)
        {
            throw new KeyNotFoundException($"Estafeta com id {id} não encontrado.");
        }
        await _courierRepository.DeleteAsync(id);
    }
}
