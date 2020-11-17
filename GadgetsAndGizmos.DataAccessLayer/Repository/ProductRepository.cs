using GadgetsAndGizmos.DataAccessLayer.Data;
using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);

            if (objFromDb != null)
            {
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }

                objFromDb.Name = product.Name;
                objFromDb.Manufacturer = product.Manufacturer;
                objFromDb.Distributor = product.Distributor;
                objFromDb.Cost = product.Cost;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.Description = product.Description;
                objFromDb.MSRP = product.MSRP;
                objFromDb.Price = product.Price;
                objFromDb.Weight = product.Weight;
                objFromDb.VolumeX = product.VolumeX;
                objFromDb.VolumeY = product.VolumeY;
                objFromDb.VolumeZ = product.VolumeZ;

            }
        }
    }
}
