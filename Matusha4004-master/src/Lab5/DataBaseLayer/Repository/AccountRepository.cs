using Itmo.Dev.Platform.Postgres.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Core.Model;
using Itmo.ObjectOrientedProgramming.Lab5.Core.Repositories;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.DataBaseLayer.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly string _connectionString;

    public AccountRepository(PostgresConnectionConfiguration configuration)
    {
        _connectionString = configuration.ToConnectionString();
    }

    public Account? GetAccount(string number, string pin)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(
            $"SELECT id, number, balance, pin FROM accounts WHERE number = @number AND pin = @pin",
            connection);

        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("pin", pin);

        using NpgsqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Account(reader.GetGuid(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3));
        }

        return null;
    }

    public void AddAccount(Account account)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(
            $"INSERT INTO accounts (id, number, balance, pin) VALUES (@id, @number, @balance, @pin)", connection);

        command.Parameters.AddWithValue("id", account.Id);
        command.Parameters.AddWithValue("number", account.Number);
        command.Parameters.AddWithValue("balance", account.Balance);
        command.Parameters.AddWithValue("pin", account.Pin);

        command.ExecuteNonQuery();
    }

    public void UpdateAccount(Account account)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(
            $"UPDATE accounts SET balance = @balance WHERE id = @id", connection);

        command.Parameters.AddWithValue("balance", account.Balance);
        command.Parameters.AddWithValue("id", account.Id);

        command.ExecuteNonQuery();
    }
}