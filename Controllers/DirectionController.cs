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
    public class DirectionController : ControllerBase
    {
        private readonly MonCourrielDbContext _monCourrielDbContext;
        public DirectionController(MonCourrielDbContext monCourrielDbContext){
            _monCourrielDbContext = monCourrielDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDirections()
        {
            var directions = await _monCourrielDbContext.CompagnyDirections.ToListAsync();

            return Ok(directions);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Directions direction)
        {
            direction.Id = Guid.NewGuid();
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _monCourrielDbContext.AddAsync(direction);

            var result = await _monCourrielDbContext.SaveChangesAsync();

            if(result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        // Return all direction and service
        [HttpGet("all")]
        public async Task<ActionResult<Directions>> GetDirectionsAndServices()
        {
            // Récupérer toutes les directions avec les services associés
            var dirServ = await _monCourrielDbContext.CompagnyDirections
                .Select(d => new {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Type = "Direction" // Ajoutez un marqueur pour indiquer que c'est une direction
            })
                .Union(_monCourrielDbContext.ServicesDeps
                    .Select(s => new {
                        Id = s.Id,
                        Code = s.Code,
                        Description = s.Description,
                        Type = "Service" // Ajoutez un marqueur pour indiquer que c'est un service
            }))
            .ToListAsync();

            // Retourner les directions avec les services associés
            return Ok(dirServ);
        }

    }
}