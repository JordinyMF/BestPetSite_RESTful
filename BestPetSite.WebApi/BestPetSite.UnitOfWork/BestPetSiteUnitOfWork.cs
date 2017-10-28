using System;
using BestPetSite.Repository.BestPetSite;

namespace BestPetSite.UnitOfWork
{
    public class BestPetSiteUnitOfWork : IUnitOfWork, IDisposable
    {
        public BestPetSiteUnitOfWork()
        {
            Users = new UserRepository();
        }

        public IUserRepository Users { get; private set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
