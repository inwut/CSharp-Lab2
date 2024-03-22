using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exceptions
{
    class PersonValidationException : Exception
    {
        public PersonValidationException(string message) : base(message)
        {
            
        }
    }
}
