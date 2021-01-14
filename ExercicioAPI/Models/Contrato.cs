using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace exercicio.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get {return Id;} private set{ } }

        public DateTime DataContratacao { get; private set; }

        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public double QuantidadeParcelas { get; set; }

        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public double ValorFinanciado { get; set; }

        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public double Prestacoes { get; set; }
    }
}