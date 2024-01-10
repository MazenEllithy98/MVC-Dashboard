using Microsoft.EntityFrameworkCore;
using MStartPreHiringTask.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStartPreHiringTask.DAL.Models.Account
{
    [Index(nameof(Account_Number), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }
        
        
        [Required]
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }

        
        
        public DateTime Server_DateTime { get; set; } = DateTime.Now;
        
        
        
        
        public DateTime DateTime_UTC { get; set; } = DateTime.UtcNow;




        [Required(ErrorMessage = "Update time is required!")]
        public DateTime Update_DateTime_UTC { get; set; }
       
        
        
        
        [Required]
        [RegularExpression(@"^[0-9]{7,7}$", ErrorMessage = "Account Number must be unique and Composed of 7 numbers ")]
        public int Account_Number { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Required]
        public Currencies CurrencyType { get; set; }
        
        
        [Required(ErrorMessage = "Account Status is required!")]
        public Status status { get; set; }

        //Navigational Property (ONE)
        public User.User User { get; set; }


    }
}
