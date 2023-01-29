using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KryptoniteAPI.Exceptions
{
    public class InvalidConfigurationException :Exception
    {
        public InvalidConfigurationException(string message):base(message)
        {

        }
    }
}
