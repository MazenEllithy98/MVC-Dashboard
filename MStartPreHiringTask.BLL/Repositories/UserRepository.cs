using MStartPreHiringTask.BLL.Interfaces;
using MStartPreHiringTask.DAL.Context;
using MStartPreHiringTask.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MStartPreHiringTask.BLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; //Ask CLR to create an object from dbContext
        }
        public int Add(User user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }

        public int Delete(User user)
        {
            _dbContext?.Users.Remove(user);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        => _dbContext.Users.ToList();

        public User GetByEmail(string Email)
        {

            var user = _dbContext.Users.Local.Where(U => U.Email == Email).FirstOrDefault();
            if (user is null)
             return _dbContext.Users.Where(U => U.Email == Email).FirstOrDefault();
            
            return user;
        }


        public User GetByID(int Id)
            => _dbContext.Users.Find(Id);

        public User GetByName(string Name)
        {
        

            var user = _dbContext.Users.Local.Where(U => U.UserName == Name).FirstOrDefault();
            if (user is null)
                return _dbContext.Users.Where(U => U.UserName == Name).FirstOrDefault();

            return user;
        
        }

        public int Update(User user)
        {
            _dbContext.Users.Update(user);
            return _dbContext.SaveChanges();
        }
    }
}
