﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games
{
    [Table("Publisher")]
    public class Publisher : BaseModel
    {
        [Key]
        public int PublisherID { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}