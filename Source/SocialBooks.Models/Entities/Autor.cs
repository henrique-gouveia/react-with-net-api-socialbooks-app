using System;
using System.Collections.Generic;

namespace SocialBooks.Models.Entities
{
    public class Autor
    {
        public Autor()
        {
            DtCadastro = DateTime.Now;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DtCadastro { get; set; }

        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}
