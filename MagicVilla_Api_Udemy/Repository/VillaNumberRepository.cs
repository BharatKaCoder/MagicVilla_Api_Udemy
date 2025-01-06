using System.Linq;
using System.Linq.Expressions;
using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_Api_Udemy.Repository
{
    public class VillaNumberRepository : IVillaNumberRepository
    {
        private readonly ApplicationDbContext _context;

        public VillaNumberRepository(ApplicationDbContext db)
        {
            _context = db;
        }

        // create method
        public async Task CreateNumberAsync(VillaNumber entity)
        {
            await _context.VillaNumber.AddAsync(entity);
            await SaveNumberAsync();
        }

        // remove method
        public async Task RemoveNumberAsync(VillaNumber entity)
        {
            _context.VillaNumber.Remove(entity);
            await SaveNumberAsync();
        }
        public async Task<VillaNumber> GetNumberAsync(Expression<Func<VillaNumber, bool>> filter = null, bool tracked = true)
        {
            IQueryable<VillaNumber> query = _context.VillaNumber;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<VillaNumber>> GetAllNumberAsync(Expression<Func<VillaNumber, bool>> filter = null)
        {
            IQueryable<VillaNumber> query = _context.VillaNumber;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task SaveNumberAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
