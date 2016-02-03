using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polycore.Models.Forum;

namespace Polycore.Models.Games
{
    public class BaseModel
    {
        public string Name { get; set; }
        public List<GameSubject>  Games { get; set; }
    }
}