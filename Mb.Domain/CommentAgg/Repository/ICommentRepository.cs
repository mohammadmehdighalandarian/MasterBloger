using Mb.Application.contracts.Comment;

namespace Mb.Domain.CommentAgg.Repository
{
    public interface ICommentRepository
    {
        public List<Comment> Get_All_Comments();

        public void Create(Comment comment);

        public void Change_Status_To_Confirmed(long commentId);

        public void Change_Status_To_Cancel(long commentId);

        public void Save();

    }
}
