using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ClientAccountDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
