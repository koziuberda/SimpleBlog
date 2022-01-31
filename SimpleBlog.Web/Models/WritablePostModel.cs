using SimpleBlog.Entities;

namespace SimpleBlog.Web.Models
{
    public class WritablePostModel
    {
        public WritablePostModel()
        {
        }

        public WritablePostModel(Post post)
        {
            Title = post.Title;
            Text = post.Text;
        }

        public string Title { get; set; }
        public string Text { get; set; }
    }
}