namespace DataAccessLibrary;

public class CM_Changes : ICM_Changes
{
    private readonly ISqlDataAccess _db;

    public CM_Changes(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<ChangeModel>> GetChanges()
    {
        string query = @"
            SELECT cha.*, ca.*, sub.*, cat.*, op.*
            FROM dbo.CM_Changes cha
            INNER JOIN dbo.CM_Callers ca ON cha.CallID = ca.CallID
            INNER JOIN dbo.CM_SubCategories sub ON cha.SubCatID = sub.SubCatID
            INNER JOIN dbo.CM_Categories cat ON sub.CatID = cat.CatID
            INNER JOIN dbo.CM_Operators op ON cha.OpID = op.OpID";

        var changeList = new List<ChangeModel>();

        await _db.LoadData<ChangeModel, CallerModel, SubCategoryModel, CategoryModel, OperatorModel, ChangeModel, dynamic>(query, new { },
            (cha, ca, sub, cat, op) =>
            {
                cha.Caller = ca;
                sub.Category = cat.Category; // Assuming Category is a property in SubCategoryModel
                cha.SubCategory = sub;
                cha.Operator = op;
                changeList.Add(cha);
                return cha;
            }, splitOn: "CallID,SubCatID,CatID,OpID");

        return changeList;
    }

    public async Task<ChangeModel> GetChange(int ChanID)
    {
        string query = @"
            SELECT cha.*, ca.*, sub.*, op.*
            FROM dbo.CM_Changes cha
            INNER JOIN dbo.CM_Callers ca ON cha.CallID = ca.CallID
            INNER JOIN dbo.CM_SubCategories sub ON cha.SubCatID = sub.SubCatID
            INNER JOIN dbo.CM_Categories cat ON sub.CatID = cat.CatID
            INNER JOIN dbo.CM_Operators op ON cha.OpID = op.OpID
            WHERE cha.ChanID = " + ChanID;

        var change = await _db.LoadData<ChangeModel, CallerModel, SubCategoryModel, OperatorModel, ChangeModel, dynamic>(query, new { },
            (cha, ca, sub, op) =>
            {
                cha.Caller = ca;
                cha.SubCategory = sub;
                cha.Operator = op;
                return cha;
            }, splitOn: "CallID,SubCatID,OpID");

        List<CommentModel> comments = await new CM_Comments(_db).GetComments(ChanID);
        change.FirstOrDefault().Comments = comments;

        return change.FirstOrDefault();
    }
}
