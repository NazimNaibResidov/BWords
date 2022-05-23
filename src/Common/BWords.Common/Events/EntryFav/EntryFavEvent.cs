using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Common.Events.EntryFav
{
    public class EntryFavEvent
    {
        public Guid? EntryId { get; set; }
        public Guid? UserId { get; set; }
    }
}
