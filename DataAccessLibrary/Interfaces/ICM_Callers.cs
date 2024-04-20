namespace DataAccessLibrary;

public interface ICM_Callers
{
    Task<List<CallerModel>> GetCallers();
    Task InsertCaller(CallerModel caller);
}
