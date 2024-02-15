using Database.Model;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class GetUser : IGetUser
    {
        private readonly Context context;

        public GetUser(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        Domain.User IGetUser.Get(string name, string password)
        {
            var user = context.Users.SingleOrDefault(p => p.Name == name && p.Password == password);

            if (user == null) return null;

            return new() { Id = user.Id, Name = user.Name, Password = user.Password, RegisterDate = user.RegisterDate };
        }
    }
}
