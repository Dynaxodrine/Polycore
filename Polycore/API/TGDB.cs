using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Polycore.API.Core.TGDB;
using Polycore.API.Core.TGDB.Platform;
using Polycore.API.Core.TGDB.PlatformGames;
using Polycore.API.Core.TGDB.Platforms;

namespace Polycore.API
{
    public class TGDB : TGDBCore
    {
        public static TGDBGame GetGame(int id)
        {
            XDocument document = GetRawGame(id);
            return SanitizeGame(document);
        }

        public static TGDBPlatform GetPlatform(int id)
        {
            XDocument document = GetRawPlatform(id);
            return SanitizePlatform(document);
        }

        public static List<PlatformSummary> GetPlatformList()
        {
            XDocument document = GetRawPlatformList();
            return SanitizePlatformList(document);
        }

        public static List<GameSummary> GetPlatformGamesList(int id)
        {
            XDocument document = GetRawPlatformGamesList(id);
            return SanitizePlatformGamesList(document);
        }
    }
}