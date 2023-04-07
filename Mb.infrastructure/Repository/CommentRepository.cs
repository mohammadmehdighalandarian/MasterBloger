using Mb.Application.contracts.Comment;
using Mb.Domain.CommentAgg;
using Mb.Domain.CommentAgg.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mb.infrastructure.EFCore.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<CommentViewModel> Get_All_Comments()
        {
            return _context.Comments.Include(x=>x.Article)
                .Select(x=>new CommentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    CreationDate = x.CreationDate.ToString(),
                    ArticleName = x.Article.Title,
                    Message = x.Message,
                    Status = x.Status

                }).ToList();
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
