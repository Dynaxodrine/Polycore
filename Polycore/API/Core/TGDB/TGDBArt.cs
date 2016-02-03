using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.TGDB.Game
{
    public class TGDBArt
    {
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ThumbUrl { get; set; }
        public string Url { get; set; }

        public TGDBArt(int? width, int? height, string thumbUrl, string url)
        {
            Width = width;
            Height = height;
            ThumbUrl = thumbUrl;
            Url = url;
        }
    }
}