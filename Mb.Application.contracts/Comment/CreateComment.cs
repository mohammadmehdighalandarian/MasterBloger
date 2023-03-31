namespace Mb.Application.contracts.Comment
{
    public class CreateComment
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Message { get; private set; }

        public long ArticleId { get; private set; }
    }
}
