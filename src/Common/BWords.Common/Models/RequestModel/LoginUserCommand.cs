using BWords.Common.Models.Quiers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Common.Models.RequestModel
{
    public class LoginUserCommand:IRequest<LoginUserViewModel>
    {
        public LoginUserCommand(string password)
        {
            Password = password;
        }
        public LoginUserCommand()
        {

        }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
    }
}
