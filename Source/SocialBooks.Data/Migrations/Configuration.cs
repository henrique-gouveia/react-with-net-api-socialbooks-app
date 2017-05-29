namespace SocialBooks.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Context;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialBooksContext>
    {
        public Configuration()
        {
            // Default False, Habilitado para atualizar a base de dados 
            // a medida que o modelo for evoulindo.
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SocialBooksContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
