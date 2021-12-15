using MyForumProject.Data;
using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public class EFCommentNotificationRepository : ICommentNotificationRepository 
    {
        private readonly ApplicationDbContext _context;

        public EFCommentNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<CommentNotification> CommentNotifications => _context.Notifications;

        public void Add(CommentNotification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public async Task AddAsync(CommentNotification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public bool Contain(long id)
        {
            return _context.Notifications.Any(p => p.Id == id);
        }

        public bool Contain(CommentNotification notification)
        {
            return _context.Notifications.Contains(notification);
        }

        public void Delete(CommentNotification notification)
        {
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            CommentNotification notification = GetById(id);
            Delete(notification);
        }
        public async Task DeleteAsync(long id)
        {
            CommentNotification notification = await GetByIdAsync(id);
            Delete(notification);
        }

        public void Update(CommentNotification notification)
        {
            _context.Notifications.Update(notification);
            _context.SaveChanges();
        }

        public CommentNotification GetById(long id)
        {
            return _context.Notifications.Find(id);
        }

        public async Task<CommentNotification> GetByIdAsync(long id)
        {
            return await _context.Notifications.FindAsync(id);
        }
    }
}
