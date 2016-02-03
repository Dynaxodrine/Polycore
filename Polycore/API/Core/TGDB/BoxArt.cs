using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.TGDB.Game
{
    public class BoxArt : TGDBArt
    {
        public BoxArtSide Side { get; set; }

        public BoxArt(int? width, int? height, string thumbUrl, string url, BoxArtSide side) 
            : base(width, height, thumbUrl, url)
        {
            Side = side;
        }
    }
}