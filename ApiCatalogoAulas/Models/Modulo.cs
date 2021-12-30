using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoAulas.Models
{
    public class Modulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres.")]
        public string Nome { get; set; }
    }
}
