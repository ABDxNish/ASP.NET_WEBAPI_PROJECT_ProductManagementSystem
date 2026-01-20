using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Find(int id);
        List<T> GetAll();
        bool Add(T entity);
        bool Update(int id,T entity);
        bool Delete(int id);

    }
}
