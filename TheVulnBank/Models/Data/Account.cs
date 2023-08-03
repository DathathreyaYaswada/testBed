using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheVulnBank.Models.Data
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
    }
}