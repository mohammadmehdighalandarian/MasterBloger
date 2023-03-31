using Mb.Domain.CommentAgg;
using Mb.Domain.CommentAgg.Repository;

namespace Mb.infrastructure.EFCore.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<Comment> Get_All_Comments()
        {
            return _context.Comments.ToList();
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            Save();
        }

        public void Change_Status_To_Confirmed(long commentId)
        {
            var Comment = _context.Comments.FirstOrDefault(x => x.Id == commentId);
            Comment.ChangeStatusToConfirmed();
            Save();
        }

        public void Change_Status_To_Cancel(long commentId)
        {
            var Comment = _context.Comments.FirstOrDefault(x => x.Id == commentId);
            Comment.ChangeStatusToCancel();
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
