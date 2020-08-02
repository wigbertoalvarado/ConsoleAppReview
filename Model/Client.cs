using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string Dir { get; set; }
        public DateTime Birthday { get; set; }
        //public TypeOfPerson PersonType { get; set; }
    }

   

    //public enum TypeOfPerson 
    //{ 
    //    Underage =1,
    //    Adult =2,
    //    SeniorAdult =3
    //}
    // son predefinidos
}
