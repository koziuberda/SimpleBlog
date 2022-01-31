using System;
using SimpleBlog.Entities;

namespace SimpleBlog.Web.Models
{
    public class ReadableCommentModel
    {
        public ReadableCommentModel(Comment comment)
        {
            Author = $"{comment.User.Firstname} {comment.User.Lastname}";
            Text = comment.Text;
            Date = comment.CreationDate;
        }

        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}