using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWebBackEnd.Model
{
    public class ReturnData
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string message { get; set; }
        public bool OutPut { get; set; }
        
    }
}
