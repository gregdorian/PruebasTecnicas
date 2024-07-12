using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public abstract class Repository<T> where T : class
{
    private readonly string _connectionString;

    protected Repository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public virtual T GetById(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand($"SELECT * FROM {GetTableName()} WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return MapToEntity(reader);
                }
                return null;
            }
        }
    }

    public virtual IEnumerable<T> GetAll()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand($"SELECT * FROM {GetTableName()}", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return MapToEntity(reader);
                }
            }
        }
    }

    public virtual void Add(T entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand($"INSERT INTO {GetTableName()} ({GetColumnNames()}) VALUES ({GetParameterNames()})", connection);
            foreach (var property in typeof(T).GetProperties())
            {
                command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity));
            }
            command.ExecuteNonQuery();
        }
    }

    public virtual void Update(T entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand($"UPDATE {GetTableName()} SET {GetUpdateColumnNames()} WHERE Id = @Id", connection);
            foreach (var property in typeof(T).GetProperties())
            {
                command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity));
            }
            command.Parameters.AddWithValue("@Id", entity.GetType().GetProperty("Id").GetValue(entity));
            command.ExecuteNonQuery();
        }
    }

    public virtual void Delete(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand($"DELETE FROM {GetTableName()} WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }

    protected abstract string GetTableName();
    protected abstract string GetColumnNames();
    protected abstract string GetParameterNames();
    protected abstract string GetUpdateColumnNames();
    protected abstract T MapToEntity(IDataReader reader);
}