using GadgetsAndGizmos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
