﻿using LastProject403.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace LastProject403.DAL
{
    public class StrawContext : DbContext
    {
        public StrawContext() : base("StrawContext")
        {

        }

        public DbSet<Inventories> Inventory { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<Straws> Straw { get; set; }
        public DbSet<Users> User { get; set; }

        public System.Data.Entity.DbSet<LastProject403.Models.Comments> Comments { get; set; }
    }
}