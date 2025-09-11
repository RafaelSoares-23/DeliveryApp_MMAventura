using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class DeliveryAttraction
{
    public int DeliveryId { get; set; }
    public Delivery Delivery { get; set; }
    public int AttractionId { get; set; }
    public Attraction Attraction { get; set; }
}
