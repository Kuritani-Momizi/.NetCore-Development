using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suika.Services.Identity.Initializer
{
    public interface IDbInitializer
    {
        public void Initialize();
    }
}
