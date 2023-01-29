using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebEscuelaMVC.Validators;

namespace WebEscuelaMVC.Models
{
    public class Aula
    {
        public int Id { get; set; }

        [Required]
        [CheckValidNumeroAtributte]
        public int Numero { get; set; }

        [Required(ErrorMessage = "El Campo es obligatorio")]
        [Column(TypeName ="varchar(50)")]
        [StringLength(50)]
        public string Estado { get; set; }
    }
}
