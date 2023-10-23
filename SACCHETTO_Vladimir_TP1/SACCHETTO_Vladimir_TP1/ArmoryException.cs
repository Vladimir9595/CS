using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_TP1
{
    public class ArmoryException : Exception
    {
        public ArmoryException() { }
        public ArmoryException(string message) : base(message)
        {
        }
    }
}
