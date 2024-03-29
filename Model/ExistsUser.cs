﻿using Database.Model;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ExistsUser : IExistsUser
    {
        private readonly Context context;

        public ExistsUser(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool Exists(Domain.User user)
        {
            return context.Users.SingleOrDefault(p => p.Name == user.Name && p.Password == user.Password) == null ? false : true;
        }
    }
}
