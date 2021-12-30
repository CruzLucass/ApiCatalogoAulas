using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoAulas.Models
{
    public class Aula
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres.")]
        public string Nome { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "Módulo inválido!")]
        public int ModuloId { get; set; }
    }
}
