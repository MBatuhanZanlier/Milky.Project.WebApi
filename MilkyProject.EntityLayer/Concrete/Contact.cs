﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class Contact
    { 
        public int ContactId { get; set; } 
        public string NameSurname { get; set; } 
        public string Email { get; set; } 
        public string Subject { get; set; } 
        public string Content { get; set; }
    
    }
}
