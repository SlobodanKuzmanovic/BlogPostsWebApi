using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class db_SingleBlogPost
    {
        public long? PkBlogPostId { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }

    }
}
