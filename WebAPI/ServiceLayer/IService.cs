using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IService<T>
    {
        Task<bool> AddAsync(T dataDM);
        Task<bool> UpdateAsync(T dataDM);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<bool> DeleteAsync(int id);
    }
}
