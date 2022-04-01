using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Commands
{
    public class UserCreateCommand:ICommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public UserCreateCommand(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
