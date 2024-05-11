using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public string ConnectionStringName { get; set; } = "Default";

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync<T>(sql, parameters);

            return data.ToList();
        }
    }
    public async Task<List<TResult>> LoadData<TFirst, TSecond, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TResult> map, string splitOn)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync(sql, map, parameters, splitOn: splitOn);

            return data.ToList();
        }
    }
    public async Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TThird, TResult> map, string splitOn)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync(sql, map, parameters, splitOn: splitOn);

            return data.ToList();
        }
    }
    public async Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TFourth, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TThird, TFourth, TResult> map, string splitOn)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync(sql, map, parameters, splitOn: splitOn);

            return data.ToList();
        }
    }
    public async Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TFourth, TFifth, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TThird, TFourth, TFifth, TResult> map, string splitOn)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync(sql, map, parameters, splitOn: splitOn);

            return data.ToList();
        }
    }
    public async Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult, U>(string sql, U parameters, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult> map, string splitOn)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync(sql, map, parameters, splitOn: splitOn);

            return data.ToList();
        }
    }
    public async Task SaveData<T>(string sql, T parameters)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }

    public async Task<List<TResult>> LoadData<TFirst, TSecond, TThird, TResult>(string sql, dynamic parameters, Func<TFirst, TSecond, TThird, TResult> map, string splitOn)
{
    string connectionString = _config.GetConnectionString(ConnectionStringName);

    using (IDbConnection connection = new SqlConnection(connectionString))
    {
        var data = await connection.QueryAsync<TFirst, TSecond, TThird, TResult>(sql, map, (object)parameters, splitOn: splitOn);

        return data.ToList();
    }
}
}

