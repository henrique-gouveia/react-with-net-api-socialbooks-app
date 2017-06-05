using SocialBooks.Models.Entities;
using System;
using System.Data.Entity.ModelConfiguration;

namespace SocialBooks.Data.Configurations
{
    public class ComentarioConfiguration : EntityTypeConfiguration<Comentario>
    {
        public ComentarioConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Descricao)
                .HasMaxLength(250);

            Property(c => c.DtCadastro)
                .HasColumnName("Data_Cadastro");

            HasRequired(c => c.Livro)
                .WithMany()
                .HasForeignKey(c => c.LivroId);
        }
    }
}
