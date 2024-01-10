using MStartPreHiringTask.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStartPreHiringTask.BLL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByID(int Id);
        User GetByName(string Name);
        User GetByEmail(string Email);
        int Add(User user);
        int Update(User user);
        int Delete(User user);

    }
}
