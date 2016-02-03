using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.Steam
{
    public class SteamGame
    {
        public int SteamId { get; set; }
        public string Title { get; set; }

        public SteamGame(int steamId, string title)
        {
            SteamId = steamId;
            Title = title;
        }
    }
}