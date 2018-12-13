using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using LastProject403.Models;

namespace LastProject403.Models
{
    [Table("Straws")]
    public class Straws
    {
        [Key]
        public int strawID { get; set; }

        public string strawMaterial { get; set; }

        public decimal strawHeight { get; set; }

        public string strawColor { get; set; }
    }
}