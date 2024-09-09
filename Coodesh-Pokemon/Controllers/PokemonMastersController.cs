using Coodesh_Pokemon.Data;
using Coodesh_Pokemon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coodesh_Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonMastersController(PokemonMasterContext context) : Controller
    {
        private readonly PokemonMasterContext _context = context;

        /// <summary>
        /// Busca os Mestres Pokémon cadastrados
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/PokemonMasters
        /// </remarks>
        /// <returns>Retorna a lista dos Mestres</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonMaster>>> GetPokemonMasters()
        {
            return await _context.PokemonMasters.ToListAsync();
        }

        /// <summary>
        /// Busca um Mestre Pokémon através do ID
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/PokemonMasters
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna os dados do Pokémon pesquisado</returns>
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
