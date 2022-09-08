using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Escola.Dominio
{
    public class disciplina
    {
        public int id { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }

        public virtual List<registroNotas> registroNotas { get; set; }
    }
}
