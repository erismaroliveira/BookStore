using BookStore.Context;
using BookStore.Domain;
using BookStore.Repositories.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDataContext _db;

        public AuthorRepository(BookStoreDataContext context)
        {
            _db = context;
        }

        public List<Autor> Get()
        {
            return _db.Autores.AsNoTracking().ToList();
        }

        public Autor Get(int id)
        {
            return _db.Autores.Find(id);
        }

        public List<Autor> GetByName(string name)
        {
            return _db.Autores
                .Where(x => x.Nome.Contains(name))
                .ToList();
        }

        public bool Create(Autor autor)
        {
            try
            {
                if (autor != null)
                {
                    _db.Autores.Add(autor);
                    _db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Autor autor)
        {
            try
            {
                if (autor != null)
                {
                    _db.Entry<Autor>(autor).State = EntityState.Modified;
                    _db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            var autor = _db.Autores.Find(id);

            if (autor != null)
            {
                _db.Autores.Remove(autor);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}