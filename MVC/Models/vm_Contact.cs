using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class vm_Contact
    {
        public int c_ContactId { get; set; }
        public int c_UserId { get; set; }
        public string c_UserName { get; set; }
        public string c_ContactName { get; set; }
        public string c_Email { get; set; }
        public string c_Group { get; set; }
        public string? c_Address { get; set; }
        public string? c_Mobile { get; set; }
        public string? c_Image { get; set; }
        public string? c_Status { get; set; }
    }
}