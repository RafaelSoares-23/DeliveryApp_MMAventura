using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CourierDTOs;
public class CreateCourierDTO
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "O numero de telemovel é obrigatório.")]
    public string PhoneNumber { get; set; } = string.Empty;
}
