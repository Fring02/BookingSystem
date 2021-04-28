using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IModelService<User>
    { 
        Task<User> Login(string email, string password);
        Task<User> Register(User user, string password);
        Task<bool> UpdateUser(User userParam, string password = null);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
