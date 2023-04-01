using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnipeITdotNET.Clients
{
    public abstract class BaseClient<T>
    {
        protected BaseClient() 
        {
        }

        public abstract T Get();


    }
}
