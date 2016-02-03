using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.Twitch.Streams
{
    public class TwitchRawChannel
    {
        public bool? Mature { get; set; }
        public string Status { get; set; }
        public string Broadcaster_Language { get; set; }
        public string Display_Name { get; set; }
        public string Game { get; set; }
        public string Language { get; set; }
        public int _id { get; set; }
        public string Name { get; set; }
        public string Created_At { get; set; }
        public string Updated_At { get; set; }
        public int? Delay { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public string Video_Banner { get; set; }
        public string Background { get; set; }
        public string Profile_Banner { get; set; }
        public string Profile_Banner_Background_Color { get; set; }
        public bool Partner { get; set; }
        public string Url { get; set; }
        public int Views { get; set; }
        public int Followers { get; set; }
        public Dictionary<string, string> _links { get; set; }
    }
}