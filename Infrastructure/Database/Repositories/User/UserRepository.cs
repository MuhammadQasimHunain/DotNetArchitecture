using Solution.CrossCutting.EntityFrameworkCore;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserModel>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public AuthenticatedModel Authenticate(AuthenticationModel authentication)
        {
            return SingleOrDefault<AuthenticatedModel>
            (
                where =>
                (
                    where.Login.Equals(authentication.Login)
                    && where.Password.Equals(authentication.Password)
                    && where.Status == Status.Active
                )
            );
        }
    }
}
