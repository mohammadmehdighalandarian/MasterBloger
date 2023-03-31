namespace Mb.Application.contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> Get_All_Comment();

        void Create(CreateComment command);

        void Change_To_Cancel(long Id);

        void Change_To_Confiremed(long Id);

    }
}
