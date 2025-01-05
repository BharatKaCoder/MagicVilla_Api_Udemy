using System.Linq;
using System.Linq.Expressions;
using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_Api_Udemy.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _context;

        public VillaRepository(ApplicationDbContext Db)
        {
            _context = Db;
        }
        public async Task CreateAsync(VillaModel entity)
        {
            await _context.VillasTable.AddAsync(entity);
            await SaveAsync(entity);
        }

        public async Task<VillaModel> GetAsync(Expression<Func<VillaModel,bool>> filter = null, bool tracked = true)
        {
            IQueryable<VillaModel> query = _context.VillasTable;
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

        public async Task<List<VillaModel>> GetAllAsync(Expression<Func<VillaModel,bool>> filter = null)
        {
            IQueryable<VillaModel> query = _context.VillasTable;
            if (filter != null) 
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task SaveAsync(VillaModel entity)
        {
            await _context.SaveChangesAsync();
        }
    }
}
