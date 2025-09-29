using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
        public ICollection<UserPost>? UserPosts { get; set; }
    }
}
