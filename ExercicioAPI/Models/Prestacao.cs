using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace exercicio.Models
{
    public class Prestacao
    {
        [Key]
        public int Id { get {return Id;} private set{ } }

        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public DateTime DataVencimento { get; private set; }

        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public DateTime DataPagamento { get; private set; }

        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public double Valor { get; set; }
        
        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Este campo e obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Contrato invalida")]
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
    }
}