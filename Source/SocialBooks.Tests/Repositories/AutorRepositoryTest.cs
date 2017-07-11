using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using SocialBooks.Models.Interfaces;
using SocialBooks.Models.Entities;
using SocialBooks.Data.Repositories;

namespace SocialBooks.Tests.Repositories
{
    // NUnit 3 Test Adapter

    [TestFixture]
    public class AutorRepositoryTest
    {
        private IRepository<Autor, int> autorRepository;

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            autorRepository = new AutorRepository();
        }

        [Test]
        public void DeveInserirAutor()
        {
            var autor = CreateAutorDefault();
            autorRepository.Insert(autor);

            var autorInserted = autorRepository.Query.FirstOrDefault(a => a.Id == autor.Id);
            Assert.IsNotNull(autorInserted);
            Assert.AreEqual(autor.Nome, autorInserted.Nome);
        }

        [Test]
        public void DeveAtualizarAutor()
        {
            var autor = CreateAutorDefault();
            autorRepository.Insert(autor);

            autor.Nome = "AUTOR UPDATED";
            autorRepository.Update(autor);

            var autorUpdated = autorRepository.Query.FirstOrDefault(a => a.Id == autor.Id);
            Assert.IsNotNull(autorUpdated);
            Assert.AreNotEqual("AUTOR UPDATED", autorUpdated.Nome);
        }

        [Test]
        public void DeveExcluirAutor()
        {
            var autor = CreateAutorDefault();
            autorRepository.Insert(autor);

            var autorInserted = autorRepository.Query.FirstOrDefault(a => a.Id == autor.Id);
            Assert.IsNotNull(autorInserted);

            autorRepository.Delete(autor);

            var autorDeleted = autorRepository.Query.FirstOrDefault(a => a.Id == a.Id);
            Assert.IsNull(autorDeleted);
        }

        private Autor CreateAutorDefault(string nome = "AUTOR")
        {
            return new Autor
            {
                Nome = nome
            };
        }
    }
}
