using AutoMapper;
using BWords.Api.Application.Features.Commands.User.Create;
using BWords.Api.Domain.Models;
using BWords.Common.Models.Quiers;
using BWords.Common.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Mapping
{
   public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();
            CreateMap<CreateUserCommandHandler, User>()
                .ReverseMap();
            CreateMap<UpdateUserCommand, User>()
                .ReverseMap();
            CreateMap<Entiry, GetEntryViewModel>()
                .ForMember(x => x.CommentCount, y => y.MapFrom(z => z.EntryComments.Count));
            CreateMap<CreateEntryCommentCommand, EntryComment>
                ().ReverseMap();
        }
    }
}
