using System.Text;

namespace DataAccessLibrary;

public class CM_Callers : ICM_Callers
{
    private readonly ISqlDataAccess _db;

    public CM_Callers(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<CallerModel>> GetCallers()
    {
        const string query = "SELECT * FROM dbo.CM_Callers";

        return await _db.LoadData<CallerModel, dynamic>(query, new { });
    }

    public async Task CreateCaller(CallerModel caller)
    {
        const string query = @"INSERT INTO dbo.CM_Callers (SkolePrefix, ADTelephoneNumber, AlternativNumber1, AlternativNumber2, Email, UPN)
                                VALUES (@SkolePrefix, @ADTelephoneNumber, @AlternativNumber1, @AlternativNumber2, @Email, @UPN);";

        await _db.SaveData(query, caller);
    }

    public async Task<CallerModel> GetCallerByEmailAddress(string email)
    {
        const string query = "SELECT * FROM dbo.CM_Callers WHERE Email = @Email";

        return await _db.LoadData<CallerModel, dynamic>(query, new { Email = email })
            .ContinueWith(x => x.Result.FirstOrDefault());
    }
    public async Task<CallerModel> GetCallerByUPN(string upn)
    {
        const string query = "SELECT * FROM dbo.CM_Callers WHERE UPN = @UPN";

        return await _db.LoadData<CallerModel, dynamic>(query, new { UPN = upn })
            .ContinueWith(x => x.Result.FirstOrDefault());
    }
    public async Task UpdateCaller(CallerModel caller)
    {
        const string query = @"UPDATE dbo.CM_Callers
                                SET SkolePrefix = @SkolePrefix, ADTelephoneNumber = @ADTelephoneNumber, AlternativNumber1 = @AlternativNumber1, AlternativNumber2 = @AlternativNumber2, Email = @Email, UPN = @UPN
                                WHERE CallID = @CallID;";

        _db.SaveData(query, caller);
    }
}
