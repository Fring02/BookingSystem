using System;
using System.Threading.Tasks;
using Domain.Core.Models.Users;
using Domain.Interfaces.Repositories.Users;

namespace Domain.Interfaces.Services.Users
{
    public interface IUserService : IModelService<IUsersRepository, User, Guid>
    { 
        Task<User> LoginAsync(string email, string password);
        Task<User> RegisterAsync(User user, string password);
        Task<bool> UpdateUserWithPasswordAsync(User userParam, string password = null);
    }
}
