using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace FinanceAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       
        //public DbSet<Finance> Finance { get; set; }

        
        //Add Transaction
        public int AddTransaction(int accountId, string description, decimal amount, bool trxType, bool isVoid, int categoryId, string userId, bool reconciled, decimal recBalance, bool isDeleted)
        {
            return Database.ExecuteSqlCommand("AddTransaction @accId, @desc, @created, @amount, @type, @void, @catId, @enterbyId, @reconciled, @reconciledamt, @IsDeleted",
                new SqlParameter("accId", accountId),
                new SqlParameter("desc", description),
                new SqlParameter("created", DateTimeOffset.Now),
                new SqlParameter("amount", amount),
                new SqlParameter("type", trxType),
                new SqlParameter("void", isVoid),
                new SqlParameter("catId", categoryId),
                new SqlParameter("enterbyId", userId),
                new SqlParameter("reconciled", reconciled),
                new SqlParameter("reconciledamt", recBalance),
                new SqlParameter("IsDeleted", isDeleted));
               
        }


        //Add Budget
        public int AddBudget(int hhId, string Name)
        {
            return Database.ExecuteSqlCommand("AddBudget @hhId, @Name",
                new SqlParameter("hhId", hhId),
                new SqlParameter("Name", Name));     
        }

        //Add Account
        public int AddAccount(int hhId, string name, decimal balance, string userId, decimal recbalance, bool isdeleted)
        {
            return Database.ExecuteSqlCommand("AddAccount @hhId, @name, @balance, @userId, @recbalance, @isdeleted",
                new SqlParameter("hhId", hhId),
                new SqlParameter("name", name),
                new SqlParameter("balance", balance),
                new SqlParameter("userId", userId),
                 new SqlParameter("recbalance", recbalance),
                  new SqlParameter("isdeleted", isdeleted));

        }

        //Create Household
        public int CreateHousehold(string name)
        {
            return Database.ExecuteSqlCommand("CreateHousehold @name",
                new SqlParameter("name", name));
                
        }

        //Get AccountBalance
        public async Task<PersonalAccount> GetAccountsBalance(int hhId)
        {
            return await Database.SqlQuery<PersonalAccount>("GetAccountsBalance @hhId",
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();

        }

        //Get AccountDetails
        public async Task<PersonalAccount> AccountDetails(int accountId, int hhId)
        {
            return await Database.SqlQuery<PersonalAccount>("GetAccountDetails @AccId, @hhId",
                new SqlParameter("AccId", accountId),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();

        }

        //Get Transactions
        public async Task<List<Transaction>>GetTransactions(int accountId, int hhId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @accId, @hhId",
                new SqlParameter("accId", accountId),
                new SqlParameter("hhId", hhId)).ToListAsync();
        }

        //Get TransactionDetails
        public async Task<Transaction> GetTransactionDetails(int accountId, int transactionId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @accId, @transId",
                new SqlParameter("accId", accountId),
                new SqlParameter("transId", transactionId)).FirstOrDefaultAsync();

        }

        //Get Household
        public async Task<List<Household>> GetHousehold(int HouseholdId)
        {
            return await Database.SqlQuery<Household>("GetHousehold @hhId",
                new SqlParameter("hhId", HouseholdId)).ToListAsync();
        }

        //Get BudgetDetails
        public async Task<Budget> GetBudgetDetails(int budgetId, int householdId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @BudgetId, @hhId",
                new SqlParameter("BudgetId", budgetId),
                new SqlParameter("hhId", householdId)).FirstOrDefaultAsync();
        }

        //Get Budgets
        public async Task<List<Budget>> GetBudgets(int householdId, int budgetId)
        {
            return await Database.SqlQuery<Budget>("GetBudgets @hhId, @bId",
                new SqlParameter("hhId", householdId),
                new SqlParameter("bId", budgetId)).ToListAsync();
        }

        //Get AccountsByHousehold
        public async Task<List<PersonalAccount>> GetAccountsByHousehold(int householdId)
        {
            return await Database.SqlQuery<PersonalAccount>("GetAccountsByHousehold @hhId",
                new SqlParameter("hhId", householdId)).ToListAsync();
        }

        //GetBudgetBalance
        public async Task<List<Budget>> GetBudgetBalance(int householdId, int budgetId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetsBalance @hhId, @bgId",
                new SqlParameter("hhId", householdId),
                new SqlParameter("bgId", budgetId)).ToListAsync();
        }

        //public async Task<List<BudgetsBalance>> GetBudgetBalance(int householdId, int budgetId)
        //{
        //    return await Database.SqlQuery<BudgetsBalance>("GetBudgetsBalance @hhId, @bgId",
        //        new SqlParameter("hhId", householdId),
        //        new SqlParameter("bgId", budgetId)).ToListAsync();
        //}

    }
}