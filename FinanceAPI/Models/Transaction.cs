using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = "Credit")]
        public bool Type { get; set; }
        public bool Void { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Entered By")]
        public string EnteredById { get; set; }
        public bool Reconciled { get; set; }
        public decimal ReconciledAmount { get; set; }
        public bool IsDeleted { get; set; }
    }
}