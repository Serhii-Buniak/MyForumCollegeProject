using MyForumProject.Data;
using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public class EFFavoritePostRepository : IFavoritePostRepository 
    {
        private readonly ApplicationDbContext _context;

        public EFFavoritePostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<FavoritePost> FavoritePosts => _context.FavoritePosts;

        public void Add(FavoritePost post)
        {
            _context.FavoritePosts.Add(post);
        }

        public async Task AddAsync(FavoritePost post)
        {
            await _context.FavoritePosts.AddAsync(post);
        }

        public bool Contain(long id)
        {
            return _context.FavoritePosts.Any(p => p.Id == id);
        }

        public bool Contain(FavoritePost post)
        {
            return _context.FavoritePosts.Contains(post);
        }

        public void Delete(FavoritePost post)
        {
            _context.FavoritePosts.Remove(post);
        }

        public void Delete(long id)
        {
            FavoritePost post = GetById(id);
            Delete(post);
        }
        public async Task DeleteAsync(long id)
        {
            FavoritePost post = await GetByIdAsync(id);
            Delete(post);
        }

        public void Update(FavoritePost post)
        {
            _context.FavoritePosts.Update(post);
        }

        public FavoritePost GetById(long id)
        {
            return _context.FavoritePosts.Find(id);
        }

        public async Task<FavoritePost> GetByIdAsync(long id)
        {
            return await _context.FavoritePosts.FindAsync(id);
        }
    }
}
