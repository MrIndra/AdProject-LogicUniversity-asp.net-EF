using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AD4.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        [Required(ErrorMessage = "Please enter a username.", AllowEmptyStrings = false)]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter a password.",AllowEmptyStrings = false)]
        public string password { get; set; }

        public string Roles { get; set; }

    }

    public enum RolesType
    {
        Admin = 1, 
        Employee = 0
    }
}