using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }

        void Add(Comment comment);
        Task AddAsync(Comment comment);

        void Delete(Comment comment);
        void Delete(long id);
        Task DeleteAsync(long id);

        bool Contain(long id);
        bool Contain(Comment comment);

        void Update(Comment comment);

        Comment GetById(long id);
        Task<Comment> GetByIdAsync(long id);
    }
}
