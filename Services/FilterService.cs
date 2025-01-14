using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marpha.Data;

namespace marpha.Services
{
    public class FilterService : IFilterService
    {
        public List<Transaction> FilterByDate(List<Transaction> transactions, DateTime startDate, DateTime endDate)
        {
            return transactions.Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate).ToList();
        }
        public List<Transaction> FilterByName(List<Transaction> transactions, string name)
        {
            return transactions.Where(t => t.TransactionName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Transaction> FilterByCategory(List<Transaction> transactions, string category)
        {
            return transactions
       .Where(t => t.TransactionCategory != null &&
                   t.TransactionCategory.Equals(category, StringComparison.OrdinalIgnoreCase))
       .ToList();
        }
        public List<Transaction> SortByDate(List<Transaction> transactions, bool ascending = true)
        {
            return ascending
                ? transactions.OrderBy(t => t.TransactionDate).ToList()
                : transactions.OrderByDescending(t => t.TransactionDate).ToList();
        }
        public List<Transaction> SortByAmount(List<Transaction> transactions, bool ascending = true)
        {
            return ascending
                ? transactions.OrderBy(t => t.TransactionAmount).ToList()
                : transactions.OrderByDescending(t => t.TransactionAmount).ToList();
        }

    }
}
