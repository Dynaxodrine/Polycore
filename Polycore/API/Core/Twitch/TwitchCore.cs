using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polycore.API.Core.Twitch.Games;
using Polycore.API.Core.Twitch.Streams;

namespace Polycore.API.Core.Twitch
{
    public class TwitchCore : CoreBase
    {
        private const string BASE_URL = "https://api.twitch.tv/kraken/";
        protected static GameSearchResult GetRawSearchResult(string query)
        {
            try
            {
                return
                    RequestJson<GameSearchResult>(BASE_URL + "search/games?type=suggest&query=" + query);
            }
            catch
            {
                return null;
            }
        }

        protected static List<TwitchGame> SanitizeSearchResult(GameSearchResult searchResult)
        {
            List<TwitchGame> result = new List<TwitchGame>();
            if (searchResult?.Games != null)
                result.AddRange(
                    searchResult.Games.Select(
                        p => new TwitchGame(p._id, p.Name.Trim(), p.Giantbomb_Id, p.Popularity, p.Box, p.Logo)));
            return result;
        }

        protected static StreamSearchResult GetRawStreamSearchResult(string game, int limit = 25, int offset = 0,
            string channel = null, string clientId = null, StreamType streamType = StreamType.All)
        {
            string url = BASE_URL + "streams";
            url += "?game=" + game.Trim();
            url += "&limit=" + limit;
            url += "&offset=" + offset;
            url += "&stream_type=" +
                   (streamType == StreamType.Live ? "live" : streamType == StreamType.Playlist ? "playlist" : "all");

            if (!string.IsNullOrWhiteSpace(channel))
                url += "&channel=" + channel.Trim();

            if (!string.IsNullOrWhiteSpace(clientId))
                url += "&client_id=" + clientId.Trim();

            try
            {
                return RequestJson<StreamSearchResult>(url);
            }
            catch
            {
                return null;
            }
        }

        protected static List<TwitchStream> SanitizeStreamSearchResult(StreamSearchResult searchResult)
        {
            List<TwitchStream> result = new List<TwitchStream>();
            if (searchResult?.Streams != null)
            {
                foreach (var stream in searchResult.Streams)
                {
                    TwitchChannel channel = null;
                    if (stream.Channel != null)
                        channel = new TwitchChannel(stream.Channel._id, stream.Channel.Mature, stream.Channel.Status,
                            stream.Channel.Broadcaster_Language, stream.Channel.Display_Name, stream.Channel.Game,
                            stream.Channel.Language, stream.Channel.Name, stream.Channel.Created_At,
                            stream.Channel.Updated_At,
                            stream.Channel.Delay, stream.Channel.Logo, stream.Channel.Banner,
                            stream.Channel.Video_Banner,
                            stream.Channel.Background, stream.Channel.Profile_Banner,
                            stream.Channel.Profile_Banner_Background_Color, stream.Channel.Partner, stream.Channel.Url,
                            stream.Channel.Views, stream.Channel.Followers);

                    TwitchStream str = new TwitchStream(stream._id, stream.Game, stream.Viewers, stream.Created_At,
                        stream.Video_Height, stream.Average_Fps, stream.Delay, stream.Is_Playlist, stream.Preview,
                        channel);

                    result.Add(str);
                }
            }

            return result;
        }
    }
}