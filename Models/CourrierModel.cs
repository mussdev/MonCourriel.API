using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonCourriel.API.Models
{
    public class CourrierModel
    {
        public string? Expediteur { get; set; }
        public string? MailCourrier { get; set; }
        public string? Adresse { get; set; }
        public string? Contact { get; set; }
        public string? CodeCourrier { get; set; }
        public DateTime? DateCourrier { get; set; }
        public string? Obejt { get; set; }
        public string? Note { get; set; }
        public string? Statut { get; set; }
        public List<IFormFile>? Files { get; set; }
    }
}