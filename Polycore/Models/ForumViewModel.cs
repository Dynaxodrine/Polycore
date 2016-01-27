using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polycore.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Polycore.Models
{
    public class BrowseForumViewModel
    {
        // Get Set the model id's. 
        public int PlatformID { get; set; }
        public int GameID { get; set; }
        public int SubjectID { get; set; }

        // Get Set platform gamename.
        public string PlatformName { get; set; }
        public string GameName { get; set; }

        // Get Set list of platforms.
        public virtual List<PlatformModel> Platforms { get; set; }

        // Get Set list of games.
        public virtual List<GameModel> Games { get; set; }

        // Get Set list og subjects.
        public virtual List<SubjectModel> Subjects { get; set; }
    }

    public class ForumIndexViewModel
    {
        // Get Set the model id's.        
        public int PlatformID { get; set; }
        public int GameID { get; set; }
        public int SubjectID { get; set; }
        public int PostID { get; set; }

        // Get Set names for posts titles.
        public string PlatformName { get; set; }
        public string GameName { get; set; }
        public string SubjectName { get; set; }

        // Get Set the posts content items.
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public int PostLikes { get; set; }
        public int PostDislikes { get; set; }
        public DateTime PostDate { get; set; }
        public string PostUserName { get; set; }
        
        // Get Set games in a list to get the available platforms of that game.
        public virtual List<GameModel> Games { get; set; }
        
        // Get Set list of comments for under the posts.
        public virtual List<CommentModel> Comments { get; set; }

        // Get Set comment content in model.
        [AllowHtml]
        [Required]
        public string CommentContent { get; set; }
    }
}