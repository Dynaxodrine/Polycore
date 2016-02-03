using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games
{
    public class BaseModel
    {
        public string Name { get; set; }
        public List<Game>  Games { get; set; }
    }
}