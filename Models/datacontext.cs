using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MAGAZA.Models
{
    public class datacontext : DbContext
    {
        public DbSet<Magaza> MagazamTablom { get; set; }
    }
}