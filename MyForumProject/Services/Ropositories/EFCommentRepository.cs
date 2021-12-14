using MyForumProject.Data;
using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public class EFCommentRepository : ICommentRepository 
    {
        private readonly ApplicationDbContext _context;

        public EFCommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Comment> Comments => _context.Comments;

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public bool Contain(long id)
        {
            return _context.Comments.Any(p => p.Id == id);
        }

        public bool Contain(Comment comment)
        {
            return _context.Comments.Contains(comment);
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
        }

        public void Delete(long id)
        {
            Comment comment = GetById(id);
            Delete(comment);
        }
        public async Task DeleteAsync(long id)
        {
            Comment comment = await GetByIdAsync(id);
            Delete(comment);
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }

        public Comment GetById(long id)
        {
            return _context.Comments.Find(id);
        }

        public async Task<Comment> GetByIdAsync(long id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}
