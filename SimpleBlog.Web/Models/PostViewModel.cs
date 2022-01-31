using System.Collections.Generic;

namespace SimpleBlog.Web.Models
{
    public class PostViewModel
    {
        public PostViewModel(ReadablePostModel post, List<ReadableCommentModel> comments)
        {
            Post = post;
            Comments = comments;
        }

        public ReadablePostModel Post { get; set; }
        public List<ReadableCommentModel> Comments { get; set; }
    }
}