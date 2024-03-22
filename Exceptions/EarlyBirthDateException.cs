using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exceptions
{
    class EarlyBirthDateException : PersonValidationException
    {
        public EarlyBirthDateException(string message) : base(message)
        {
            
        }
    }
}
