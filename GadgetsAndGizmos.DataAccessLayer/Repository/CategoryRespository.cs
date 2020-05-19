using GadgetsAndGizmos.DataAccessLayer.Data;
using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository
{
    public class CategoryRespository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.CategoryId == category.CategoryId);

            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                _db.SaveChanges();
            }
        }
    }
}
