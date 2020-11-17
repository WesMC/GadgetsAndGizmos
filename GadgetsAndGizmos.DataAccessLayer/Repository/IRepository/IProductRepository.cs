using GadgetsAndGizmos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
