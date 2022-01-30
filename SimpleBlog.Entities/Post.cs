using System;
using System.Collections.Generic;

namespace SimpleBlog.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Comment> Comments { get; set; }
    }
}