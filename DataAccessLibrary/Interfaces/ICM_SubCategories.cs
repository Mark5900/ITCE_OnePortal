namespace DataAccessLibrary;

public interface ICM_SubCategories
{
    Task<List<SubCategoryModel>> GetSubCategories();
    Task InsertSubCategory(SubCategoryModel subCategory);
}
