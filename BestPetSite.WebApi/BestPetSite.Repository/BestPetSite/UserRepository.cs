using System.Data.SqlClient;
using BestPetSite.Models;
using Dapper;

namespace BestPetSite.Repository.BestPetSite
{
  public  class UserRepository : BaseRepository<User>,IUserRepository
    {
        public User ValidateUser(string email, string password)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                return connection
                    .QueryFirstOrDefault<User>("dbo.ValidateUser",
                        parameters,
                        commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
