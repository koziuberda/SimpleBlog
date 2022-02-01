using System.Collections.Generic;

namespace SimpleBlog.Web.Models
{
    public class PostViewModel
    {
        public PostViewModel(ReadablePostModel post, List<ReadableCommentModel> comments, 
            WritableCommentModel newComment)
        {
            Post = post;
            Comments = comments;
            NewComment = newComment;
        }

        public ReadablePostModel Post { get; set; }
        public List<ReadableCommentModel> Comments { get; set; }
        public WritableCommentModel NewComment { get; set; }
    }
}