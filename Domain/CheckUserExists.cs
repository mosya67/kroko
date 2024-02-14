using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CheckUserExistsDecorator : IExistsUser
    {
        private IExistsUser service;

        public CheckUserExistsDecorator(IExistsUser service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public bool Exists(string name)
        {
            return service.Exists(name);
        }
    }
}
