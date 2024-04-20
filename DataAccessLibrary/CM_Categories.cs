namespace DataAccessLibrary;

public class CM_Categories : ICM_Categories
{
    private readonly ISqlDataAccess _db;

    public CM_Categories(ISqlDataAccess db)
    {
        _db = db;
    }
    public Task<List<CategoryModel>> GetCategories()
    {
        const string query = "SELECT * FROM dbo.CM_Categories";

        return _db.LoadData<CategoryModel, dynamic>(query, new { });
    }
    public Task InsertCategory(CategoryModel category)
    {
        const string query = @"INSERT INTO dbo.CM_Categories (Category)
                                VALUES (@Category);";

        return _db.SaveData(query, category);
    }
}
