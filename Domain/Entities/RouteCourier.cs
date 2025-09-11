using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class RouteCourier
{
    public int RouteId { get; set; }
    public Route Route { get; set; }
    public int CourierId { get; set; }
    public Courier Courier { get; set; }
}
