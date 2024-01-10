using MStartPreHiringTask.BLL.Interfaces;
using MStartPreHiringTask.DAL.Context;
using MStartPreHiringTask.DAL.Models.Account;
using MStartPreHiringTask.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStartPreHiringTask.BLL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; //Ask CLR to create an object from dbContext
        }
        public int Add(Account account)
        {
            _dbContext.Accounts.Add(account);
            return _dbContext.SaveChanges();
        }

        public int Delete(Account account)
        {
            _dbContext?.Accounts.Remove(account);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Account> GetAll()
        => _dbContext.Accounts.ToList();

        public Account GetByAccountID(int id)
            => _dbContext.Accounts.Find(id);


        public Account GetByUserID(int Id)
        {
            var account = _dbContext.Accounts.Local.Where(A => A.UserId == Id).FirstOrDefault();
            if (account is null)
                return _dbContext.Accounts.Where(A => A.UserId == Id).FirstOrDefault();

            return account;
        }
            

        public Account GetByAccountNumber(int AccNum)
        {
            var account = _dbContext.Accounts.Local.Where(A => A.Account_Number == AccNum).FirstOrDefault();
            if (account is null)
                return _dbContext.Accounts.Where(A => A.Account_Number == AccNum).FirstOrDefault();

            return account;

        }

        public int Update(Account account)
        {
            _dbContext.Accounts.Update(account);
            return _dbContext.SaveChanges();
        }
    }
}
