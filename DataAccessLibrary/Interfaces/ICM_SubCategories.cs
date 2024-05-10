namespace DataAccessLibrary;

public interface ICM_SubCategories
{
    Task<List<SubCategoryModel>> GetSubCategories();
    public Task<List<SubCategoryModel>> GetSubCategoriesByCategory(int catID);
    Task InsertSubCategory(SubCategoryModel subCategory);
}
