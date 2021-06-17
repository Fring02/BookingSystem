using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Helpers.Exceptions;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Booking;

namespace Infrastructure.Services.Booking
{
    public class CommentService : BaseService<ICommentRepository, Comment, int>, ICommentService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILeisureServicesRepository _servicesRepository;
        public CommentService(ICommentRepository repository, IUsersRepository usersRepository, ILeisureServicesRepository servicesRepository) : base(repository)
        {
            _usersRepository = usersRepository;
            _servicesRepository = servicesRepository;
        }

        public override async Task<Comment> CreateAsync(Comment model)
        {
            if (await _usersRepository.GetByIdAsync(model.UserId) == null)
                throw new EntityNotFoundException("User with id " + model.UserId + " doesn't exist");
            if(await _servicesRepository.GetByIdAsync(model.ServiceId) == null)
                throw new EntityNotFoundException("Service with id " + model.UserId + " doesn't exist");
            return await base.CreateAsync(model);
        }

        public override async Task<bool> UpdateAsync(Comment model)
        {
            if (string.IsNullOrEmpty(model.Content))
                throw new ValidationException("New comment content shouldn't be empty");
            var comment = await _repository.GetByIdAsync(model.Id);
            if (comment == null) throw new EntityNotFoundException("Didn't found comment by id " + model.Id);
            comment.Content = model.Content;
            return await base.UpdateAsync(model);
        }

        public async Task<IEnumerable<Comment>> GetByServiceIdAsync(Guid serviceId)
        {
            if (serviceId == default) return null;
            return await _repository.GetByServiceIdAsync(serviceId);
        }
    }
}