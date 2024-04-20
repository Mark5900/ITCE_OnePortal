namespace DataAccessLibrary;

public class CM_Comments : ICM_Comments
{
    private readonly ISqlDataAccess _db;

    public CM_Comments(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task<List<CommentModel>> GetComments(int ChanID)
    {
        string query = @"
            SELECT com.*, op.*, ca.*
            FROM dbo.CM_Comments com
            INNER JOIN dbo.CM_Operators op ON com.OpID = op.OpID
            INNER JOIN dbo.CM_Callers ca ON op.CallID = ca.CallID
            WHERE com.ChanID = " + ChanID;

        var commentList = new List<CommentModel>();

        await _db.LoadData<CommentModel, OperatorModel, CommentModel, dynamic>(query, new { },
            (com, op) =>
            {
                com.Operator = op;
                commentList.Add(com);
                return com;
            }, splitOn: "OpID,CallID");

        return commentList;
    }
}
