using Mb.Application.contracts.Comment;
using Mb.Domain.CommentAgg;
using Mb.Domain.CommentAgg.Repository;

namespace Mb.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<CommentViewModel> Get_All_Comment()
        {
            return _commentRepository.Get_All_Comments();
        }

        public void Create(CreateComment command)
        {
            var Comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(Comment);
        }

        public void Change_To_Cancel(long Id)
        {
            _commentRepository.Change_Status_To_Cancel(Id);
        }

        public void Change_To_Confiremed(long Id)
        {
            _commentRepository.Change_Status_To_Confirmed(Id);
        }
    }
}
