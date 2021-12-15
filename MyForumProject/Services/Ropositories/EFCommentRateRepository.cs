using MyForumProject.Data;
using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public class EFCommentRateRepository : ICommentRateRepository 
    {
        private readonly ApplicationDbContext _context;

        public EFCommentRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<CommentRate> Rates => _context.CommentRates;

        public void Add(CommentRate rate)
        {
            _context.CommentRates.Add(rate);
            _context.SaveChanges();
        }

        public async Task AddAsync(CommentRate rate)
        {
            await _context.CommentRates.AddAsync(rate);
            await _context.SaveChangesAsync();
        }

        public bool Contain(long id)
        {
            return _context.CommentRates.Any(p => p.Id == id);
        }

        public bool Contain(CommentRate rate)
        {
            return _context.CommentRates.Contains(rate);
        }

        public void Delete(CommentRate rate)
        {
            _context.CommentRates.Remove(rate);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            CommentRate rate = GetById(id);
            Delete(rate);
        }
        public async Task DeleteAsync(long id)
        {
            CommentRate rate = await GetByIdAsync(id);
            Delete(rate);
        }

        public void Update(CommentRate rate)
        {
            _context.CommentRates.Update(rate);
            _context.SaveChanges();
        }

        public CommentRate GetById(long id)
        {
            return _context.CommentRates.Find(id);
        }

        public async Task<CommentRate> GetByIdAsync(long id)
        {
            return await _context.CommentRates.FindAsync(id);
        }
    }
}
