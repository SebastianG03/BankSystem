using APIBankService.Data;
using APIBankService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBankService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public TransferenciaController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Transferencia> Transferencia = await _db.transferencia.ToListAsync();
            return Ok(Transferencia);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{IdTransfer}")]
        public async Task<IActionResult> Get(int IdTransfer)
        {
            Transferencia transf = await _db.transferencia.FirstOrDefaultAsync(x => x.IdTransfer == IdTransfer);
            if (transf == null)
            {
                return BadRequest();
            }
            return Ok(transf);
        }

        [HttpGet("{IdAccountSender}/{IdAccountReceiver}")]
        public async Task<IActionResult> Get(int IdAccountSender, int IdAccountReceiver)
        {
            List<Transferencia> transf = await _db.transferencia
                .Where(x => x.IdAccountSender == IdAccountSender || x.IdAccountReceiver == IdAccountReceiver)
                .ToListAsync();
            if (transf == null)
            {
                return BadRequest();
            }
            return Ok(transf);
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transferencia transfer)
        {
            Transferencia transfer2 = await _db.transferencia.FirstOrDefaultAsync(x => x.IdTransfer == transfer.IdTransfer);

            if (transfer != null && transfer2 == null)
            {
                await _db.transferencia.AddAsync(transfer);
                await _db.SaveChangesAsync();
                return Ok(transfer.IdTransfer);
            }
            return BadRequest();
            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{IdTransfer}")]
        public async Task<IActionResult>  Put(int IdTransfer, [FromBody] Transferencia transferencia)
        {
            Transferencia existingTransferencia = await _db.transferencia.FirstOrDefaultAsync(x => x.IdTransfer == IdTransfer);

            if (existingTransferencia != null)
            {
                existingTransferencia.IdAccountSender = transferencia.IdAccountSender != 0 ? transferencia.IdAccountSender : existingTransferencia.IdAccountSender;
                existingTransferencia.IdAccountReceiver = transferencia.IdAccountReceiver != 0 ? transferencia.IdAccountReceiver : existingTransferencia.IdAccountReceiver;
                existingTransferencia.Amount = transferencia.Amount != 0 ? transferencia.Amount : existingTransferencia.Amount;
                existingTransferencia.DateIssue = transferencia.DateIssue != DateTime.MinValue ? transferencia.DateIssue : existingTransferencia.DateIssue;

                _db.transferencia.Update(existingTransferencia);
                await _db.SaveChangesAsync();
                return Ok(existingTransferencia);
            }
            return BadRequest("No se encuentra la cuenta");

        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{IdTransfer}")]
        public async Task<IActionResult> Delete(int IdTransfer)
        {
            Transferencia transfer = await _db.transferencia.FirstOrDefaultAsync(x => x.IdTransfer == IdTransfer);

            if (transfer != null)
            {
                _db.transferencia.Remove(transfer);
                await _db.SaveChangesAsync();
                return Ok(transfer);
            }

            return BadRequest("La transferencia no se encontró");
        }

    }
}
