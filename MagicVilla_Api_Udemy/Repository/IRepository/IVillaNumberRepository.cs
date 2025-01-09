using System.Linq.Expressions;
using MagicVilla_Api_Udemy.Models;

namespace MagicVilla_Api_Udemy.Repository.IRepository
{
    public interface IVillaNumberRepository
    {
        Task<List<VillaNumber>> GetAllNumberAsync(Expression<Func<VillaNumber, bool>> filter = null, string includeProperties = null);
        Task<VillaNumber> GetNumberAsync(Expression<Func<VillaNumber, bool>> filter = null, bool tracked = true, string includeProperties = null);
        Task CreateNumberAsync(VillaNumber entity);

        Task RemoveNumberAsync(VillaNumber entity);
        Task SaveNumberAsync();
    }
}
