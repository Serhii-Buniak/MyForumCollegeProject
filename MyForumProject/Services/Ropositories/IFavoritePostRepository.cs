using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public interface IFavoritePostRepository 
    {
        IQueryable<FavoritePost> FavoritePosts { get; }

        void Add(FavoritePost post);
        Task AddAsync(FavoritePost post);

        void Delete(FavoritePost post);
        void Delete(long id);
        Task DeleteAsync(long id);

        bool Contain(long id);
        bool Contain(FavoritePost post);

        bool ContainPost(long postId, AppUser appUser);
        bool ContainPost(Post post, AppUser appUser);

        void Update(FavoritePost post);

        FavoritePost GetById(long id);
        Task<FavoritePost> GetByIdAsync(long id);

        FavoritePost GetByPost(long postId, AppUser appUser);
        FavoritePost GetByPost(Post post, AppUser appUser);
    }
}
