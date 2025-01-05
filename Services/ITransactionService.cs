using marpha.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marpha.Services
{
    public interface ITransactionService
    {
        Task<bool> AddTransactionAsync(Transaction transaction);
        Task SaveTransactionsAsync(List<Transaction> transactions);
        Task<List<Transaction>> GetAllTransactionsAsync();
        Task<int> GetTransactionsCountAsync();
        Task<List<Transaction>> GetTransactionByTypeAsync(string transactionType);
        Task<decimal> GetTotalTransactionByTypeAsync(string transactionType);

    }
}
