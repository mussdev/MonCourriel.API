using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonCourriel.API.Models
{
    public class CourrierImage
    {
        public Guid Id {get; set;}
        public string? NameImg {get; set;}
        public string? Url {get; set;}
        public Guid CourrierId {get; set;}
        [JsonIgnore]
        public Courrier? Courriers {get; set;}
    }
}