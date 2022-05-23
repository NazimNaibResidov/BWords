using System.IO;
using System.Security;
using System.Xml.Xsl.Runtime;
using System.Runtime.Intrinsics.X86;
using System.Collections.Specialized;
using AutoMapper;
using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Common.Infrastructure.Exseptions;
using BWords.Common.Models.RequestModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.User.Updates
{
    public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepstory repstory;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepstory repstory)
        {
            this.mapper = mapper;
            this.repstory = repstory;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser =await repstory.GetByIdAsync(request.Id);
            if (dbUser is null)
                throw new DataBaseValidotorExeptions("user not found");
                var dbEmailAdress=dbUser.Email;
                var emailChaged=string.CompareOrdinal(dbEmailAdress,request.Email)!=0;
            mapper.Map(request, dbUser);
            var rows =await repstory.UpdateAsync(dbUser);
            if(emailChaged&&rows>0){
                var @events=new UserEmailExcancedEmail{
                    OldEmailAdress=null,
                    NewEmailAdress=request.Email
                };
                QueueDeclare.SendMessageToExchange(WordConstants.UserExcanced
                WordConstants.defaultExcanceType,
                WordConstants.UserEmailChancedQueueName,
                @events
            )
            return dbUser.Id;


        }
    }
}
