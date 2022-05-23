using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Features.Commands.User.EmailConfigurations
{
    public class EmailConfigurationCommand:IRequest<bool>
    {
        public Guid ConfigurationId { get; set; }
    }
}
