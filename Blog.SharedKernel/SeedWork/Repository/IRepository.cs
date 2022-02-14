using System.Collections.Generic;
using System.Threading.Tasks;

namespace TgaCase.SharedKernel.SeedWork.Repository
{
    public interface IRepository<TEntity, TId> 
        where TEntity : class where TId : struct
    {
        Task<TId> InsertAsync(TEntity input);
        Task<bool> UpdateAsync(TEntity input);
        Task<bool> DeleteAsync(long Id);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);        
    }
}