using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Route
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    // FK : Van
        public int VanId { get; set; }
        public Van Van { get; set; }

    public ICollection<RouteCourier> RouteCouriers { get; set; } = new List<RouteCourier>();
    public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
