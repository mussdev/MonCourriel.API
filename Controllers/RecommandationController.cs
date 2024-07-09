using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonCourriel.API.Data;
using MonCourriel.API.Models;

namespace MonCourriel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class RecommandationController : ControllerBase
    {
        private readonly MonCourrielDbContext _monCourrielDbContext;
        public RecommandationController(MonCourrielDbContext monCourrielDbContext){
            _monCourrielDbContext = monCourrielDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecommandation()
        {
            var directions = await _monCourrielDbContext.recommandations.ToListAsync();

            return Ok(directions);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recommandation recommandation)
        {
            recommandation.Id = Guid.NewGuid();
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _monCourrielDbContext.AddAsync(recommandation);

            var result = await _monCourrielDbContext.SaveChangesAsync();

            if(result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}