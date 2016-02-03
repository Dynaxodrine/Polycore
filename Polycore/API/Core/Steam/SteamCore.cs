using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.Steam
{
    public class SteamCore : CoreBase
    {
        protected static GameList GetRawGameList()
        {
            try
            {
                return RequestJson<GameList>("http://api.steampowered.com/ISteamApps/GetAppList/v0001/");
            }
            catch
            {
                return null;
            }
        }

        protected static List<SteamGame> SanitizeGameList(GameList list)
        {
            List<SteamGame> result = new List<SteamGame>();
            if(list.AppList?.Apps?.App != null)
                result.AddRange(list.AppList.Apps.App.Select(app => new SteamGame(app.AppId, app.Name.Trim())));
            return result;
        }
    }
}