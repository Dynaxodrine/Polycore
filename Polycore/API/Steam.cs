using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polycore.API.Core.Steam;

namespace Polycore.API
{
    public class Steam : SteamCore
    {
        public static List<SteamGame> GetGameList()
        {
            GameList list = GetRawGameList();
            return SanitizeGameList(list);
        }
    }
}