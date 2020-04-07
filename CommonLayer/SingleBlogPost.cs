using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class SingleBlogPost
    {
        public long PkBlogPostId { get; set; }
        public string slug { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string body { get; set; }
        public List<string> tagList { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }

        public SingleBlogPost()
        {
            tagList = new List<string>();
        }
    }
}
