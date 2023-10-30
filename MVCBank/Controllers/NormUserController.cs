using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBank.Models;
using BankSystem.Web.Servicios;
using MVCBank.Servicios;
using System.Runtime.CompilerServices;

namespace MVCBank.Controllers
{
    public class NormUserController : Controller
    {
        private readonly IServicio_API_User servicioAPI;
        private readonly IServicio_API_BAccount servicio_APIBAccount;
        private readonly IServicio_API_Transferencia transferenciaAPI;
        public NormUserController(IServicio_API_User servicioAPI, IServicio_API_BAccount servicio_APIBAccount, IServicio_API_Transferencia transferenciaAPI)
        {
            this.servicioAPI = servicioAPI;
            this.servicio_APIBAccount = servicio_APIBAccount;
            this.transferenciaAPI = transferenciaAPI;

        }

        // GET: NormUserController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Email, string Password)

        {
            
            var response = await servicioAPI.Autenticar(Email, Password);
            Console.WriteLine("hola " + response?.IdUser);

            if (response != null)
            {
                if (response.Role.Equals("client"))
                {
                    var response2 = await servicio_APIBAccount.GetIdUser((int)(response?.IdUser));
                    Console.WriteLine("Resp" + response2?.IdUser);
                    return View("Details", response2);
                }
                else
                {
                    return RedirectToAction("Index", "Admin", response);
                }



            }
            return View();
        }

        // GET: NormUserController/Details/5
        public IActionResult Details(BankAccount account)
        {
            if (account != null)
            {
                Console.WriteLine("con" + account.IdUser);
                return View(account);
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DetailsBack(int IdAccount)
        {

            var account = await servicio_APIBAccount.Obtener(IdAccount);
            if (account != null)
            {
                Console.WriteLine("con" + account.IdUser);
                return View("Details", account);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            user.IdUser = 0;
            user.Phone = "strddsfasd";
            user.DNI = "strdddd";
            user.Name = "strsssds";

            user.Role = user.Role.Equals("Cliente") ? "client" : "adm";

            var response = await servicioAPI.Crear(user);

            Console.WriteLine(user.Password + "hola");
            if (response != 0)
            {
                BankAccount account = new BankAccount();
                var lista = await servicio_APIBAccount.Lista();
                account.AccountNumber = lista.Count + 1;
                account.AccountAmount = 0;
                account.IdUser = response;
                var response2 = await servicio_APIBAccount.Guardar(account);

            return View("Index");

            } 
                
            return View();

        }

 

        
        public async Task<ActionResult> Edit(int IdAccount)
        {

            var response = await servicio_APIBAccount.Obtener(IdAccount);
            Console.WriteLine("hola" + response?.IdUser);
            if (response?.IdUser != 0)
            {
                Transferencia transfer = new Transferencia() { Amount = 0, IdAccountSender = response.IdAccount, IdAccountReceiver = 0 };

                return View("Edit", transfer);


            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Transferencia transfer)

        {
            Transferencia transfer1=null;
            if (transfer != null)
            {

                transfer.IdTransfer = 0;
                transfer.DateIssue = DateTime.Now;
                BankAccount accountSender = await servicio_APIBAccount.Obtener(transfer.IdAccountSender);
                BankAccount accountReceiver = await servicio_APIBAccount.Obtener(transfer.IdAccountReceiver);
                Console.WriteLine(transfer.ToString + "accountS");
                Console.WriteLine(accountSender.AccountAmount +"accountS");
                Console.WriteLine(accountReceiver.AccountAmount + "accountR");
                if (accountReceiver != null)
                {
                    transfer1 = transfer;
                    bool trans=true;
                    BankAccount test = await servicio_APIBAccount.EditarCantidad(accountSender.IdAccount, accountReceiver.AccountAmount + transfer.Amount);
                    BankAccount test2 = await servicio_APIBAccount.EditarCantidad(accountSender.IdAccount, accountSender.AccountAmount - transfer.Amount);
                    await transferenciaAPI.Crear(transfer);
                    Console.WriteLine(test.AccountAmount + "Test");
                    Console.WriteLine(test2.AccountAmount + "Test");
                    Console.WriteLine("Transferencia emitida: ");
                }

                Console.WriteLine("Transferencia realizandose..." + accountReceiver.AccountAmount);
                //await servicio_APIBAccount.Editar(accountSender);
                bool success = await servicio_APIBAccount.Editar(accountReceiver);
                Console.WriteLine("Transferencia realizada..." + success);

                return View("Details", accountSender);
            }
            Console.WriteLine("Operacion fallida");
            return BadRequest("No se pudo realizar la accion");
        }

        // GET: NormUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // Transferencia
        public async Task<IActionResult> Transferencias(int IdAccount)
        {
            List<Transferencia> transfer = await transferenciaAPI.Transferencias(IdAccount);
            ViewData["IdAccount"] = IdAccount;
            return View("Transferencias", transfer);

        }
        // POST: NormUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
