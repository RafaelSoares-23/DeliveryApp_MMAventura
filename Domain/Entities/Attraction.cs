using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Attraction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<DeliveryAttraction> DeliveryAttractions { get; set; } = new List<DeliveryAttraction>();
}
