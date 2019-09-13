using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Domain.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T item);
        void Delete<T>(T item);
        void Update<T>(T item);
        T GetByID<T>(int ID);
        IEnumerable<T> GetAll<T>();
        void Save();
    }
}
