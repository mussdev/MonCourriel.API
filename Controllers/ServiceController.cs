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
    public class ServiceController : ControllerBase
    {
        private readonly MonCourrielDbContext _monCourrielDbContext;
        public ServiceController(MonCourrielDbContext monCourrielDbContext){
            _monCourrielDbContext = monCourrielDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
           /*  var services = await _monCourrielDbContext
                        .ServicesDeps
                        .Include(_ => _.Directions)
                        .ToListAsync();

            return Ok(services); */
            var services = await _monCourrielDbContext.ServicesDeps
                            .Select(service => new {
                                service.Id,
                                service.Code,
                                service.Description,
                                service.DirectionId,
                                Direction = new {
                                    service.Directions.Id,
                                    service.Directions.Code,
                                    service.Directions.Description
                                    // Ajoutez d'autres propriétés de direction si nécessaire
                                }
                            })
                            .ToListAsync();

            return Ok(services);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicesDep servicesDep)
        {
            servicesDep.Id = Guid.NewGuid();
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Récuperer la direction parent
            var directionParent = await _monCourrielDbContext.CompagnyDirections.FirstOrDefaultAsync(d => d.Id==servicesDep.DirectionId);
            if(directionParent == null){
                return BadRequest("Direction inexistante !");
            }

            // Associer le service à la direction
            servicesDep.Directions = directionParent;
            
            await _monCourrielDbContext.AddAsync(servicesDep);

            var result = await _monCourrielDbContext.SaveChangesAsync();

            if(result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}