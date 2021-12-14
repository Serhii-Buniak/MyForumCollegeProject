using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public interface ICommentRateRepository 
    {
        IQueryable<CommentRate> Rates { get; }

        void Add(CommentRate rate);
        Task AddAsync(CommentRate rate);

        void Delete(CommentRate rate);
        void Delete(long id);
        Task DeleteAsync(long id);

        bool Contain(long id);
        bool Contain(CommentRate rate);

        void Update(CommentRate rate);

        CommentRate GetById(long id);
        Task<CommentRate> GetByIdAsync(long id);
    }
}
