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
            SELECT cha.*, ca.*, sub.*, op.*, ca_op.*
            FROM dbo.CM_Changes cha
            INNER JOIN dbo.CM_Callers ca ON cha.CallID = ca.CallID
            INNER JOIN dbo.CM_SubCategories sub ON cha.SubCatID = sub.SubCatID
            INNER JOIN dbo.CM_Categories cat ON sub.CatID = cat.CatID
            INNER JOIN dbo.CM_Operators op ON cha.OpID = op.OpID
            INNER JOIN dbo.CM_Callers ca_op ON op.CallID = ca_op.CallID
            WHERE cha.ChanID = @ChanID";

        var change = await _db.LoadData<ChangeModel, CallerModel, SubCategoryModel, OperatorModel, CallerModel, ChangeModel, dynamic>(query, new { ChanID },
            (cha, ca, sub, op, ca_op) =>
            {
                cha.Caller = ca;
                cha.SubCategory = sub;
                op.CallId = ca_op.CallId;
                op.SkolePrefix = ca_op.SkolePrefix;
                op.ADTelephoneNumber = ca_op.ADTelephoneNumber;
                op.AlternativNumber1 = ca_op.AlternativNumber1;
                op.AlternativNumber2 = ca_op.AlternativNumber2;
                op.Email = ca_op.Email;
                op.UPN = ca_op.UPN;
                cha.Operator = op;
                return cha;
            }, splitOn: "CallID,SubCatID,OpID,CallID");

        List<CommentModel> comments = await new CM_Comments(_db).GetComments(ChanID);
        comments = comments.OrderByDescending(c => c.ComID).ToList();

        change.FirstOrDefault().Comments = comments;

        return change.FirstOrDefault();
    }

    public async Task UpdateChange(ChangeModel change)
    {
        #region Create Caller and update if needed
        if (change.Caller.CallId == 0)
        {
            await new CM_Callers(_db).CreateCaller(change.Caller);

            CallerModel caller;
            if (!string.IsNullOrEmpty(change.Caller.UPN))
            {
                caller = await new CM_Callers(_db).GetCallerByUPN(change.Caller.UPN);
            }
            else
            {
                caller = await new CM_Callers(_db).GetCallerByEmailAddress(change.Caller.Email);
            }

            if (caller == null)
            {
                throw new Exception("Caller not found after creation");
            }
            else
            {
                change.Caller = caller;
            }
        }
        else
        {
            await new CM_Callers(_db).UpdateCaller(change.Caller);
        }
        #endregion

        string query = @"
        UPDATE dbo.CM_Changes
        SET CallID = @CallID, 
        BriefDescription = @BriefDescription,
        SubCatID = @SubCatID,
        Description = @Description,
        StartTime = @StartTime,
        ImplementedTime = @ImplementedTime,
        Status = @Status,
        ApprovedByApprover = @ApprovedByApprover,
        OpID = @OpID,
        IsTemplate = @IsTemplate,
        NeedApproval = @NeedApproval
        WHERE ChanID = @ChanID";

        var parameters = new
        {
            CallID = change.Caller.CallId,
            BriefDescription = change.BriefDescription,
            SubCatID = change.SubCategory.SubCatID,
            Description = change.Description,
            StartTime = change.StartTime,
            ImplementedTime = change.ImplementedTime,
            Status = change.Status,
            ApprovedByApprover = change.ApprovedByApprover,
            OpID = change.Operator.OpID,
            IsTemplate = change.IsTemplate,
            NeedApproval = change.NeedApproval,
            ChanID = change.ChanID
        };

        await _db.SaveData(query, parameters);

        foreach (var comment in change.Comments)
        {
            if (comment.ComID == 0)
            {
                await new CM_Comments(_db).CreateComment(comment, change.ChanID);
            }
            else
            {
                await new CM_Comments(_db).UpdateComment(comment);
            }
        }
    }
    public async Task<int> CreateChangeAndGetID(ChangeModel change){
        #region Create Caller and update if needed
        if (change.Caller.CallId == 0)
        {
            await new CM_Callers(_db).CreateCaller(change.Caller);

            CallerModel caller;
            if (!string.IsNullOrEmpty(change.Caller.UPN))
            {
                caller = await new CM_Callers(_db).GetCallerByUPN(change.Caller.UPN);
            }
            else
            {
                caller = await new CM_Callers(_db).GetCallerByEmailAddress(change.Caller.Email);
            }

            if (caller == null)
            {
                throw new Exception("Caller not found after creation");
            }
            else
            {
                change.Caller = caller;
            }
        }
        else
        {
            await new CM_Callers(_db).UpdateCaller(change.Caller);
        }
        #endregion

        string query = @"
        INSERT INTO dbo.CM_Changes
        (CallID, BriefDescription, SubCatID, Description, StartTime, ImplementedTime, Status, ApprovedByApprover, OpID, IsTemplate, NeedApproval)
        VALUES
        (@CallID, @BriefDescription, @SubCatID, @Description, @StartTime, @ImplementedTime, @Status, @ApprovedByApprover, @OpID, @IsTemplate, @NeedApproval)
        SELECT SCOPE_IDENTITY()";

        var parameters = new
        {
            CallID = change.Caller.CallId,
            BriefDescription = change.BriefDescription,
            SubCatID = change.SubCategory.SubCatID,
            Description = change.Description,
            StartTime = change.StartTime,
            ImplementedTime = change.ImplementedTime,
            Status = change.Status,
            ApprovedByApprover = change.ApprovedByApprover,
            OpID = change.Operator.OpID,
            IsTemplate = change.IsTemplate,
            NeedApproval = change.NeedApproval
        };

        change.ChanID = await _db.SaveDataAndGetID(query, parameters);

        foreach (var comment in change.Comments)
        {
            await new CM_Comments(_db).CreateComment(comment, change.ChanID);
        }

        return change.ChanID;
    }
}
