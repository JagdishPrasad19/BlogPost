using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blogpost.Core.User.Model
{
    public class SignUpModel
    {
        [Required]
        public string UserName { get; set; }


        [Required]

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
