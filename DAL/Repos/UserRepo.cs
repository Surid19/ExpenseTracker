using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            var user = Read(id);
            if (user != null)
            {
                db.Users.Remove(user);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(string id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var existingUser = Read(obj.Uname);
            if (existingUser != null)
            {
                db.Entry(existingUser).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }

        public List<User> ReadByType(string userType)
        {
            return db.Users.Where(u => u.Type == userType).ToList();
        }

        List<User> IRepo<User, string, User>.ReadByCategory(string category)
        {
            throw new NotImplementedException();
        }

        List<User> IRepo<User, string, User>.ReadByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        List<User> IRepo<User, string, User>.ReadRecurring()
        {
            throw new NotImplementedException();
        }
    }

    internal interface IRepo<T1, T2, T3, T4>
    {
    }
}
