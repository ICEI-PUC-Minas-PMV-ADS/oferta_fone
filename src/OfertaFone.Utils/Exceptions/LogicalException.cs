using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Utils.Exceptions
{
    public class LogicalException : Exception
    {
        public LogicalException(string message) : base(message)
        { }
    }
}
