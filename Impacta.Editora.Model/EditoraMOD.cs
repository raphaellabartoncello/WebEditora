using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Impacta.Editora.Model
{
    public class EditoraMOD
    {
        public int Id { get; set; }

        [Required]
        public string NomeEditora { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Observacoes { get; set; }



    }
}