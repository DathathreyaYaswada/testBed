using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Models.View
{
    public class Transfer
    {
        public List<TheVulnBank.Models.Data.Account> FromAccounts { get; set; }
        public List<TheVulnBank.Models.Data.Account> ToAccounts { get; set; }

        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public double Amount { get; set; }
        public string Message { get; set; }
    }
}