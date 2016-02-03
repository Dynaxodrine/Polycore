using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.Twitch.Games
{
    public class GameSearchResult
    {
        public Dictionary<string, string> _links { get; set; }
        public List<TwitchRawGame> Games { get; set; }
    }
}