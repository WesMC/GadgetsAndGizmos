using GadgetsAndGizmos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}
