using BestPetSite.Models;

namespace BestPetSite.Repository.BestPetSite
{
   public interface IUserRepository : IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
