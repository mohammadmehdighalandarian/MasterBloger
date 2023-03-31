using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Domain.ArticleAgg;

namespace Mb.Domain.CommentAgg
{
    public class Comment
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; } = CommentAgg.Status.NewComment;
        public DateTime CreationDate { get; private set; }

        public long ArticleId { get; private set; }
        public Article Article { get; set; }

        public Comment(string name, string email, string message,long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            CreationDate=DateTime.Now;
        }

        public void ChangeStatusToConfirmed()
        {
            this.Status = CommentAgg.Status.Confirmed;
        }
        public void ChangeStatusToCancel()
        {
            this.Status = CommentAgg.Status.Canceled;
        }
    }
}
