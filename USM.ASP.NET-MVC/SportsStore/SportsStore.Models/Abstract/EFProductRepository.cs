using SportsStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Models.Abstract
{
    public class EFProductRepository : IProductRepository
    {
        private SportsStoreContext context = new SportsStoreContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
