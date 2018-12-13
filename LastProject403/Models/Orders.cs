using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using LastProject403.Models;

namespace LastProject403.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int orderID { get; set; }

        public int? strawID { get; set; }
        public virtual Straws Straws { get; set; }

        public int? userID { get; set; }
        public virtual Users Users { get; set; }

        public int quantityOrdered { get; set; }
    }
}