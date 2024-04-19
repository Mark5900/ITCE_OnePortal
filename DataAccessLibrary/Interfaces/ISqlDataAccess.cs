namespace DataAccessLibrary;

public interface ISqlDataAccess
{
    string ConnectionStringName { get; set; }

    Task<List<T>> LoadData<T, U>(string sql, U parameters);
    Task<List<TResult>> LoadData<TFirst, TSecond, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TResult> map, string splitOn);
    Task<T> LoadSingleData<T, U>(string sql, U parameters);
    Task SaveData<T>(string sql, T parameters);
}
