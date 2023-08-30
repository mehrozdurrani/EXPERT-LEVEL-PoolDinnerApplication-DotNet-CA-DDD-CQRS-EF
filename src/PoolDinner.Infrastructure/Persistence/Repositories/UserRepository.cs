using PoolDinner.Application.Common.Interfaces.Persistence;
using PoolDinner.Domain.UserAggregate;

namespace PoolDinner.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly static List<User> _users = new List<User>();

        void IUserRepository.Add(User user)
        {
            _users.Add(user);
        }

        User? IUserRepository.GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}

