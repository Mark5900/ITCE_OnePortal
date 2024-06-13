namespace DataAccessLibrary;

public interface ICM_Callers
{
    Task<List<CallerModel>> GetCallers();
    Task CreateCaller(CallerModel caller);
    Task<CallerModel> GetCallerByEmailAddress(string email);
    Task<CallerModel> GetCallerByUPN(string upn);
    Task UpdateCaller(CallerModel caller);
}
