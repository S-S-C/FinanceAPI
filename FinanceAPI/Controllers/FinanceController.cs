using FinanceAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;



namespace FinanceAPI.Controllers
{
    [RoutePrefix("Api/FinancePortal")]
    public class FinanceController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //----------------------------------------------------------------------//

        /// <summary>
        /// Get Accounts By Household Id
        /// </summary>
        /// <param name="householdId">The Household Primary Key</param>
        /// <returns></returns>
        [Route("Accounts")]
        public async Task<List<PersonalAccount>> GetAccountsByHousehold(int householdId)
        {
            return await db.GetAccountsByHousehold(householdId);
        }

        /// <summary>
        /// Get Accounts data (as JSON) by Household Id
        /// </summary>
        /// <param name="householdId">PK of Household</param>
        /// <returns></returns>
        [Route("Accounts/json")]
        public async Task<IHttpActionResult> GetAccountsJson(int householdId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAccountsByHousehold(householdId));
            return Ok(json);
        }
             
        /// <summary>
        /// Get AccountBalance
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("AccountBalance")]
        public async Task<PersonalAccount> GetAccountsBalance(int householdId)
        {
            return await db.GetAccountsBalance(householdId);
        }

        /// <summary>
        /// Get AccountDetails
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("AccountDetails")]
        public async Task<PersonalAccount> GetAccountDetails(int accountId,int householdId )
        {
            return await db.AccountDetails( accountId, householdId);
        }

        /// <summary>
        /// Get Transactions
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("Transactions")]
        public async Task<List<Transaction>> GetTransactions(int householdId, int accountId)
        {
            return await db.GetTransactions(householdId, accountId);
        }

        /// <summary>
        /// Get Transaction Details
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("TransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int accountId, int transactionId)
        {
            return await db.GetTransactionDetails(accountId, transactionId);
        }

        /// <summary>
        /// Get Household
        /// </summary>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("Household")]
        public async Task<List<Household>> GetHousehold(int householdId)
        {
            return await db.GetHousehold(householdId);
        }


        /// <summary>
        /// Get Budget Details
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="householdId"></param>
        /// <returns></returns>
        [Route("BudgetDetails")]
        public async Task<Budget> GetBudgetDetails(int budgetId, int householdId)
        {
            return await db.GetBudgetDetails(budgetId, householdId);
        }

        /// <summary>
        /// Get Budgets
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        [Route("Budget")]
        public async Task<List<Budget>> GetBudgets(int householdId, int budgetId)
        {
            return await db.GetBudgets(householdId, budgetId);
        }

        /// <summary>
        /// Get Budget Balance
        /// </summary>
        /// <param name="householdId"></param>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        [Route("BudgetBalance")]
        public async Task<List<Budget>> GetBudgetBalance(int householdId, int budgetId)
        {
            return await db.GetBudgetBalance(householdId, budgetId);
        }

        //public async Task<List<BudgetsBalance>> GetBudgetBalance(int householdId, int budgetId)
        //{
        //    return await db.GetBudgetBalance(householdId, budgetId);
        //}


        /// <summary>
        /// Add Account
        /// </summary>
        /// <param name="hhId"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        /// <param name="userId"></param>
        /// <param name="recbalance"></param>
        /// <param name="isdeleted"></param>
        /// <returns></returns>
        [Route("AddAccount")]
        public IHttpActionResult AddAccount(int hhId, string name, decimal balance, string userId, decimal recbalance, bool isdeleted)
        {
            return Ok(db.AddAccount(hhId, name, balance, userId, recbalance, isdeleted));
        }

        /// <summary>
        /// Add Budget
        /// </summary>
        /// <param name="hhId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("AddBudget")]
        public IHttpActionResult AddBudget(int hhId, string name)
        {
            return Ok(db.AddBudget(hhId, name));
        }

        /// <summary>
        /// Add Transaction
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="description"></param>
        /// <param name="amount"></param>
        /// <param name="trxType"></param>
        /// <param name="isVoid"></param>
        /// <param name="categoryId"></param>
        /// <param name="userId"></param>
        /// <param name="reconciled"></param>
        /// <param name="recBalance"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        [Route("AddTransaction")]
        public IHttpActionResult AddTransaction(int accountId, string description, decimal amount, bool trxType, bool isVoid, int categoryId, string userId, bool reconciled, decimal recBalance, bool isDeleted)
        {
            return Ok(db.AddTransaction(accountId, description, amount, trxType, isVoid, categoryId, userId, reconciled, recBalance, isDeleted));
        }

        /// <summary>
        /// Create Household
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("CreateHousehold")]
        public IHttpActionResult CreateHousehold(string name)
        {
            return Ok(db.CreateHousehold(name));
        }


        // GET: Finance
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}