using System;
using System.Collections.Generic;
using System.Text;

namespace PocGraphql.Infra.model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
