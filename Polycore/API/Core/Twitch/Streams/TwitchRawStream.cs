using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.Twitch.Streams
{
    public class TwitchRawStream
    {
        public int _id { get; set; }
        public string Game { get; set; }
        public int Viewers { get; set; }
        public string Created_At { get; set; }
        public int Video_Height { get; set; }
        public double Average_Fps { get; set; }
        public int Delay { get; set; }
        public bool Is_Playlist { get; set; }
        public Dictionary<string, string> _links { get; set; }
        public TwitchAPIArt Preview { get; set; }
        public TwitchRawChannel Channel { get; set; }
    }
}