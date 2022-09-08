using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Escola.Dominio
{
    public class aluno
    {
        public int id { get; set; }
        [Display(Name = "CPF")]
        public long cpf { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "CEP")]
        public int cep { get; set; }
        [Display(Name = "Número")]
        public int numero { get; set; }
        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        public virtual List<registroNotas> registroNotas { get; set; }
    }
}
