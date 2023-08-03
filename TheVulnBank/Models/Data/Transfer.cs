using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheVulnBank.Models.Data
{
    public class Transfer
    {
        public int Id { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public double Amount { get; set; }
        public string Message { get; set; }
    }
}