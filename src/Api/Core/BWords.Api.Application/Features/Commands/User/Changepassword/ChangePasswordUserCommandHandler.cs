using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Infrastructure;
using BWords.Common.Infrastructure.Exseptions;
using BWords.Common.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.User.Changepassword
{
    internal class ChangePasswordUserCommandHandler : IRequestHandler<ChangePasswordUserCommand, bool>
    {
        private readonly IUserRepstory _repstory;

        public ChangePasswordUserCommandHandler(IUserRepstory repstory)
        {
            this._repstory = repstory;
        }

        public async Task<bool> Handle(ChangePasswordUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue)
            throw new ArgumentNullException(nameof(request.UserId));
            var dbUser = await _repstory.GetByIdAsync(request.UserId.Value);
            if (dbUser is null)
                throw new DataBaseValidotorExeptions("user not found");

            var encPass = PasswordEncryption.Encrypt(request.OldPassword);
            if (dbUser.Password!=encPass)
                throw new DataBaseValidotorExeptions("old password wrong");
            dbUser.Password = PasswordEncryption.Encrypt(request.NewPassword);
            await _repstory.UpdateAsync(dbUser);
            return true;


        }
    }
}
