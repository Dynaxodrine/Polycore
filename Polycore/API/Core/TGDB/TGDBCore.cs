using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Polycore.API.Core.TGDB.Game;
using Polycore.API.Core.TGDB.Platform;
using Polycore.API.Core.TGDB.PlatformGames;
using Polycore.API.Core.TGDB.Platforms;
using Polycore.Models.Games;

namespace Polycore.API.Core.TGDB
{
    public class TGDBCore : CoreBase
    {
        private const string BASE_URL = "http://thegamesdb.net/api/";
        private const string GAME_URL = BASE_URL + "GetGame.php?id=";
        private const string PLATFORM_URL = BASE_URL + "GetPlatform.php?id=";
        private const string PLATFORMLIST_URL = BASE_URL + "GetPlatformsList.php";
        private const string PLATFORMGAMESLIST_URL = BASE_URL + "GetPlatformGames.php?platform=";

        protected static XDocument GetRawGame(int id)
        {
            try
            {
                return RequestXml(GAME_URL + id);
            }
            catch
            {
                return null;
            }
        }

        protected static XDocument GetRawPlatform(int id)
        {
            try
            {
                return RequestXml(PLATFORM_URL + id);
            }
            catch
            {
                return null;
            }
        }

        protected static XDocument GetRawPlatformList()
        {
            try
            {
                return RequestXml(PLATFORMLIST_URL);
            }
            catch
            {
                return null;
            }
        }

        protected static XDocument GetRawPlatformGamesList(int id)
        {
            try
            {
                return RequestXml(PLATFORMGAMESLIST_URL + id);
            }
            catch
            {
                return null;
            }
        }

        protected static TGDBGame SanitizeGame(XDocument game)
        {
            TGDBGame result = null;
            if (!game.Elements("Data").Any() || !game.Elements("Data").Elements("Game").Any())
                return result;

            var g = game.Element("Data").Element("Game");

            try
            {
                result = new TGDBGame()
                {
                    Id = int.Parse(g.Element("id")?.Value),
                    Title = g.Element("GameTitle")?.Value,
                    PlatformId = int.Parse(g.Element("PlatformId")?.Value),
                    PlatformName = g.Element("Platform")?.Value,
                    ReleaseDate = g.Element("ReleaseDate")?.Value,
                    Overview = g.Element("Overview")?.Value,
                    ESRB = g.Element("ESRB")?.Value,
                    Genres = g.Elements("Genres").Elements("genre").Select(p => p.Value).ToList(),
                    Players = g.Element("Players")?.Value,
                    CoOp = g.Element("Co-op")?.Value,
                    YoutubeUrl = g.Element("Youtube")?.Value,
                    Publisher = g.Element("Publisher")?.Value,
                    Developer = g.Element("Developer")?.Value,
                    Rating = g.Element("Rating")?.Value,
                    SimilarGames = HandleSimilarGames(g.Elements("Similar")),
                    Fanart = HandleArt(g.Elements("Images"), "fanart"),
                    Boxart = HandleBoxArt(g.Elements("Images")),
                    Screenshots = HandleArt(g.Elements("Images"), "screenshot"),
                    Banner = HandleArt(g.Elements("Images"), "banner", false),
                    Clearlogo = HandleArt(g.Elements("Images"), "clearlogo", false).FirstOrDefault(),
            };
            }
            catch
            {
                // ignored
            }
            return result;
        }

        protected static TGDBPlatform SanitizePlatform(XDocument platform)
        {
            TGDBPlatform result = null;
            if (!platform.Elements("Data").Any() || !platform.Elements("Data").Elements("Platform").Any())
                return result;

            var pf = platform.Element("Data").Element("Platform");

            try
            {
                result = new TGDBPlatform()
                {
                    Id  = int.Parse(pf.Element("id")?.Value),
                    Name = pf.Element("name")?.Value,
                    Overview = pf.Element("overview")?.Value,
                    Developer = pf.Element("developer")?.Value,
                    Manufacturer = pf.Element("manufacturer")?.Value,
                    Cpu = pf.Element("cpu")?.Value,
                    Memory = pf.Element("memory")?.Value,
                    Graphics = pf.Element("graphics")?.Value,
                    Sound = pf.Element("sound")?.Value,
                    Display = pf.Element("display")?.Value,
                    Media = pf.Element("media")?.Value,
                    MaxControllers = pf.Element("maxcontrollers")?.Value,
                    Rating = pf.Element("rating")?.Value,
                    ConsoleArt = pf.Element("Images")?.Element("consoleart")?.Value,
                    ControllerArt = pf.Element("Images")?.Element("controllerart")?.Value,
                    Fanart = HandleArt(pf.Elements("Images"), "fanart"),
                    Boxart = HandleBoxArt(pf.Elements("Images")),
                    Banners = HandleArt(pf.Elements("Images"), "banner", false)
                };
            }
            catch
            {
                // ignored
            }
            

            return result;

        }

        protected static List<PlatformSummary> SanitizePlatformList(XDocument list)
        {
            List<PlatformSummary> result = new List<PlatformSummary>();
            if (!list.Elements("Data").Any() || !list.Elements("Data").Elements("Platforms").Any())
                return result;

            foreach (var pf in list.Elements("Data").Elements("Platforms").Elements("Platform"))
            {
                try
                {
                    result.Add(new PlatformSummary(int.Parse(pf.Element("id")?.Value), pf.Element("name")?.Value, pf.Element("alias")?.Value));
                }
                catch
                {
                    // ignored
                }
            }

            return result;

        }

        protected static List<GameSummary> SanitizePlatformGamesList(XDocument list)
        {
            List<GameSummary> result = new List<GameSummary>();
            if (!list.Elements("Data").Any() || !list.Elements("Data").Elements("Game").Any())
                return result;

            foreach (var pf in list.Elements("Data").Elements("Game"))
            {
                try
                {
                    result.Add(new GameSummary(int.Parse(pf.Element("id")?.Value), pf.Element("GameTitle")?.Value, pf.Element("ReleaseDate")?.Value));
                }
                catch
                {
                    // ignored
                }
            }

            return result;

        }

        protected static List<SimilarGame> HandleSimilarGames(IEnumerable<XElement> similar)
        {
            List<SimilarGame> result = new List<SimilarGame>();
            foreach (var sg in similar.Elements("Game"))
            {
                try
                {
                    result.Add(new SimilarGame(int.Parse(sg.Element("id")?.Value), int.Parse(sg.Element("PlatformId")?.Value)));
                }
                catch
                {
                    // ignored
                }
            }
            return result;
        }

        private static List<TGDBArt> HandleArt(IEnumerable<XElement> images, string key, bool hasThumb = true)
        {
            List<TGDBArt> result = new List<TGDBArt>();
            foreach (var art in images.Elements(key))
            {
                if (!art.Elements("original").Any() && hasThumb)
                    continue;

                var original = hasThumb ? art.Element("original") : art; // Ugly, I know

                string thumb = null;

                if (art.Elements("thumb").Any() && hasThumb)
                    thumb = art.Element("thumb")?.Value;

                int? width = null, height = null;

                if (original.Attributes("width").Any())
                    width = int.Parse(original.Attribute("width")?.Value);

                if (original.Attributes("height").Any())
                    height = int.Parse(original.Attribute("height")?.Value);

                result.Add(new TGDBArt(width, height, thumb, original.Value));
            }
            return result;
        }
        private static List<BoxArt> HandleBoxArt(IEnumerable<XElement> images)
        {
            List<BoxArt> result = new List<BoxArt>();
            foreach (var boxart in images.Elements("boxart"))
            {
                int? width = null, height = null;
                BoxArtSide side = BoxArtSide.Other;

                string thumb = null;

                if (boxart.Attributes("thumb").Any())
                    thumb = boxart.Attribute("thumb")?.Value;

                if (boxart.Attributes("width").Any())
                    width = int.Parse(boxart.Attribute("width")?.Value);

                if (boxart.Attributes("height").Any())
                    height = int.Parse(boxart.Attribute("height")?.Value);

                if (boxart.Attributes("side").Any())
                    side = boxart.Attribute("side")?.Value == "front" ? BoxArtSide.Front
                        : boxart.Attribute("side")?.Value == "back" ? BoxArtSide.Back
                        : BoxArtSide.Other;

                result.Add(new BoxArt(width, height, thumb, boxart.Value, side));
            }
            return result;
        }
    }
}