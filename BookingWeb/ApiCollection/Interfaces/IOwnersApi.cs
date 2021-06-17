using BookingWeb.Models;
using System;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection.Interfaces
{
    public interface IOwnersApi
    {
        Task<string> RegisterOwnerAsync(RegisterDTO registerForm);
        Task<string> LoginOwnerAsync(LoginDTO loginForm);
        Task<OwnerProfileModel> GetOwnerByIdAsync(Guid id, string token = default);
    }
}
