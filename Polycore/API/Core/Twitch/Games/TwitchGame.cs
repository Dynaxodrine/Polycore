using System;
using System.Collections.Generic;

namespace Polycore.API.Core.Twitch.Games
{
    public class TwitchGame
    {
        public int TwitchId { get; set; }
        public string Title { get; set; }
        public int GiantbombId { get; set; }
        public int Popularity { get; set; }
        public TwitchAPIArt BoxArt { get; set; }
        public TwitchAPIArt Logo { get; set; }

        public TwitchGame(int twitchId, string title, int giantbombId, int popularity, TwitchAPIArt boxArt, TwitchAPIArt logo)
        {
            TwitchId = twitchId;
            Title = title;
            GiantbombId = giantbombId;
            Popularity = popularity;
            BoxArt = boxArt;
            Logo = logo;
        }
    }
}