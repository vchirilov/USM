using SportsStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Models.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
