using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Repository
{
    /// <summary>
    /// IRepository interface represents the read and 
    /// write implementation of the Repository pattern 
    /// </summary>
    /// <typeparam name="E">for generic parameter</typeparam>
    /// <typeparam name="I">for generic parameter</typeparam>
    public interface IRepository<E , I>
    {
        Task<E> Add(E entity);
        Task<E> GetByEmail(I email);

        Task<List<E>> GetAll();

        Task Remove(I id);

        Task Update(E entity);
        Task Save();
    }
}
