using System.Data.Entity;

namespace SocialBooks.Data.Context
{
    class SocialBooksContext : DbContext
    {
        public SocialBooksContext() : base("socialbooks")
        {

        }
    }
}
