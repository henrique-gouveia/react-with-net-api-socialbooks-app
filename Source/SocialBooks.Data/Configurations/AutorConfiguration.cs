using System.Data.Entity.ModelConfiguration;
using SocialBooks.Models.Entities;

namespace SocialBooks.Data.Configurations
{
    public class AutorConfiguration : EntityTypeConfiguration<Autor>
    {
        public AutorConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .IsRequired();

            Property(a => a.DtCadastro)
                .HasColumnName("Data_Cadastro");
        }

    }
}
