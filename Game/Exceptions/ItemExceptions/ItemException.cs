using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions.ItemExceptions
{
    public class ItemException : Exception
    {
        public ItemException()
            : base()
        {
        }
        
        public ItemException(string msg)
            : base(msg)
        {
        }
    }
}
