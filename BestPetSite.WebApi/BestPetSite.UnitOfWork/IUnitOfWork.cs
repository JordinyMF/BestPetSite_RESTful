using BestPetSite.Repository.BestPetSite;

namespace BestPetSite.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICustomerRepository Customers { get; }
        IPetRepository Pets { get; }
        IVeterinaryServiceRepository VeterinaryServices { get; }
    }
}
