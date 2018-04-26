using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceAPI.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BudgetBalance { get; set; }
        public int HouseholdId { get; set; }
    }
}