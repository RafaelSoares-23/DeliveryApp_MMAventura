using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Delivery
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string Address { get; set; }
    public DateTime SetupTime { get; set; }
    public DateTime TeardownTime { get; set; }
    public bool IsDelivered { get; set; }

    // FK Rota
    public int RouteId { get; set; }
    public Route Route { get; set; }

    // Delivery has many attractioms
    public ICollection<DeliveryAttraction> DeliveryAttractions { get; set; } = new List<DeliveryAttraction>();
}
