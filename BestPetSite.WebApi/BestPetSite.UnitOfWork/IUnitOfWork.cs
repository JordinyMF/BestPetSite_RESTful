using BestPetSite.Repository.BestPetSite;

namespace BestPetSite.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
