namespace DataAccessLibrary;

public class CM_Operators : ICM_Operators
{
    private readonly ISqlDataAccess _db;

    public CM_Operators(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task<List<OperatorModel>> GetOperators()
    {
        const string query = @"
        SELECT o.OpID, o.ChangeApprover, c.*
        FROM [dbo].[CM_Operators] o
        INNER JOIN [dbo].[CM_Callers] c ON o.CallID = c.CallID";

        return await _db.LoadData<OperatorModel, dynamic>(query, new { });
    }
    public async Task InsertOperator(OperatorModel operatorModel)
    {
        const string query = @"INSERT INTO dbo.CM_Operators (CallID, ChangeApprover)
                                VALUES (@CallID, @ChangeApprover);";

        await _db.SaveData(query, operatorModel);
    }
}
