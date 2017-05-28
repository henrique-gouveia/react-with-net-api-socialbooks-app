using System;
using Newtonsoft.Json;

namespace SocialBooks.Models.Entities
{
    public class Livro
    {
        public Livro()
        {
            DtCadastro = DateTime.Now;
            DtPublicacao = DateTime.Now;
        }

        public int Id { get; set; }

        public int AutorId { get; set; }

        [JsonIgnore]
        public virtual Autor Autor { get; set; }

        public string Nome { get; set; }

        public DateTime DtCadastro { get; set; }

        public DateTime DtPublicacao { get; set; }
    }
}
