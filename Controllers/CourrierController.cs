using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonCourriel.API.Data;
using MonCourriel.API.Models;

namespace MonCourriel.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CourrierController : ControllerBase
    {
        private readonly MonCourrielDbContext _monCourrielDbContext; IWebHostEnvironment _webHostEnvironment;
        public CourrierController(MonCourrielDbContext monCourrielDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _monCourrielDbContext = monCourrielDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourriers()
        {
            var courriers = await _monCourrielDbContext.Courriers.ToListAsync();

            return Ok(courriers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CourrierModel model)
        {
            // Générer un nouveau GUID pour le courrier
               var courrier = new Courrier
                {
                    Id = Guid.NewGuid(),
                    Expediteur = model.Expediteur,
                    MailCourrier = model.MailCourrier,
                    Adresse = model.Adresse,
                    Contact = model.Contact,
                    CodeCourrier = model.CodeCourrier,
                    DateCourrier = model.DateCourrier,
                    Obejt = model.Obejt,
                    Note = model.Note,
                    Statut = model.Statut
                };
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            if(model.Files != null  && model.Files.Count > 0){
                //string folder = "/Images";
                
                foreach(var file in model.Files){
                    string imageUrl = UploadImage(file);
                    CourrierImage courrierImage = new CourrierImage
                    {
                        NameImg = file.FileName,
                        Url = imageUrl,
                        CourrierId = courrier.Id

                    };

                    courrier.CourrierImages.Add(courrierImage);
                }
            }

            await _monCourrielDbContext.AddAsync(courrier);

            var result = await _monCourrielDbContext.SaveChangesAsync();

            if(result > 0)
            {
                return Ok();
            }

            return BadRequest();

        }

       [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Courrier>> GetCourrier(Guid id)
        {
            var courrier = await _monCourrielDbContext.Courriers.FindAsync(id);

            if (courrier is null)
                return NotFound();
            return Ok(courrier);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var courrierFind = await _monCourrielDbContext.Courriers.FindAsync(id);

            if(courrierFind is null)
                return NotFound();
            _monCourrielDbContext.Remove(courrierFind);

            var result = await _monCourrielDbContext.SaveChangesAsync();
            if( result > 0)
                return Ok("Le courrier a été supprimé !");
            
            return BadRequest("Unable to delete livres");
        }

        // Methode de modification d'un courrier
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCourrier([FromRoute] Guid id, Courrier UpdateCourrierRequest)
        {
            var courrier = await _monCourrielDbContext.Courriers.FindAsync(id);

            if (courrier == null)
            {
                return NotFound();
            }

            // Doing the data update
            courrier.Obejt = UpdateCourrierRequest.Obejt;
            courrier.Expediteur = UpdateCourrierRequest.Expediteur;
            courrier.Note = UpdateCourrierRequest.Note;
            courrier.Contact = UpdateCourrierRequest.Contact;
            courrier.Adresse = UpdateCourrierRequest.Adresse;
            courrier.MailCourrier=UpdateCourrierRequest.MailCourrier;
            courrier.DateCourrier=UpdateCourrierRequest.DateCourrier;

            await _monCourrielDbContext.SaveChangesAsync();

            return Ok(courrier);
        }

        private string UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentNullException(nameof(file), "File is null or empty");
            }

            // Chemin absolu vers le dossier dans la racine du projet
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            // Vérifiez si le dossier existe, sinon, créez-le
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Générez un nom de fichier unique pour éviter les collisions
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(folderPath, fileName);

            // Enregistrez le fichier sur le disque
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filePath;
        }



    }
}
