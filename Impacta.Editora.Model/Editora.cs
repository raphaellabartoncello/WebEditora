using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Impacta.Editora.Model
{
    public class Editora
    {
        public int Id { get; set; }

        [Required]
        public int Nome { get; set; }

        public int Telefone { get; set; }

        public int Email { get; set; }

        public int Observacoes { get; set; }



    }
}