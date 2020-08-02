using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public bool AccountState { get; set ; }
    }
}