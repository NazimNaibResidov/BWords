using AutoMapper;
using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Infrastructure;
using BWords.Common.Infrastructure.Exseptions;
using BWords.Common.Models.RequestModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IUserRepstory repstory;

        public CreateUserCommandHandler(IMapper mapper, IUserRepstory repstory)
        {
            this.mapper = mapper;
            this.repstory = repstory;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existsUser = repstory.GetSingleAsync(x => x.Email == request.Email);
            if (existsUser is not null)
                throw new DataBaseValidotorExeptions("user alredy exists");
            var dataUser = mapper.Map<BWords.Api.Domain.Models.User>(request);

            var rows = await repstory.AddAsync(dataUser);
            if(rows>0){
                var @events=new UserEmailExcancedEmail{
                    OldEmailAdress=null,
                    NewEmailAdress=request.Email
                };
                QueueDeclare.SendMessageToExchange(WordConstants.UserExcanced
                WordConstants.defaultExcanceType,
                WordConstants.UserEmailChancedQueueName,
                @events
            )
            }

        }
    }
}
