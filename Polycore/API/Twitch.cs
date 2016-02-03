using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polycore.API.Core.Twitch;
using Polycore.API.Core.Twitch.Games;
using Polycore.API.Core.Twitch.Streams;

namespace Polycore.API
{
    public class Twitch : TwitchCore
    {
        public static List<TwitchGame> SearchGames(string query)
        {
            GameSearchResult searchResult = GetRawSearchResult(query);
            return SanitizeSearchResult(searchResult);
        }

        public static List<TwitchStream> SearchStreams(string game, int limit = 25, int offset = 0,
            string channel = null, string clientId = null, StreamType streamType = StreamType.All)
        {
            StreamSearchResult searchResult = GetRawStreamSearchResult(game, limit, offset, channel, clientId, streamType);
            return SanitizeStreamSearchResult(searchResult);
        }

        public static List<TwitchStream> SearchLiveStreams(string game, int limit = 25, int offset = 0,
            string channel = null, string clientId = null)
        {
            return SearchStreams(game, limit, offset, channel, clientId, StreamType.Live);
        }

        public static List<TwitchStream> SearchPlaylistStreams(string game, int limit = 25, int offset = 0,
            string channel = null, string clientId = null)
        {
            return SearchStreams(game, limit, offset, channel, clientId, StreamType.Playlist);
        }
    }
}