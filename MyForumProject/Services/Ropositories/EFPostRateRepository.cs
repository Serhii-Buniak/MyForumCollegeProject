using MyForumProject.Data;
using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public class EFPostRateRepository : IPostRateRepository 
    {
        private readonly ApplicationDbContext _context;

        public EFPostRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<PostRate> PostRates => _context.PostRates; 

        public void Add(PostRate rate)
        {
            _context.PostRates.Add(rate);
        }

        public async Task AddAsync(PostRate rate)
        {
            await _context.PostRates.AddAsync(rate);
        }

        public bool Contain(long id)
        {
            return _context.PostRates.Any(p => p.Id == id);
        }

        public bool Contain(PostRate rate)
        {
            return _context.PostRates.Contains(rate);
        }

        public void Delete(PostRate rate)
        {
            _context.PostRates.Remove(rate);
        }

        public void Delete(long id)
        {
            PostRate rate = GetById(id);
            Delete(rate);
        }
        public async Task DeleteAsync(long id)
        {
            PostRate rate = await GetByIdAsync(id);
            Delete(rate);
        }

        public void Update(PostRate rate)
        {
            _context.PostRates.Update(rate);
        }

        public PostRate GetById(long id)
        {
            return _context.PostRates.Find(id);
        }

        public async Task<PostRate> GetByIdAsync(long id)
        {
            return await _context.PostRates.FindAsync(id);
        }
    }

}
