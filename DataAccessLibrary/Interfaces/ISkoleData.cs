namespace DataAccessLibrary;

public interface ISkoleData
{
    Task<List<SkoleDataModel>> GetSkoleData();
    Task InsertSkoleData(SkoleDataModel skoleData);

}
