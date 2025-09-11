using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Courier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }

    public ICollection<RouteCourier> RouteCouriers { get; set; } = new List<RouteCourier>();
}
