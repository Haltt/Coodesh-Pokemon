using Coodesh_Pokemon.Data;
using Coodesh_Pokemon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coodesh_Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonMastersController : Controller
    {
        private readonly PokemonMasterContext _context;

        public PokemonMastersController(PokemonMasterContext context)
        {
            _context = context;
        }

        // GET: api/PokemonMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonMaster>>> GetPokemonMasters()
        {
            return await _context.PokemonMasters.ToListAsync();
        }

        // GET: api/PokemonMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonMaster>> GetPokemonMaster(int id)
        {
            var pokemonMaster = await _context.PokemonMasters.FindAsync(id);

            if (pokemonMaster == null)
            {
                return NotFound();
            }

            return pokemonMaster;
        }

        // POST: api/PokemonMasters
        [HttpPost]
        public async Task<ActionResult<PokemonMaster>> PostPokemonMaster(PokemonMaster pokemonMaster)
        {
            // Verifica se já existe um mestre Pokémon com o mesmo CPF
            var existingMaster = await _context.PokemonMasters
                                               .FirstOrDefaultAsync(m => m.Cpf == pokemonMaster.Cpf);
            if (existingMaster != null)
            {
                // Retorna um erro 400 (Bad Request) informando que o CPF já está em uso
                return BadRequest("Já existe um mestre Pokémon com este CPF.");
            }

            _context.PokemonMasters.Add(pokemonMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokemonMaster), new { id = pokemonMaster.Id }, pokemonMaster);
        }

        // PUT: api/PokemonMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemonMaster(int id, PokemonMaster pokemonMaster)
        {
            if (id != pokemonMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(pokemonMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/PokemonMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemonMaster(int id)
        {
            var pokemonMaster = await _context.PokemonMasters.FindAsync(id);
            if (pokemonMaster == null)
            {
                return NotFound();
            }

            _context.PokemonMasters.Remove(pokemonMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonMasterExists(int id)
        {
            return _context.PokemonMasters.Any(e => e.Id == id);
        }
    }
}
