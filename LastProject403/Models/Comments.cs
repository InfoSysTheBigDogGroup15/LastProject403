using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LastProject403.Models
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public int commentID { get; set; }

        public String userName { get; set; }

        public String question { get; set; }

        public String answers { get; set; }
    }
}