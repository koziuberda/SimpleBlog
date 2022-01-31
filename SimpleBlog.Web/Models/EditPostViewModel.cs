namespace SimpleBlog.Web.Models
{
    public class EditPostViewModel
    {
        public int PostId { get; set; }
        public WritablePostModel EditedPost { get; set; }
    }
}