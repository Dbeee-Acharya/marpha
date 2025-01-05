using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using marpha.Data;


namespace marpha.Services
{
    internal class DebtService : IDebtService
    {
        private readonly string debts_file_path = Path.Combine(AppContext.BaseDirectory, "DebtDetails.json");
        public async Task<bool> AddDebtAsync(Debt debt)
        {
            try
            {
                var debts = await GetAllDebtsAsync();
                if (debts.Any(t => t.DebtId == debt.DebtId))
                {
                    return false;
                }

                debts.Add(debt);
                await SaveDebtsAsync(debts);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBT ADDING ERROR: {ex.Message}");
                return false;
            }
        }
        public async Task SaveDebtsAsync(List<Debt> debts)
        {
            var json = JsonSerializer.Serialize(debts);
            await File.WriteAllTextAsync(debts_file_path, json);
        }
        public async Task<List<Debt>> GetAllDebtsAsync()
        {
            var debts = new List<Debt>();

            if (!File.Exists(debts_file_path))
            {
                return debts;
            }

            var json = await File.ReadAllTextAsync(debts_file_path);
            return string.IsNullOrEmpty(json) ? debts : JsonSerializer.Deserialize<List<Debt>>(json) ?? debts;
        }
        public async Task<int> GetDebtsCountAsync()
        {
            var debts = await GetAllDebtsAsync();
            return debts.Any() ? debts.Max(u => u.DebtId) + 1 : 1;
        }

        public async Task<decimal> GetTotalDebtAsync()
        {
            var debts = await GetAllDebtsAsync();

            if(!debts.Any()) return 0;

            var sum = debts
                .Sum(d => d.DebtAmount);

            return sum;
        }
    }
}
