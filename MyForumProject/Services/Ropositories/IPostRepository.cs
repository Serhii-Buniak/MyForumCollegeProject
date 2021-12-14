using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }

        void Add(Post post);
        Task AddAsync(Post post);

        void Delete(Post post);
        void Delete(long id);
        Task DeleteAsync(long id);

        bool Contain(long id);
        bool Contain(Post post);

        void Update(Post post);

        Post GetById(long id);
        Task<Post> GetByIdAsync(long id);
    }

}
