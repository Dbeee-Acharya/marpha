using marpha.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marpha.Services
{
    public interface IDebtService
    {
        event Action DebtsUpdated;
        Task<bool> AddDebtAsync(Debt debt);
        Task SaveDebtsAsync(List<Debt> debts);
        Task<List<Debt>> GetAllDebtsAsync();
        Task<int> GetDebtsCountAsync();
        Task<decimal> GetTotalDebtAsync();
        Task<bool> DeleteDebtAsync(int debtId);
        Task<bool> PayDebtAsync(Debt debt, decimal totalIncome, decimal payingAmount);
    }
}
