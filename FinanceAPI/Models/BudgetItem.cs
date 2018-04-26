using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceAPI.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BudgetId { get; set; }
        public decimal Amount { get; set; }
    }
}