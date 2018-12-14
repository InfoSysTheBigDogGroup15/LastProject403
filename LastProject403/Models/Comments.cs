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

        public string userName { get; set; }

        public string question { get; set; }

        public string answers { get; set; }
    }
}