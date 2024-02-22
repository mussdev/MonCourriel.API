using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonCourriel.API.Data;
using MonCourriel.API.Models;

namespace MonCourriel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourrierController : ControllerBase
    {
        private readonly MonCourrielDbContext _monCourrielDbContext;
        public CourrierController(MonCourrielDbContext monCourrielDbContext)
        {
            _monCourrielDbContext = monCourrielDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourriers()
        {
            var courriers = await _monCourrielDbContext.Courriers.ToListAsync();

            return Ok(courriers);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourrier(Courrier courrier)
        {
            courrier.Id = Guid.NewGuid();
            _monCourrielDbContext.Courriers.Add(courrier);
            await _monCourrielDbContext.SaveChangesAsync();

            return Ok(courrier);
        }


    }
}
