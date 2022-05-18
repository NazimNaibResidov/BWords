using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Common.Infrastructure.Exseptions
{
    public class DataBaseValidotorExeptions : Exception
    {
        public DataBaseValidotorExeptions(string? message) : base(message)
        {
        }
    }
}
