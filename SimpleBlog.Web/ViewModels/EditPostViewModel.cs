using SimpleBlog.Web.Models;

namespace SimpleBlog.Web.ViewModels
{
    public class EditPostViewModel
    {
        public int PostId { get; set; }
        public WritablePostModel EditedPost { get; set; }
    }
}