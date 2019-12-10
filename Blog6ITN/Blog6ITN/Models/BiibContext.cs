using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog6ITN.Models
{
    public class BiibContext : DbContext
    {
        public BiibContext() : base("Blog6ITN")
        {

        }

        public DbSet<Nieuws> Nieuws { get; set; }
        public DbSet<Gip> Gips { get; set; }
    }
}