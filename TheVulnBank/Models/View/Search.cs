using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Models.View
{
    public class Search
    {
        public string Query { get; set; }
        public List<Article> Articles { get; set; }
    }
}