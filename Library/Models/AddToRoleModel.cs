using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class AddToRoleModel
    {
        public string  email { get; set; }
        public string selectRole { get; set; }
        public List<string> roles { get; set; }
        public AddToRoleModel()
        {
            roles = new List<string>();
        }
    }
}