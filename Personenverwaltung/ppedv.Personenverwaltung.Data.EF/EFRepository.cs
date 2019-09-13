using ppedv.Personenverwaltung.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Data.EF
{
    public class EFRepository : IRepository
    {
        public EFRepository(EFContext context)
        {
            this.context = context;
        }
        private readonly EFContext context;

        public void Add<T>(T item) where T : class
        {
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : class
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return context.Set<T>().ToList();
        }

        public T GetByID<T>(int ID) where T : class
        {
            return context.Set<T>().Find(ID);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T item) where T : class
        {
            // wackelige implementierung ohne ID...
            context.Entry(item).CurrentValues.SetValues(item);
            Save();
        }
    }
}
