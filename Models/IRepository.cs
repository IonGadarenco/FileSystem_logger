using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem_logger.Models
{
    internal interface IRepository<T> where T : Entity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
