using SportsStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class SportsStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
