using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeowDating.Models
{
    using System.Data.Entity;

    public class CatDb : DbContext
    {
        public DbSet<CatProfile> CatProfiles { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<BlogThings> BlogThings { get; set; }
    }
}