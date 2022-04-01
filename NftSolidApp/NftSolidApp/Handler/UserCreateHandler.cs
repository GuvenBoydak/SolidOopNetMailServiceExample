using NftSolidApp.Base;
using NftSolidApp.Commands;
using NftSolidApp.Entities;
using NftSolidApp.Interface;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Handler
{
    public class UserCreateHandler : ICommandHandler<UserCreateCommand, ResponceBase>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ResponceBase Execute(UserCreateCommand command)
        {
            ResponceBase responce = new ResponceBase();

            User user = new User(command.Name,command.Surname,command.Email);

            _userRepository.Add(user);

            int result = _userRepository.Save();

            if (result>0)
            {
                responce.IsSuccesed = true;
                responce.Message = "Başarıyla Kullanıcı Eklendi.";
            }
            else
            {
                responce.IsSuccesed = true;
                responce.Message = "Kullanıcı Ekleme Başarısız!!!";
            }
            return responce;
        }
    }
}
