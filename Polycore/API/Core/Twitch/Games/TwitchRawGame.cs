using System;
using System.Collections.Generic;

namespace Polycore.API.Core.Twitch.Games
{
    public class TwitchRawGame
    {
        public int _id { get; set; }
        public string Name { get; set; }
        public int Giantbomb_Id { get; set; }
        public int Popularity { get; set; }
        public TwitchAPIArt Box { get; set; }
        public TwitchAPIArt Logo { get; set; }
        public Dictionary<string, string> _links { get; set; }
    }
}