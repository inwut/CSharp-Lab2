using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exceptions
{
    class InvalidEmailException : PersonValidationException
    {
        public InvalidEmailException(string message) : base(message)
        {
            
        }

    }
}
