﻿using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneUser(User user) => CreateOneUser(user);

        public void DeleteOneUser(User user)=> DeleteOneUser(user);

        public IQueryable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges).OrderBy(c=>c.Id);

        public User GetOneUserById(string id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOneUser(User user)=> UpdateOneUser(user);
    }
}
