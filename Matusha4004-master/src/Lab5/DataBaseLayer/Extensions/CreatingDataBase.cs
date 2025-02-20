using Itmo.Dev.Platform.Postgres.Models;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.DataBaseLayer.Extensions;

public class CreatingDataBase
{
    private readonly string _connectionString;

    public CreatingDataBase(PostgresConnectionConfiguration configuration)
    {
        _connectionString = configuration.ToConnectionString();
    }

    public void InitializeDatabase()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using (var command = new NpgsqlCommand(
                   @"CREATE TABLE IF NOT EXISTS accounts (
                 id UUID PRIMARY KEY,
                number VARCHAR(50) NOT NULL UNIQUE,
                balance DECIMAL(18, 2) NOT NULL,
                pin VARCHAR(50) NOT NULL
            );",
                   connection))
        {
            command.ExecuteNonQuery();
        }

        using (var command = new NpgsqlCommand(
                   @"CREATE TABLE IF NOT EXISTS transactions (
                id UUID PRIMARY KEY,
                account_id UUID NOT NULL,
                amount DECIMAL(18, 2) NOT NULL,
                type VARCHAR(50) NOT NULL,
                FOREIGN KEY (account_id) REFERENCES accounts(id)
            );",
                   connection))
        {
            command.ExecuteNonQuery();
        }
    }
}