using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStartPreHiringTask.DAL.Models.Account
{
    public enum Currencies
    {
        USD,
        EUR,
        GBP,
        EGP
    }
    public struct Currency
    {
        public Currencies CurrencyType { get; }

    }
}
