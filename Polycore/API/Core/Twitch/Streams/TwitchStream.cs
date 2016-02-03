using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.Twitch.Streams
{
    public class TwitchStream
    {
        public int Id { get; set; }
        public string Game { get; set; }
        public int Viewers { get; set; }
        public string CreatedAt { get; set; }
        public int VideoHeight { get; set; }
        public double AverageFps { get; set; }
        public int Delay { get; set; }
        public bool IsPlaylist { get; set; }
        public TwitchAPIArt Preview { get; set; }
        public TwitchChannel Channel { get; set; }

        public TwitchStream(int id, string game, int viewers, string createdAt, int videoHeight, double averageFps, int delay, bool isPlaylist, TwitchAPIArt preview, TwitchChannel channel)
        {
            Id = id;
            Game = game;
            Viewers = viewers;
            CreatedAt = createdAt;
            VideoHeight = videoHeight;
            AverageFps = averageFps;
            Delay = delay;
            IsPlaylist = isPlaylist;
            Preview = preview;
            Channel = channel;
        }
    }
}