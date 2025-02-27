using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImmobileApp.Exception
{
    public abstract class ImmobileAppException:SystemException
    {

        protected ImmobileAppException(string message):base(message){ }
        public abstract List<string> getErrorMessages();
        public abstract HttpStatusCode getStatusCode();
    }
}
