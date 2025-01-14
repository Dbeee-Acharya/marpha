using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marpha.Data;

namespace marpha.Services
{
    public interface IDebtFilterService
    {
        List<Debt> FilterByDate(List<Debt> debts, DateTime startDate, DateTime endDate);
        List<Debt> FilterByName(List<Debt> debts, string name);
        List<Debt> FilterByCategory(List<Debt> debts, string category);
        List<Debt> SortByDate(List<Debt> debts, bool ascending = true);
        List<Debt> SortByAmount(List<Debt> debts, bool ascending = true);
    }
}
