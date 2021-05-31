using BookingWeb.Models;
using System;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection.Interfaces
{
    public interface IUsersApi
    {
        Task<User> GetUserById(Guid id);
        Task<bool> UpdateUser(User user);
        Task<string> RegistrationToken(User user);
        Task<string> AuthentificationToken(User user);
        Task RegisterOwner(RegisterDTO registerForm);
    }
}
