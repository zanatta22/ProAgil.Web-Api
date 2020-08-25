using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.WebApi.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength (100, MinimumLength = 3, ErrorMessage = "Local é 3 e 100 caracteres")]
        public string Local { get; set; }

        public string DataEvento { get; set; }

        [Required (ErrorMessage = "Tema é obrigatorio")]
        public string Tema { get; set; }

        [Range(2, 120000, ErrorMessage = "Quantidade de pessoas entre 2 e 120000 ")]
        public int QtdPessoas { get; set; }

        public string ImagemURL { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<LoteDto> Lotes { get; set; }

        public List<RedeSocialDto> RedesSociais { get; set; }

        public List<PalestranteDto> Palestrantes { get; set; }
    }
}
