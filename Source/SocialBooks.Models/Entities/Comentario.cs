using System;
using System.Runtime.Serialization;

namespace SocialBooks.Models.Entities
{
    public class Comentario
    {
        public Comentario()
        {
            DtCadastro = DateTime.Now;
        }

        public int Id { get; set; }

        public int LivroId { get; set; }

        [IgnoreDataMember]
        public Livro Livro { get; set; }

        public string Descricao { get; set; }

        public DateTime DtCadastro { get; set; }
        

    }
}
