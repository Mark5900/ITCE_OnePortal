namespace DataAccessLibrary;

public interface ISqlDataAccess
{
    string ConnectionStringName { get; set; }

    Task<List<T>> LoadData<T, U>(string sql, U parameters);
    Task<List<TResult>> LoadData<TFirst, TSecond, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TResult> map, string splitOn);
    Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TThird, TResult> map, string splitOn);
    Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TFourth, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TThird, TFourth, TResult> map, string splitOn);
    Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TFourth, TFifth, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TThird, TFourth, TFifth, TResult> map, string splitOn);
    Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult> map, string splitOn);
    Task SaveData<T>(string sql, T parameters);
    Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TResult>(string sql, dynamic parameters, Func<TFirst, TSecond, TThird, TResult> map, string splitOn);
}
