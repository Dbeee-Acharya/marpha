using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marpha.Data;

namespace marpha.Services
{
    public interface IFilterService
    {
        List<Transaction> FilterByDate(List<Transaction> transactions, DateTime startDate, DateTime endDate);
        List<Transaction> FilterByName(List<Transaction> transactions, string name);
        List<Transaction> FilterByCategory(List<Transaction> transactions, string category);
        List<Transaction> SortByDate(List<Transaction> transactions, bool ascending = true);
        List<Transaction> SortByAmount(List<Transaction> transactions, bool ascending = true);
    }
}
