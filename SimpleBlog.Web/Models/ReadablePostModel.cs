using System;
using SimpleBlog.Entities;

namespace SimpleBlog.Web.Models
{
    public class ReadablePostModel
    {
        public ReadablePostModel(Post post)
        {
            Id = post.Id;
            CreationDate = post.CreationDate;
            Title = post.Title;
            Text = post.Text;
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}