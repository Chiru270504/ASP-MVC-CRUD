using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medamtest.Models
{
    public class form
    {
        [Required(ErrorMessage ="user id reuqired")]
        public int uid { get; set; }
        [Required(ErrorMessage ="username is required")]
        public string uname { get; set; }
        [Required(ErrorMessage ="password is required")]
        public string password { get; set; }
        [Required(ErrorMessage ="confirm password required")]
        [Compare("password",ErrorMessage ="password doesn't match")]
        public string conpassword { get; set; }
        [Required(ErrorMessage ="gender is required")]
        public string gender { get; set; }

        [Required(ErrorMessage = "*")]
        public string state { get; set; }
        [Required(ErrorMessage = "*")]
        public string city { get; set; }
        [Required(ErrorMessage = "*")]
        public List<string> hobbies { get; set; }
        [Required(ErrorMessage = "*")]
        public string address {  get; set; }

    }
}