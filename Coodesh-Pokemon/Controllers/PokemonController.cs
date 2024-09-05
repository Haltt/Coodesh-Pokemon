using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Coodesh_Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController(HttpClient httpClient) : Controller
    {

        private readonly HttpClient _httpClient = httpClient;

        // Método GET que busca dados do Pokémon da PokeAPI pelo ID (Número do Pokémon)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemon(int id)
        {
            // URL da PokeAPI com o ID do Pokémon
            var url = $"https://pokeapi.co/api/v2/pokemon/{id}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonDoc = JsonDocument.Parse(content);

                    // Extrair os campos necessários
                    var pokemonData = new
                    {
                        id = jsonDoc.RootElement.GetProperty("id").GetInt32(),
                        name = jsonDoc.RootElement.GetProperty("name").GetString(),
                        sprite = jsonDoc.RootElement.GetProperty("sprites").GetProperty("back_default").GetString(),
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

        // Método GET que busca 10 Pokémons de forma aleatória da PokeAPI
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomPokemons()
        {
            var random = new Random();
            var randomIds = new int[10];

            // Gerar 3 IDs aleatórios entre 1 e 898 (número de Pokémons atualmente na PokeAPI)
            for (int i = 0; i < 10; i++)
            {
                randomIds[i] = random.Next(1, 899); // IDs válidos de Pokémon
            }

            var pokemons = new List<object>();

            try
            {
                // Para cada ID gerado, buscar o Pokémon correspondente
                foreach (var id in randomIds)
                {
                    var url = $"https://pokeapi.co/api/v2/pokemon/{id}";

                    // Fazer a requisição GET para a PokeAPI
                    var response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        // Deserializar apenas os campos "id" e "name"
                        var jsonDoc = JsonDocument.Parse(content);
                        var pokemonData = new
                        {
                            id = jsonDoc.RootElement.GetProperty("id").GetInt32(),
                            name = jsonDoc.RootElement.GetProperty("name").GetString(),
                            sprite = jsonDoc.RootElement.GetProperty("sprites").GetProperty("back_default").GetString(),
                            types = jsonDoc.RootElement.GetProperty("types").EnumerateArray().Select(t => t.GetProperty("type").GetProperty("name").GetString()).ToList()
                        };

                        // Adicionar o Pokémon à lista de resultados
                        pokemons.Add(pokemonData);
                    }
                }

                // Retornar a lista de 3 Pokémons aleatórios
                return Ok(pokemons);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(500, $"Erro ao conectar à API: {e.Message}");
            }
        }
    }
}
