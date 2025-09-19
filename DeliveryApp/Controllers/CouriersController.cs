using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.DTOs.CourierDTOs;
using AutoMapper;


namespace DeliveryApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouriersController : ControllerBase
{
    private readonly ICourierService _courierService;
    private readonly IMapper _mapper;

    // Constructor
    public CouriersController(ICourierService courierService, IMapper mapper)
    {
        _courierService = courierService;
        _mapper = mapper;
    }

    // GET: api/Couriers/GetAllCouriers
    [HttpGet ("GetAllCouriers")]
    public async Task<IActionResult> GetAllCouriers()
    {
        try
        {
            var couriers = await _courierService.GetAllCouriersAsync();
            return Ok(couriers);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    // GET: api/Couriers/GetCourierById/5
    [HttpGet("GetCourierById/{id}")]
    public async Task<IActionResult> GetCourierById(int id)
    {
        try 
        {
            var courier = await _courierService.GetCourierByIdAsync(id);
            return Ok(courier);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    // POST: api/Couriers/AddCourier
    [HttpPost("AddCourier")]
    public async Task<IActionResult> AddCourier([FromBody] CreateCourierDTO courierDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _courierService.AddCourierAsync(courierDto);
        return Ok(new { message = "Estafeta adicionado com sucesso!" });
    }

    // PUT: api/Couriers/UpdateCourier/5
    [HttpPut("UpdateCourier/{id}")]
    public async Task<IActionResult> UpdateCourier(int id, [FromBody] UpdateCourierDTO courierDto)
    {
        try
        {
            await _courierService.UpdateCourierAsync(id, courierDto);
            return Ok(new {message = "Estafeta Atualizado"});
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // DELETE: api/Couriers/DeleteCourier/5
    [HttpDelete("DeleteCourier/{id}")]
    public async Task<IActionResult> DeleteCourier(int id)
    {
        try
        {
            await _courierService.DeleteCourierAsync(id);
            return Ok(new { message = "Estafeta removido" });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
