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
        WHERE com.ChanID = @ChanID";

        var commentList = new List<CommentModel>();

        await _db.LoadData<CommentModel, OperatorModel, OperatorModel, dynamic, dynamic>(query, new { ChanID },
            (com, op, ca) =>
            {
                op.CallId = ca.CallId;
                op.SkolePrefix = ca.SkolePrefix;
                op.ADTelephoneNumber = ca.ADTelephoneNumber;
                op.AlternativNumber1 = ca.AlternativNumber1;
                op.AlternativNumber2 = ca.AlternativNumber2;
                op.Email = ca.Email;
                op.UPN = ca.UPN;
                com.Operator = op;
                commentList.Add(com);
                return com;
            }, splitOn: "OpID,CallID");

        return commentList;
    }

    public async Task UpdateComment(CommentModel comment)
    {
        // Tjek om Operator eksisterer i databasen
        var operatorExists = await _db.LoadData<OperatorModel, dynamic>("SELECT * FROM dbo.CM_Operators WHERE OpID = @OpID", new { OpID = comment.Operator.OpID });

        if (operatorExists == null || operatorExists.Count == 0)
        {
            throw new Exception($"Operator with given OpID does not exist in the database. OpID: {comment.Operator.OpID}");
        }

        string query = @"
        UPDATE dbo.CM_Comments
        SET Comment = @Comment, OpID = @OpID
        WHERE ComID = @ComID;";

        var parameters = new
        {
            Comment = comment.Comment,
            OpID = comment.Operator.OpID,
            ComID = comment.ComID
        };

        try
        {
            await _db.SaveData(query, parameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task CreateComment(CommentModel comment, int ChanID)
    {
        // Tjek om Operator eksisterer i databasen
        var operatorExists = await _db.LoadData<OperatorModel, dynamic>("SELECT * FROM dbo.CM_Operators WHERE OpID = @OpID", new { OpID = comment.Operator.OpID });

        if (operatorExists == null || operatorExists.Count == 0)
        {
            throw new Exception($"Operator with given OpID does not exist in the database. OpID: {comment.Operator.OpID}");
        }

        string query = @"
        INSERT INTO dbo.CM_Comments (Comment, OpID, ChanID)
        VALUES (@Comment, @OpID, @ChanID);";

        var parameters = new
        {
            Comment = comment.Comment,
            OpID = comment.Operator.OpID,
            ChanID = ChanID
        };

        try
        {
            await _db.SaveData(query, parameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
