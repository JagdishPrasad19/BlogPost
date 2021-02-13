using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blogpost.Core.Blog.Model
{
    public class BlogEditModel
    {
        public long Id { get; set; }
        [Required]
        public string Titel { get; set; }
        public string Content { get; set; }
    }
}
