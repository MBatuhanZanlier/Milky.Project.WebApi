using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class Appuser:IdentityUser<int>
    { 
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string Email {  get; set; } 
        public string Usurname { get; set; }
        public string Password { get; set; } 

    }
}
