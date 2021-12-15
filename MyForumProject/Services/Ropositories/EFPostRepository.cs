using MyForumProject.Data;
using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public class EFPostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public EFPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Post> Posts => _context.Posts;

        public void Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public bool Contain(long id)
        {
            return _context.Posts.Any(p => p.Id == id);
        }

        public bool Contain(Post post)
        {
            return _context.Posts.Contains(post);
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            Post post = GetById(id);
            Delete(post);
        }
        public async Task DeleteAsync(long id)
        {
            Post post = await GetByIdAsync(id);
            Delete(post);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public Post GetById(long id)
        {
            return _context.Posts.Find(id);
        }

        public async Task<Post> GetByIdAsync(long id)
        {
            return await _context.Posts.FindAsync(id);
        }
    }
}
