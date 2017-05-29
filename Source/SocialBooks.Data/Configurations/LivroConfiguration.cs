using System.Data.Entity.ModelConfiguration;
using SocialBooks.Models.Entities;

namespace SocialBooks.Data.Configurations
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            HasKey(l => l.Id);

            Property(l => l.Nome)
                .IsRequired();

            Property(l => l.DtCadastro)
                .HasColumnName("Data_Cadastro");

            Property(l => l.DtPublicacao)
                .HasColumnName("Data_Publicacao");

            // 0 -> n, embora o relacionamento correto seja de n -> n, 
            HasRequired(l => l.Autor)
                .WithMany()
                .HasForeignKey(l => l.AutorId);
        }
    }
}
