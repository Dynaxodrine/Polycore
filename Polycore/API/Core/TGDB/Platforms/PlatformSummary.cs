using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polycore.API.Core.TGDB.Platforms
{
    public class PlatformSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        public PlatformSummary(int id, string name, string @alias)
        {
            Id = id;
            Name = name;
            Alias = alias;
        }
    }
}