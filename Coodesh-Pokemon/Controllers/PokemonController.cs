using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Coodesh_Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController(HttpClient httpClient) : Controller
    {

        private readonly HttpClient _httpClient = httpClient;

        /// <summary>
        /// Método GET que busca dados do Pokémon da PokeAPI pelo ID (Número do Pokémon)
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Pokemon
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna os dados do Pokémon pesquisado</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemon(int id)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{id}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonDoc = JsonDocument.Parse(content);

                    var pokemonData = new
                    {
                        id = jsonDoc.RootElement.GetProperty("id").GetInt32(),
                        name = jsonDoc.RootElement.GetProperty("name").GetString(),
                        sprite = jsonDoc.RootElement.GetProperty("sprites").GetProperty("front_default").GetString(),
                        types = jsonDoc.RootElement.GetProperty("types").EnumerateArray().Select(t => t.GetProperty("type").GetProperty("name").GetString()).ToList()
                    };

                    return Ok(pokemonData);
                }
                return StatusCode((int)response.StatusCode);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(500, $"Erro ao conectar à API: {e.Message}");
            }
        }

        /// <summary>
        /// Método GET que busca 10 Pokémons de forma aleatória da PokeAPI
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Pokemon/random
        /// </remarks>
        /// <returns>Retorna os dados de 10 Pokémons de forma aleatória</returns>
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomPokemons()
        {
            var random = new Random();
            var randomIds = new int[12];

            for (int i = 0; i < 12; i++)
            {
                randomIds[i] = random.Next(1, 899);
            }

            var pokemons = new List<object>();

            try
            {
                foreach (var id in randomIds)
                {
                    var url = $"https://pokeapi.co/api/v2/pokemon/{id}";
                    var response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        var jsonDoc = JsonDocument.Parse(content);
                        var pokemonData = new
                        {
                            id = jsonDoc.RootElement.GetProperty("id").GetInt32(),
                            name = jsonDoc.RootElement.GetProperty("name").GetString(),
                            sprite = jsonDoc.RootElement.GetProperty("sprites").GetProperty("front_default").GetString(),
                            types = jsonDoc.RootElement.GetProperty("types").EnumerateArray().Select(t => t.GetProperty("type").GetProperty("name").GetString()).ToList()
                        };

                        pokemons.Add(pokemonData);
                    }
                }
                return Ok(pokemons);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(500, $"Erro ao conectar à API: {e.Message}");
            }
        }
    }
}
