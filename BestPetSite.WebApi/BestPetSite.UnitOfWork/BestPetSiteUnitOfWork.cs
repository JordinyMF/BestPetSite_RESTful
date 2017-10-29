using System;
using BestPetSite.Repository.BestPetSite;

namespace BestPetSite.UnitOfWork
{
    public class BestPetSiteUnitOfWork : IUnitOfWork, IDisposable
    {
        public BestPetSiteUnitOfWork()
        {
            Users = new UserRepository();
            Customers = new CustomerRepository();
            Pets = new PetRepository();
            VeterinaryServices = new VeterinaryServiceRepository();
        }

        public IUserRepository Users { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IPetRepository Pets { get; private set; }
        public IVeterinaryServiceRepository VeterinaryServices { get; private set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
