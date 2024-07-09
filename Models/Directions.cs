using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonCourriel.API.Models
{
    public class Directions
    {
        public Guid Id {get; set;}
        public string? Code {get; set;}
        public string? Description {get; set;}
        public ICollection<ServicesDep> ServicesDeps { get; } = new List<ServicesDep>();
    }
}