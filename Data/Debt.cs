using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marpha.Data
{
    public class Debt
    {
        public int DebtId { get; set; }
        public string DebtName { get; set; }
        public string DebtDescription { get; set; }
        public double PrincipleAmount { get; set; }
        public double DebtAmount { get; set; }
        public DateTime DebtDate { get; set; }
        public DateTime DebtDueDate { get; set; }
        public string DebtStatus { get; set; }
    }
}
