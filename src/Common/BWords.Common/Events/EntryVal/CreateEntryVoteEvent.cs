using BWords.Common.Models.RequestModel;
using BWords.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Common.Events.EntryVal
{
    public class CreateEntryVoteEvent:BaseCommand
    {
        public VoteTypes VoteTypes { get; set; }
    }

}
