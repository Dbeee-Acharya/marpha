using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marpha.Data
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string TransactionName { get; set; }
        public string TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }

    }
}
