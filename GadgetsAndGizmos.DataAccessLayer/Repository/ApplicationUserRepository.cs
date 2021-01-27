using GadgetsAndGizmos.DataAccessLayer.Data;
using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
