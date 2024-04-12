namespace DataAccessLibrary;

public class SkoleData : ISkoleData
{
    private readonly ISqlDataAccess _db;

    public SkoleData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<List<SkoleDataModel>> GetSkoleData()
    {
        const string sql = "SELECT * FROM dbo.SkoleData";

        return _db.LoadData<SkoleDataModel, dynamic>(sql, new { });
    }

    public Task InsertSkoleData(SkoleDataModel skoleData)
    {
        const string sql = @"INSERT INTO dbo.SkoleData (SkolePrefix, SkoleNavn, TeknikerGruppe, CVR, EAN)
                             VALUES (@SkolePrefix, @SkoleNavn, @TeknikerGruppe, @CVR, @EAN);";

        return _db.SaveData(sql, skoleData);
    }
}
