﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWebBackEnd.Model
{
    public class LoginData
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        
        public string Surname { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
