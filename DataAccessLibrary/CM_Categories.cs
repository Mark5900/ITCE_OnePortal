namespace DataAccessLibrary;

public class CM_Categories : ICM_Categories
{
    private readonly ISqlDataAccess _db;

    public CM_Categories(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task<List<CategoryModel>> GetCategories()
    {
        const string query = "SELECT * FROM dbo.CM_Categories";

        return await _db.LoadData<CategoryModel, dynamic>(query, new { });
    }
    public async Task InsertCategory(CategoryModel category)
    {
        const string query = @"INSERT INTO dbo.CM_Categories (Category)
                                VALUES (@Category);";

        await _db.SaveData(query, category);
    }
}
