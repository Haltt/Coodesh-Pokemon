using Coodesh_Pokemon.Data;
using Coodesh_Pokemon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Coodesh_Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonCapturesController(PokemonMasterContext context) : Controller
    {
        private readonly PokemonMasterContext _context = context;
        private readonly HttpClient _httpClient = new();

        // POST: api/PokemonCaptures/capture
        [HttpPost("capture")]
        public async Task<ActionResult<PokemonCapture>> CapturePokemon(string cpf)
        {
            // Verificar se o mestre Pokémon existe
            var pokemonMaster = await _context.PokemonMasters.FirstOrDefaultAsync(m => m.Cpf == cpf);
            if (pokemonMaster == null)
            {
                return NotFound("Mestre Pokémon não encontrado.");
            }

            // Capturar um Pokémon aleatoriamente da PokéAPI
            var random = new Random();
            int randomPokemonId = random.Next(1, 899); // Limitado a 151 Pokémons para exemplo

            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{randomPokemonId}");
            var pokemonData = JObject.Parse(response);

            var pokemonName = pokemonData["name"].ToString();
            var pokemonSprite = pokemonData["sprites"]["front_default"].ToString();
            var typesArray = pokemonData["types"].Select(t => t["type"]["name"].ToString()).ToArray();
            var pokemonTypes = string.Join(", ", typesArray);

            // Criar a captura
            var pokemonCapture = new PokemonCapture
            {
                PokemonName = pokemonName,
                PokemonId = randomPokemonId,
                PokemonSprite = pokemonSprite,
                PokemonTypes = pokemonTypes,
                PokemonMasterId = pokemonMaster.Id
            };

            _context.PokemonCaptures.Add(pokemonCapture);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CapturePokemon), new { id = pokemonCapture.Id }, pokemonCapture);
        }

        [HttpGet("by-master/{cpf}")]
        public async Task<ActionResult<IEnumerable<PokemonCapture>>> GetCapturesByMaster(string cpf)
        {
            // Verificar se o mestre Pokémon existe
            var pokemonMaster = await _context.PokemonMasters.FirstOrDefaultAsync(m => m.Cpf == cpf);
            if (pokemonMaster == null)
            {
                return NotFound("Mestre Pokémon não encontrado.");
            }

            // Buscar todas as capturas feitas por este mestre
            var captures = await _context.PokemonCaptures
                                         .Where(c => c.PokemonMasterId == pokemonMaster.Id)
                                         .OrderBy(c => c.PokemonId)
                                         .ToListAsync();

            return Ok(captures);
        }

        [HttpDelete("by-master/{cpf}")]
        public async Task<IActionResult> DeleteCapturesByMaster(string cpf)
        {
            // Verificar se o mestre Pokémon existe
            var pokemonMaster = await _context.PokemonMasters.FirstOrDefaultAsync(m => m.Cpf == cpf);
            if (pokemonMaster == null)
            {
                return NotFound("Mestre Pokémon não encontrado.");
            }

            // Buscar todas as capturas feitas por este mestre
            var captures = await _context.PokemonCaptures
                                         .Where(c => c.PokemonMasterId == pokemonMaster.Id)
                                         .ToListAsync();

            if (!captures.Any())
            {
                return NotFound("Nenhum Pokémon capturado foi encontrado para esse mestre.");
            }

            // Remover todas as capturas
            _context.PokemonCaptures.RemoveRange(captures);
            await _context.SaveChangesAsync();

            return Ok($"Todas as capturas do mestre Pokémon com CPF {cpf} foram deletadas.");
        }
    }
}
