using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IModelService<User>
    { 
        Task<User> LoginAsync(string email, string password);
        Task<User> RegisterAsync(User user, string password);
        Task<bool> UpdateUserWithPasswordAsync(User userParam, string password = null);
    }
}
