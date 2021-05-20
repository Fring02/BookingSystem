using Booking.Users.PWA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.Apis.Interfaces
{
    public interface IUsersApi
    {
        Task<string> LoginResponseAsync(LoginViewModel user);
        Task<bool> UpdateUserAsync(UpdateUserViewModel user, string token = default);
        Task<string> RegisterResponseAsync(RegisterViewModel user);
        Task<UserViewModel> GetUserByIdAsync(Guid id, string token = default);
    }
}
