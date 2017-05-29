using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;

using SocialBooks.Models.Entities;
using SocialBooks.Data.Configurations;

namespace SocialBooks.Data.Context
{
    public class SocialBooksContext : DbContext
    {

        public SocialBooksContext() : base("socialbooks")
        {

        }

        private static void LoadProviderService()
        {
            /*
                Este é um hack para garantir que Entity Framework SQL Provider 
                seja copiado para o output folder corrigindo o erro "Provider not loaded". 
                Como ele é instalado no GAC, Copiar Local não funciona. 
            */
            var instance = SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* 
                Info: Membros com Lazy Loading devem ser virtual 
                para que o mecanismo de Lazy do EntityFramework 
                possa sobrescrever.

                Exemplos: 
                    1. public virtual Entity Entity { get; set; }
                    2. public virtual IEnumerable<TEntity> Entities { get; set; }
            */

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
