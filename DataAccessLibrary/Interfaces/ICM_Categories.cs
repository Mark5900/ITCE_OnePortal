namespace DataAccessLibrary;

public interface ICM_Categories
{
    Task<List<CategoryModel>> GetCategories();
    Task InsertCategory(CategoryModel category);
}
