using NftSolidApp.Handler;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class UserCreateHandlerFactory
    { 
        public static UserCreateHandler GetInstance()
        {
            UserRepository userRepository = UserRepositoryFactory.GetInstance();

            return new UserCreateHandler(userRepository);
        }
    }
}
