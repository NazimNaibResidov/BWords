using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Common
{
   public  class WordConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string defaultExcanceType = "dricet";
        public const string UserExcancedName = "UserExcanced";
        public const string UserEmailChancedQueueName="UserEmailChancedQueue";

        public const string EntryCommentExcancedName = "EntryCommentExcanced";
        public const string EntryCommentQueueName = "EntryCommentQueue";

        public const string FavEntryExcancedName = "EntryFavExcancedName";
        public const string FavEntryQueueName = "EntryFavQueueQueue";
        public const string ValEntryCommentQueueName = "ValEntryCommentQueueName";
        public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueueName";
        public const string DeleteEntryFavQueueName = "DeleteEntryFavQueue";
        public const string DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";
        public const string FavEntryCommentQueueName = "FavEntryCommentQueueName";
        // DeleteEntryFav
        public const string EntryValExcancedName = "EntryValExcancedName";
        public const string EntryValQueueName = "EntryValQueue";
    }
}
