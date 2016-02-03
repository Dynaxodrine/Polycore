using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.Twitch.Streams
{
    public class StreamSearchResult
    {
        public List<TwitchRawStream> Streams { get; set; }
        public int _total { get; set; }
        public Dictionary<string, string> _links { get; set; }
    }
}