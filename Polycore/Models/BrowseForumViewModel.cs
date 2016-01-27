using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}