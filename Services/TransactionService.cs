using marpha.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace marpha.Services
{
    internal class TransactionService : ITransactionService
    {
        private readonly string transactions_file_path = Path.Combine(AppContext.BaseDirectory, "TransactionDetails.json");
        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            try
            {
                var transactions = await GetAllTransactionsAsync();
                if (transactions.Any(t => t.TransactionId == transaction.TransactionId))
                {
                    return false;
                }

                transactions.Add(transaction);
                await SaveTransactionsAsync(transactions);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TRANSACTION ADDING ERROR: {ex.Message}");
                return false;
            }
        }
        public async Task<List<Transaction>> GetAllTransactionsAsync()
        {
            var transactions = new List<Transaction>();

            if (!File.Exists(transactions_file_path))
            {
                return transactions;
            }

            var json = await File.ReadAllTextAsync(transactions_file_path);
            return string.IsNullOrEmpty(json) ? transactions : JsonSerializer.Deserialize<List<Transaction>>(json) ?? transactions;
        }
        public async Task<int> GetTransactionsCountAsync()
        {
            var transactions = await GetAllTransactionsAsync();
            return transactions.Any() ? transactions.Max(u => u.TransactionId) + 1 : 1;
        }
        public async Task SaveTransactionsAsync(List<Transaction> transactions)
        {
            var json = JsonSerializer.Serialize(transactions);
            await File.WriteAllTextAsync(transactions_file_path, json);
        }
    }
}
