using Microsoft.EntityFrameworkCore;
using MStartPreHiringTask.DAL.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStartPreHiringTask.DAL.Models.User
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        
        
        [Required]
        public DateTime Server_DateTime { get; set; } = DateTime.Now;
        
        
        [Required]
        public DateTime DateTime_UTC { get; set; } = DateTime.UtcNow;
        
        
        [Required(ErrorMessage = "Update time is required!")]
        public DateTime Update_DateTime_UTC { get; set; }
        
        
        [Required(ErrorMessage = "Username is required!")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "First Name is required!")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "User Status is required!")]
        public Status status { get; set; }
        [Required(ErrorMessage = "User Gender is required!")]
        public Gender gender { get; set; }
        [Required(ErrorMessage = "User's Date of Birth is required!")]
        public DateTime Date_of_Birth { get; set; }

        //Navigational Property (Many) 
        public ICollection<Account.Account> Accounts { get; set; } = new HashSet<Account.Account>();    

    }
}
