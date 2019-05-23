using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryandUnitOfWorks.DataAccess.Repositories;

namespace RepositoryandUnitOfWorks.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryAndUnitOfWorksEntities _context;

        public UnitOfWork(RepositoryAndUnitOfWorksEntities context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
        }
        public ICustomerRepository Customers { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
