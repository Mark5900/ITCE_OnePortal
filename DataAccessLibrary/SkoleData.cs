namespace DataAccessLibrary;

public class SkoleData : ISkoleData
{
    private readonly ISqlDataAccess _db;

    public SkoleData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<SkoleDataModel>> GetSkoleData()
    {
        const string query = "SELECT * FROM dbo.SkoleData";

        return await _db.LoadData<SkoleDataModel, dynamic>(query, new { });
    }

    public async Task InsertSkoleData(SkoleDataModel skoleData)
    {
        const string query = @"
            INSERT INTO dbo.SkoleData (SkolePrefix, SkoleNavn, TeknikerGruppe, CVR, EAN)
            VALUES (@SkolePrefix, @SkoleNavn, @TeknikerGruppe, 
                    CASE WHEN @CVR IS NULL OR @CVR = '' THEN NULL ELSE CAST(@CVR AS NUMERIC) END, 
                    CASE WHEN @EAN IS NULL OR @EAN = '' THEN NULL ELSE CAST(@EAN AS NUMERIC) END);";

        _db.SaveData(query, skoleData);
    }
}
