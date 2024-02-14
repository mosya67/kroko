using Database.Model;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AddUser : IRegUser
    {
        private readonly Context context;

        public AddUser(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Execute(Domain.User data)
        {
            context.Add(new Model.User
            { 
                Name = data.Name,
                Password = data.Password,
                RegisterDate = data.RegisterDate,
            });

            context.SaveChanges();
        }
    }
}
