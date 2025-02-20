using Itmo.Dev.Platform.Postgres.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Core.Model;
using Itmo.ObjectOrientedProgramming.Lab5.Core.Repositories;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.DataBaseLayer.Repository;

public class TransitionRepository : ITransitionRepository
{
    private readonly string _connectionString;

    public TransitionRepository(PostgresConnectionConfiguration configuration)
    {
        _connectionString = configuration.ToConnectionString();
    }

    public void AddTransaction(TransitionOperation transaction)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(
            $"INSERT INTO transactions (id, account_id, amount, type) VALUES (@id, @accountId, @amount, @type)", connection);
        command.Parameters.AddWithValue("id", transaction.Id);
        command.Parameters.AddWithValue("accountId", transaction.AccountId);
        command.Parameters.AddWithValue("amount", transaction.Amount);
        command.Parameters.AddWithValue("type", transaction.Type);

        command.ExecuteNonQuery();
    }

    public IEnumerable<TransitionOperation> GetTransactions(Guid accountId)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(
            $"SELECT id, account_id, amount, type FROM transactions WHERE account_id = @accountId", connection);
        command.Parameters.AddWithValue("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        var transactions = new List<TransitionOperation>();

        while (reader.Read())
        {
            transactions.Add(new TransitionOperation(
                reader.GetGuid(0),
                reader.GetGuid(1),
                reader.GetDecimal(2),
                reader.GetString(3)));
        }

        return transactions;
    }
}