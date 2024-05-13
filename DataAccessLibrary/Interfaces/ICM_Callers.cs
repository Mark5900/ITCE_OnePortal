namespace DataAccessLibrary;

public interface ICM_Callers
{
    Task<List<CallerModel>> GetCallers();
    Task InsertCaller(CallerModel caller);
    Task<CallerModel> GetCallerByEmailAddress(string email);
    Task<CallerModel> GetCallerByUPN(string upn);
}
