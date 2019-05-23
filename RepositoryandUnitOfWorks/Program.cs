using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryandUnitOfWorks.DataAccess;

namespace RepositoryandUnitOfWorks
{
    class Program
    {
        static void Main(string[] args)
        {

            var customers = new List<Customer>()
            {
                new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 55,
                    ZipCode = "7777",
                    Revenue = 50
                },
                new Customer()
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Age = 22,
                    ZipCode = "6666",
                    Revenue = 25
                },
                new Customer()
                {
                    FirstName = "Sarah",
                    LastName = "Doe",
                    Age = 46,
                    ZipCode = "8765",
                    Revenue = 20000
                }
            };

            var annoyingCustomer = new Customer()
            {
                FirstName = "Jack",
                LastName = "Annoying",
                Age = 33,
                ZipCode = "5432",
                Revenue = 5
            }; 

            using (var unitOfWorks = new UnitOfWork(new RepositoryAndUnitOfWorksEntities()))
            {
                unitOfWorks.Customers.Add(new Customer() { FirstName = "Andile", LastName = "Ngubane", Age = 28, ZipCode = "", Revenue = 9_999_999 });
                unitOfWorks.Customers.Add(annoyingCustomer);
                unitOfWorks.Customers.AddRange(customers);

                //var foundCustomers = unitOfWorks.Customers.Find(x => x.LastName == "Annoying" || x.Revenue <= 50).ToList();
                //unitOfWorks.Customers.Remove(foundCustomers[0]);
                //foundCustomers.RemoveAt(0);
                //unitOfWorks.Customers.RemoveRange(foundCustomers);

                var bestCustomers = unitOfWorks.Customers.GetBestCustomers(2);

                unitOfWorks.Complete();
            }
        }
    }
}
