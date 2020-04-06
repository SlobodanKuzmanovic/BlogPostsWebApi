using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class SingleBlogPost
    {
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
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
