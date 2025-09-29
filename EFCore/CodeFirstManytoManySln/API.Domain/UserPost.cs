using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain
{
    public class UserPost
    {
        //public int UserPostId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        public bool IsAuthor { get; set; }
    }
}
