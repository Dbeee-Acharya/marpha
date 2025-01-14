using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marpha.Data;

namespace marpha.Services
{
    public class DebtFilterService : IDebtFilterService
    {
        public List<Debt> FilterByDate(List<Debt> debts, DateTime startDate, DateTime endDate)
        {
            return debts.Where(t => t.DebtDate >= startDate && t.DebtDate <= endDate).ToList();
        }
        public List<Debt> FilterByName(List<Debt> debts, string name)
        {
            return debts.Where(t => t.DebtName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Debt> FilterByCategory(List<Debt> debts, string category)
        {
            return debts
       .Where(t => t.DebtSource != null &&
                   t.DebtSource.Equals(category, StringComparison.OrdinalIgnoreCase))
       .ToList();
        }
        public List<Debt> SortByDate(List<Debt> debts, bool ascending = true)
        {
            return ascending
                ? debts.OrderBy(t => t.DebtDate).ToList()
                : debts.OrderByDescending(t => t.DebtDate).ToList();
        }
        public List<Debt> SortByAmount(List<Debt> debts, bool ascending = true)
        {
            return ascending
                ? debts.OrderBy(t => t.DebtAmount).ToList()
                : debts.OrderByDescending(t => t.DebtAmount).ToList();
        }
    }
}
