using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Van
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public bool IsAvailable { get; set; }
    public ICollection<Route> Routes { get; set; } = new List<Route>();
}
