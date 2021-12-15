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
            _context.SaveChanges();
        }

        public async Task AddAsync(FavoritePost post)
        {
            await _context.FavoritePosts.AddAsync(post);
            await _context.SaveChangesAsync();
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
            _context.SaveChanges();
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
            _context.SaveChanges();
        }

        public FavoritePost GetById(long id)
        {
            return _context.FavoritePosts.Find(id);
        }

        public async Task<FavoritePost> GetByIdAsync(long id)
        {
            return await _context.FavoritePosts.FindAsync(id);
        }

        public bool ContainPost(long postId, AppUser appUser)
        {
            return _context.FavoritePosts.Any(p => p.Post.Id == postId && p.User == appUser);
        }

        public bool ContainPost(Post post, AppUser appUser)
        {
            return _context.FavoritePosts.Any(p => p.Post == post && p.User == appUser);
        }

        public FavoritePost GetByPost(long postId, AppUser appUser)
        {
            return _context.FavoritePosts.FirstOrDefault(f => f.Post.Id == postId && f.User == appUser);
        }
        public FavoritePost GetByPost(Post post, AppUser appUser)
        {
            return _context.FavoritePosts.FirstOrDefault(f => f.Post == post && f.User == appUser);
        }

    }
}
