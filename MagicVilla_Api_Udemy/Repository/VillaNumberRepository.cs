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

        // Create method
        public async Task CreateNumberAsync(VillaNumber entity)
        {
            await _context.VillaNumber.AddAsync(entity);
            await SaveNumberAsync();
        }

        // Remove method
        public async Task RemoveNumberAsync(VillaNumber entity)
        {
            _context.VillaNumber.Remove(entity);
            await SaveNumberAsync();
        }

        // Get a single villa number based on a filter
        public async Task<VillaNumber> GetNumberAsync(Expression<Func<VillaNumber, bool>> filter = null, bool tracked = true, string includeProperties = null)
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

            // Optionally include related properties if specified
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        // Get all villa numbers based on a filter
        public async Task<List<VillaNumber>> GetAllNumberAsync(Expression<Func<VillaNumber, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<VillaNumber> query = _context.VillaNumber;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Optionally include related properties if specified
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        // Save changes to the database
        public async Task SaveNumberAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
