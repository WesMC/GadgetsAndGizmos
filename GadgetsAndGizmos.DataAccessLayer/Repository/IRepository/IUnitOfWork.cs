using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        ISP_Call SP_Call { get; }
        IApplicationUserRepository ApplicationUser { get; }

        void Save();
    }
}
