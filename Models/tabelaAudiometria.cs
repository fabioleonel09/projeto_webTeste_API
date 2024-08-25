using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webTesteAPI.Models
{
    public class tabelaAudiometria
    {
        [Key]
        public int id { get; set; }
        public string cpfPaciente { get; set; }
        public DateTime dataExame { get; set; }
        public string nomeExame { get; set; }

        [ForeignKey("cpfPaciente")]
        public tabelaPaciente Paciente { get; set; }
    }
}