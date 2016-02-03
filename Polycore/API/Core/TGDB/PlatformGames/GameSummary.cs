using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.TGDB.PlatformGames
{
    public class GameSummary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }

        public GameSummary(int id, string title, string releaseDate)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
        }
    }
}