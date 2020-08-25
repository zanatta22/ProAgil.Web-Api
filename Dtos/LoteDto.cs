using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.WebApi.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        [Range(5, 120000)]
        public int Quantidade { get; set; }

    }
}
