using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MyForumProject.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<CommentNotification> Notifications { get; set; }
        public virtual ICollection<FavoritePost> FavoritePosts { get; set; }

    }


 
}
