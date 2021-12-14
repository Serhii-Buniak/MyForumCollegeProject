using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public interface ICommentNotificationRepository 
    {
        IQueryable<CommentNotification> CommentNotifications { get; }

        void Add(CommentNotification notification);
        Task AddAsync(CommentNotification notification);

        void Delete(CommentNotification notification);
        void Delete(long id);
        Task DeleteAsync(long id);

        bool Contain(long id);
        bool Contain(CommentNotification notification);

        void Update(CommentNotification notification);

        CommentNotification GetById(long id);
        Task<CommentNotification> GetByIdAsync(long id);
    }
}
