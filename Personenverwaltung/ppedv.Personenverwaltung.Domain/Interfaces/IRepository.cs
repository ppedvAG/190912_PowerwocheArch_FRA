using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Domain.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T item) where T : class;
        void Delete<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        T GetByID<T>(int ID) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        void Save();
    }
}
