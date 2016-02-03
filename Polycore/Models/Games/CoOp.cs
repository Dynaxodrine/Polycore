using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Polycore.Models.Games
{
    [Table("CoOps")]
    public class CoOp : BaseModel
    {
        [Key]
        public int CoOpID { get; set; }
    }
}