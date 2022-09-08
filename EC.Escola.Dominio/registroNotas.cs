using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Escola.Dominio
{
    public class registroNotas
    {
        public int id { get; set; }
        [Display(Name = "Aluno")]
        public virtual aluno aluno { get; set; }
        [Display(Name = "Aluno")]
        public int idAluno { get; set; }
        [Display(Name = "Disciplina")]
        public virtual disciplina disciplina { get; set; }
        [Display(Name = "Disciplina")]
        public int idDisciplina { get; set; }
        [Display(Name = "Situação")]
        public string situacao { 
            get { 
                if(media >= 7)
                {
                    return "APROVADO";
                }
                else
                {
                    return "REPROVADO";
                }
            } 
        }
        [Display(Name = "1º Trimestres")]
        public decimal nota1 { get; set; }
        [Display(Name = "2º Trimestres")]
        public decimal nota2 { get; set; }
        [Display(Name = "3º Trimestres")]
        public decimal nota3 { get; set; }
        [Display(Name = "4º Trimestres")]
        public decimal nota4 { get; set; }
        [Display(Name = "Media Final")]
        public decimal media { get; set; }
    }
}
