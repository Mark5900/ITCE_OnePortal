using System.Text;

namespace DataAccessLibrary;

public class CM_Callers : ICM_Callers
{
    private readonly ISqlDataAccess _db;

    public CM_Callers(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<List<CallerModel>> GetCallers()
    {
        const string query = "SELECT * FROM dbo.CM_Callers";

        return _db.LoadData<CallerModel, dynamic>(query, new { });
    }

    public Task InsertCaller(CallerModel caller)
    {
        const string query = @"INSERT INTO dbo.CM_Callers (SkolePrefix, ADTelephoneNumber, AlternativNumber1, AlternativNumber2, Email, UPN)
                                VALUES (@SkolePrefix, @ADTelephoneNumber, @AlternativNumber1, @AlternativNumber2, @Email, @UPN);";

        return _db.SaveData(query, caller);
    }
}
