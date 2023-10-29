using APIBankService.Data;
using APIBankService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBankService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public BankAccountController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<BankAccount> bankAccounts = await _db.bankAccount.ToListAsync();
            return Ok(bankAccounts);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{IdAccount}")]
        public async Task<IActionResult> GetAsync(int IdAccount)
        {
            BankAccount account= await _db.bankAccount.FirstOrDefaultAsync(x => x.IdAccount == IdAccount);
            if (account == null)
            {
                return BadRequest();
            }
            return Ok(account);

        }

        [HttpGet("user/{IdUser}")]
        public async Task<IActionResult> GetUserAsync(int IdUser)
        {
            BankAccount account = await _db.bankAccount.FirstOrDefaultAsync(x => x.IdUser == IdUser);
            if (account == null)
            {
                return BadRequest();
            }
            return Ok(account);

        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult>  PostAsync([FromBody] BankAccount account)
        {
            BankAccount account2 = await _db.bankAccount.FirstOrDefaultAsync(x => x.IdAccount == account.IdAccount);

            if (account != null && account2 == null)
            {
                await _db.bankAccount.AddAsync(account);
                await _db.SaveChangesAsync();
                return Ok(account.IdAccount);
            }
            return BadRequest();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{IdAccount}")]
        public async Task<IActionResult> Put(int IdAccount, [FromBody] BankAccount account)
        {
            BankAccount account1 = await _db.bankAccount.FirstOrDefaultAsync(x => x.IdAccount == IdAccount);
            if (account1 != null)
            {
                account1.IdAccount = account.IdAccount != null ? account.IdAccount : account1.IdAccount;
                account1.IdUser = account.IdUser != null ? account.IdUser : account1.IdUser;
                account1.AccountNumber = account.AccountNumber != null ? account.AccountNumber : account1.IdAccount;
                account1.AccountAmount = account.AccountAmount != null ? account.AccountAmount : account1.IdAccount;
                _db.bankAccount.Update(account1);
                await _db.SaveChangesAsync();
                return Ok(account1);
            }
            return BadRequest("No se encuentra la cuenta");

        }

        [HttpPut("user/{IdAccount}")]
        public async Task<IActionResult> Put(int IdAccount, [FromBody] float AccountAmount)
        {
            BankAccount account1 = await _db.bankAccount.FirstOrDefaultAsync(x => x.IdAccount == IdAccount);
            if (account1 != null)
            {

                account1.AccountAmount = AccountAmount;
                _db.bankAccount.Update(account1);
                await _db.SaveChangesAsync();
                return Ok(account1);
            }
            return BadRequest("No se encuentra la cuenta");

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{IdAccount}")]
        public async Task<IActionResult> DeleteAsync(int IdAccount)
        {
            BankAccount account1 = await _db.bankAccount.FirstOrDefaultAsync(x => x.IdAccount == IdAccount);
            if (account1 != null)
            {
                _db.bankAccount.Remove(account1);
                await _db.SaveChangesAsync();
                return Ok(account1);
            }
            return BadRequest();
                    
        }
    }
}
