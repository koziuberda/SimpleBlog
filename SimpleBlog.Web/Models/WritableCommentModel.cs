namespace SimpleBlog.Web.Models
{
    public class WritableCommentModel
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}