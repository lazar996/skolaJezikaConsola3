using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    class TokenException : Exception
    {
        public TokenException()
        {

        }

        public TokenException(string msg): base(msg)
        {



        }
    }
}
