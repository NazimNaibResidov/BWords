using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Infrastructure.Exseptions;
using MediatR;

namespace BWords.Api.Application.Features.Commands.User.EmailConfigurations
{
    public class EmailConfigurationCommandHandler : IRequestHandler<EmailConfigurationCommand,bool>
    {
        private readonly IEmailConfigurationRepstory repstory;
        private readonly IUserRepstory userRepstory;

        public EmailConfigurationCommandHandler(IEmailConfigurationRepstory repstory, IUserRepstory userRepstory)
        {
            this.repstory = repstory;
            this.userRepstory = userRepstory;
        }

        public async Task<bool> Handle(EmailConfigurationCommand request, CancellationToken cancellationToken)
        {
            var EmailConfigurationResptoryId =await repstory.GetByIdAsync(request.ConfigurationId);
            if (EmailConfigurationResptoryId is null)
             throw new DataBaseValidotorExeptions("Configuration not found");
            var Dbuser =await userRepstory.GetSingleAsync(x => x.Email == EmailConfigurationResptoryId.NewEmailAdress);
            if (Dbuser is null)
                throw new DataBaseValidotorExeptions("user not found");
            if (Dbuser.EmailConfirmed)
                throw new DataBaseValidotorExeptions("email address alredy confirmed");
            Dbuser.EmailConfirmed = true;
            await userRepstory.UpdateAsync(Dbuser);
            return true;

        }
    }
}
