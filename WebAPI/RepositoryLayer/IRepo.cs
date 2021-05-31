using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepo<T>
    {
        Task<bool> Add(T data);
        Task<bool> Update(T data);
        Task<List<T>> GetAll();
        Task<T> GetbyID(long id);
        Task<bool> Delte(int id);
    }
}
