using System.ComponentModel.DataAnnotations;

namespace MonCourriel.API.Models
{
    public class Courrier
    {
        public Guid Id { get; set; }
        public string? Expediteur { get; set; }
        public string? MailCourrier { get;set; }
        public string? Adresse { get; set; }
        public string?  Contact { get; set; }
        public string? CodeCourrier { get; set; }
        [Required(ErrorMessage="Veuillez saisir une date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}")]
        public DateTime? DateCourrier { get; set; }
        public string? Obejt { get; set; }
        public string? Note { get; set; }
        public string? Statut { get; set; }
        public ICollection<CourrierImage> CourrierImages {get; set;} = new List<CourrierImage>();

    }
}
