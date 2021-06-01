using BookingWeb.Models;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection.Interfaces
{
    public interface IUsersApi
    {
        Task<string> RegisterOwnerAsync(RegisterDTO registerForm);
    }
}
