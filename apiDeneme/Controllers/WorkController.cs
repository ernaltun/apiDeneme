using apiDeneme.Models;
using apiDeneme.Models.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace apiDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly DbContextErnet _dbContext;

        public WorkController(DbContextErnet dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Works>>> GetWorks()
        {
            if(_dbContext.Works == null)
            {
                return NotFound();
            }
            return await _dbContext.Works.ToListAsync();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Works>> GetWorks(int Id)
        {
            if (_dbContext.Works == null)
            {
                return NotFound();
            }

            var work = await _dbContext.Works.FindAsync(Id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        [HttpPost]
        
        public async Task<ActionResult<Works>> EkleWorks(Works works)
        {
            _dbContext.Works.Add(works);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(EkleWorks), new { Id = works.Id },works);
        }

        [HttpPut]

        public async Task<IActionResult> GuncelleWorks(int Id,Works works)
        {
            if(Id != works.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(works).State= EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!WorksAvailable(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }                
            }
            return Ok();
        }
        private bool WorksAvailable(int Id)
        {
            return (_dbContext.Works?.Any(x=>x.Id == Id)).GetValueOrDefault();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> SilWorks(int Id)
        {
            if(_dbContext.Works == null)
            {
                return NotFound();
            }

            var works = await _dbContext.Works.FindAsync(Id);
            if(works == null)
            {
                return NotFound();
            }
            _dbContext.Remove(works);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }

}
