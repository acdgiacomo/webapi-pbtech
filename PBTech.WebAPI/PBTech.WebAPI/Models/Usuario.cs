using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBTech.WebAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }
    }
}
