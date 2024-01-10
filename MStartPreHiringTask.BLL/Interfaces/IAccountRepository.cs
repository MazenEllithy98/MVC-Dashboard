using MStartPreHiringTask.DAL.Models.Account;
using MStartPreHiringTask.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStartPreHiringTask.BLL.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account GetByAccountID(int AccountId);
        Account GetByUserID(int UserID);
        Account GetByAccountNumber(int AccNumber);
        int Add(Account account);
        int Update(Account account);
        int Delete(Account account);

    }
}
