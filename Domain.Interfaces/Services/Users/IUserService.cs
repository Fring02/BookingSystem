using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Users;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IModelService<IUsersRepository, User>
    { 
        Task<User> LoginAsync(string email, string password);
        Task<User> RegisterAsync(User user, string password);
        Task<bool> UpdateUserWithPasswordAsync(User userParam, string password = null);
    }
}
