namespace DataAccessLibrary;

public class CM_SubCategories : ICM_SubCategories
{
    private readonly ISqlDataAccess _db;

    public CM_SubCategories(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<SubCategoryModel>> GetSubCategories()
    {
        const string query = @"
        SELECT sc.SubCatID, sc.Name, c.*
        FROM [dbo].[CM_SubCategories] sc
        INNER JOIN [dbo].[CM_Categories] c ON sc.CatID = c.CatID";

        return await _db.LoadData<SubCategoryModel, dynamic>(query, new { });
    }
    public async Task<List<SubCategoryModel>> GetSubCategoriesByCategory(int catID)
    {
        const string query = @"
        SELECT sc.SubCatID, sc.Name, c.*
        FROM [dbo].[CM_SubCategories] sc
        INNER JOIN [dbo].[CM_Categories] c ON sc.CatID = c.CatID
        WHERE sc.CatID = @catID";

        return await _db.LoadData<SubCategoryModel, dynamic>(query, new { catID });
    }
    public async Task InsertSubCategory(SubCategoryModel operatorModel)
    {
        const string query = @"INSERT INTO dbo.CM_SubCategories (CatID, Name)
                                VALUES (@CatID, @Name);";

        await _db.SaveData(query, operatorModel);
    }
}
