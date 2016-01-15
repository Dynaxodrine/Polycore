using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polycore.Models;

namespace Polycore.Models
{
    public class ForumViewModel
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public int PostLikes { get; set; }
        public int PostDislikes { get; set; }
        public DateTime PostDate { get; set; }
        public string PostUserName { get; set; }

        public string CommentContent { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
    }
}