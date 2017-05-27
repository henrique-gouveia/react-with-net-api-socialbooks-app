using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using SocialBooks.Models.Entities;
using SocialBooks.Data.Configurations;

namespace SocialBooks.Data.Context
{
    public class SocialBooksContext : DbContext
    {
        public SocialBooksContext() : base("socialbooks")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Não pluralizar nome das tabelas
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
            // Não excluir em cascata 1 - n
            modelBuilder
                .Conventions
                .Remove<OneToManyCascadeDeleteConvention>();
            // Não excluir em cascata n - n
            modelBuilder
                .Conventions
                .Remove<ManyToManyCascadeDeleteConvention>();

            // muda o default de nvarchar para varchar(100)
            modelBuilder
                .Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder
                .Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AutorConfiguration());
            modelBuilder.Configurations.Add(new LivroConfiguration());
        }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Livro> Produtos { get; set; }
    }
}
