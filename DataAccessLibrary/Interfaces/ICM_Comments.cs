namespace DataAccessLibrary;

public interface ICM_Comments
{
    Task<List<CommentModel>> GetComments(int ChanID);
    Task UpdateComment(CommentModel comment);
}
