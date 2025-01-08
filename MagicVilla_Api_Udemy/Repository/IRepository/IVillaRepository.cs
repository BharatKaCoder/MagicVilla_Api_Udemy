using System.Linq.Expressions;
using MagicVilla_Api_Udemy.Models;

namespace MagicVilla_Api_Udemy.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<VillaModel>> GetAllAsync(Expression<Func<VillaModel,bool>> filter = null);

        Task<VillaModel> GetAsync(Expression<Func<VillaModel,bool>> filter = null, bool tracked=true);
        Task CreateAsync (VillaModel entity);

        Task UpdateAsync(VillaModel entity);

        Task DeleteAsync(VillaModel entity);
        Task SaveAsync (VillaModel entity);
    }
}
