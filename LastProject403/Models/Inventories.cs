using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using LastProject403.Models;

namespace LastProject403.Models
{
    [Table("Inventories")]
    public class Inventories
    {
        [Key]
        public int inventoryID { get; set; }

        public int? strawID { get; set; }
        public virtual Straws Straws { get; set; }

        public int quantity { get; set; }
    }
}