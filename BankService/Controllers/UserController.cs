using APIBankService.Data;
using APIBankService.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBankService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> users = await _db.user.ToListAsync();
            return Ok(users);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{IdUser}")]
        public async Task<IActionResult> Get(int IdUser)
        {
            User user = await _db.user.FirstOrDefaultAsync(x => x.IdUser == IdUser);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);

        }



        [HttpGet("{Email}/{Password}")]
        public async Task<IActionResult> Get(string Email, string Password)
        {
            User user = await _db.user.FirstOrDefaultAsync(x => x.Email == Email && x.Password == Password);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            User user2 = await _db.user.FirstOrDefaultAsync(x => x.IdUser == user.IdUser);

            if (user != null && user2 == null)
            {
                await _db.user.AddAsync(user);
                await _db.SaveChangesAsync();
                return Ok(user.IdUser);
            }
            return BadRequest();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{IdUser}")]
        public async Task<IActionResult> Put(int IdUser, [FromBody] User user)
        {
            User user2 = await _db.user.FirstOrDefaultAsync(x => x.IdUser == IdUser);
            if(user2 != null)
            {
                user2.IdUser = user.IdUser != null ? user.IdUser : user2.IdUser;
                user2.Name = user.Name != null ? user.Name : user2.Name;
                user2.Email = user.Email != null ? user.Email : user2.Email;
                user2.Password = user.Password != null ? user.Password : user2.Password;
                user2.Phone = user.Phone != null ? user.Phone : user2.Phone;
                user2.Role = user.Role != null ? user.Role : user2.Role;
                user2.DNI = user.DNI != null ? user.DNI : user2.DNI;
                _db.user.Update(user2);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("El producto no se encuentra");



        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{IdUser}")]
        public async Task<IActionResult> Delete(int IdUser)
        {
            User user = await _db.user.FirstOrDefaultAsync(x => x.IdUser == IdUser);
            if (user != null)
            {
                _db.user.Remove(user);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
