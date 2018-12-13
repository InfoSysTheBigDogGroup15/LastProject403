using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using LastProject403.Models;

namespace LastProject403.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int userID { get; set; }

        public string userEmail { get; set; }

        public string password { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }
    }
}