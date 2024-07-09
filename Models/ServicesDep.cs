using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonCourriel.API.Models
{
    public class ServicesDep
    {
        public Guid Id {get; set;}
        public string? Code {get; set;}
        public string? Description {get; set;}
        public Guid DirectionId { get; set; }
        [JsonIgnore]
        public Directions? Directions { get; set; }
    }
}