using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webTesteAPI.Models
{
    public class tabelaPaciente
    {
        [Key] 
        public string cpf { get; set; }
        public string nomePaciente { get; set; }
        public DateTime dataNascimento { get; set; }
        public string examesRealizados { get; set; }
        public DateTime dataExameRealizado { get; set; }
    }
}