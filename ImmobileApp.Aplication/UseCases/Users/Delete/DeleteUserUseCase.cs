using AutoMapper;
using ImmobileApp.Aplication.UseCases.Users.Delete.Interfaces;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmobileApp.Aplication.UseCases.Users.Delete
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUserRepository _repository;

        public DeleteUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task execute(Guid userId)
        {
            var user = await _repository.GetUserById(userId);
            if (user == null) {
                throw new NotFoundException();
            }
            await _repository.DeleteUser(user);
        }
    }
}
