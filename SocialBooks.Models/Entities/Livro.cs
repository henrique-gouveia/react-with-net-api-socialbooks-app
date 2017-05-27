using System;

namespace SocialBooks.Models.Entities
{
    public class Livro
    {
        public int Id { get; set; }

        public int AutorId { get; set; }

        // Necessário ser virtual para o mecanismo de Lazy do 
        // EntityFramework poder sobrescrever
        public virtual Autor Autor { get; set; }

        public string Nome { get; set; }

        public DateTime DtCadastro { get; set; }

        public DateTime DtPublicacao { get; set; }
    }
}
