using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMVVM18112019.Exceptions
{
    public class YearOfBirthTooLow: Exception
    {
        public YearOfBirthTooLow(string message): base(message)
        {
            
        }
    }
}
