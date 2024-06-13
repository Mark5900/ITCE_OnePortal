namespace DataAccessLibrary;

public interface ICM_Changes
{
    Task<List<ChangeModel>> GetChanges();
    Task<ChangeModel> GetChange(int ChanID);
    Task UpdateChange(ChangeModel change);
    Task<int> CreateChangeAndGetID(ChangeModel change);
}
