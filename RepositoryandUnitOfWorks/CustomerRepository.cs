
using System.Linq;
using System.Collections.Generic;
using RepositoryandUnitOfWorks.DataAccess.Repositories;

namespace RepositoryandUnitOfWorks.DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
     {
        private readonly RepositoryAndUnitOfWorksEntities _repositoryAndUnitOfWorksEntities;

        public CustomerRepository(RepositoryAndUnitOfWorksEntities context) : base(context)
        {
             _repositoryAndUnitOfWorksEntities = context;
        }

        public IEnumerable<Customer> GetBestCustomers(int amountCustmoer)
        {
            return _repositoryAndUnitOfWorksEntities.Customers.OrderByDescending(x => x.Revenue).Take(amountCustmoer).ToList();
        }
     }
}
