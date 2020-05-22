using GadgetsAndGizmos.DataAccessLayer.Data;
using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductType productType)
        {
            var prodTypeFromDb = _db.ProductTypes.FirstOrDefault(s => s.Id == productType.Id);

            if (prodTypeFromDb != null)
            {
                prodTypeFromDb.SubType = productType.SubType;
                prodTypeFromDb.SubType1 = productType.SubType1;
                prodTypeFromDb.SubType2 = productType.SubType2;
                prodTypeFromDb.SubType3 = productType.SubType3;
            }
        }
    }
}
