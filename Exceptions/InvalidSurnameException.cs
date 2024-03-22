using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exceptions
{
    class InvalidSurnameException : PersonValidationException
    {
        public InvalidSurnameException(string message) : base(message)
        {
            
        }
    }
}
