using _01_Framwork.Domain;
using Mb.Domain.ArticleAgg;

namespace Mb.Domain.CommentAgg
{
    public class Comment:DomainBase<long>
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Message { get; private set; }

        public int Status { get; private set; } = CommentAgg.Status.NewComment;

        public long ArticleId { get; private set; }

        public Article Article { get; set; }



        public Comment(string name, string email, string message, long articleId)
        {
            if (CheckNullOrWhiteSpace(name) & CheckNullOrWhiteSpace(email) & CheckNullOrWhiteSpace(message))
                throw new Exception("Fill the textbox");
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
        }

        public void ChangeStatusToConfirmed()
        {
            this.Status = CommentAgg.Status.Confirmed;
        }
        public void ChangeStatusToCancel()
        {
            this.Status = CommentAgg.Status.Canceled;
        }

        public static bool CheckNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return true;
            return false;
        }
    }
}
