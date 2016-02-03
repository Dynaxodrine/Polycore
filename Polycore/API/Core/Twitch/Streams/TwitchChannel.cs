using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.Twitch.Streams
{
    public class TwitchChannel
    {
        public int Id { get; set; }
        public bool? Mature { get; set; }
        public string Status { get; set; }
        public string BroadcasterLanguage { get; set; }
        public string DisplayName { get; set; }
        public string Game { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public int? Delay { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public string VideoBanner { get; set; }
        public string Background { get; set; }
        public string ProfileBanner { get; set; }
        public string ProfileBannerBackgroundColor { get; set; }
        public bool Partner { get; set; }
        public string Url { get; set; }
        public int Views { get; set; }
        public int Followers { get; set; }

        public TwitchChannel(int id, bool? mature, string status, string broadcasterLanguage, string displayName, string game, string language, string name, string createdAt, string updatedAt, int? delay, string logo, string banner, string videoBanner, string background, string profileBanner, string profileBannerBackgroundColor, bool partner, string url, int views, int followers)
        {
            Id = id;
            Mature = mature;
            Status = status;
            BroadcasterLanguage = broadcasterLanguage;
            DisplayName = displayName;
            Game = game;
            Language = language;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Delay = delay;
            Logo = logo;
            Banner = banner;
            VideoBanner = videoBanner;
            Background = background;
            ProfileBanner = profileBanner;
            ProfileBannerBackgroundColor = profileBannerBackgroundColor;
            Partner = partner;
            Url = url;
            Views = views;
            Followers = followers;
        }
    }
}