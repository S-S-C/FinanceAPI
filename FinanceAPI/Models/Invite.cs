using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceAPI.Models
{
    public class Invite
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Email { get; set; }
        public Guid HHToken { get; set; }
        public DateTimeOffset InviteDate { get; set; }
        public string InvitedById { get; set; }
        public bool HasBeenUsed { get; set; }
    }
}