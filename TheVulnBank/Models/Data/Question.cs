using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheVulnBank.Models.Data
{
    public class Question
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AgentId { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }         
    }
}