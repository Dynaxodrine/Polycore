using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.TGDB.Game
{
    public class SimilarGame
    {
        public int Id { get; set; }
        public int PlatformId { get; set; }

        public SimilarGame(int id, int platformId)
        {
            Id = id;
            PlatformId = platformId;
        }
    }
}