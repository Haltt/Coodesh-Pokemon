using System.ComponentModel.DataAnnotations;

namespace Coodesh_Pokemon.Models
{
    public class PokemonMaster
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 150, ErrorMessage = "A idade deve ser entre 1 e 150 anos.")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato 000.000.000-00")]
        public string Cpf { get; set; }
    }
}
