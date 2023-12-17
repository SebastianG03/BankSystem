using MVCBank.Models;
using System.Net.Http;
using System.Security.Principal;

namespace BankSystem.Web.Servicios
{
    public class Servicio_API_BAccount : IServicio_API_BAccount
    {
        public static string _baseUrl;
        public HttpClient client;

        public Servicio_API_BAccount()
        {
            _baseUrl = "https://apibankservice20231127083449.azurewebsites.net/";
            client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<List<BankAccount>> Lista()
        {
            List<BankAccount>? lista = new List<BankAccount>();
            
            HttpResponseMessage response = await client.GetAsync($"/api/BankAccount");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<BankAccount>>();
            }

            return lista;
        }

        public async Task<bool> Editar(BankAccount account)
        {

            var response = await client.PutAsJsonAsync($"/api/BankAccount/{account.IdAccount}", account);

            return response.IsSuccessStatusCode;
        }

        

        public async Task<bool> Guardar(BankAccount account)
        {
            var response = await client.PostAsJsonAsync($"/api/BankAccount", account);

            return response.IsSuccessStatusCode;
        }

        public async Task<BankAccount> Obtener(int IdAccount)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/BankAccount/{IdAccount}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<BankAccount>();
            }

            return null;
        }
        public async Task<bool> Eliminar(int IdAccount)
        {

            var response = await client.DeleteAsync($"/api/BankAccount/{IdAccount}");
            return response.IsSuccessStatusCode;
        }

        public async Task<BankAccount> GetIdUser(int IdUser)
        {
            BankAccount account = null;

            HttpResponseMessage response = await client.GetAsync($"/api/BankAccount/user/{IdUser}");

            if (response.IsSuccessStatusCode)
            {
                account =await response.Content.ReadAsAsync<BankAccount>();
                
                Console.WriteLine("co" + account.IdUser);
                return account;
            }

            return null;
        }

        public async Task<BankAccount> EditarCantidad(int IdUser, float AccounAmount)
        {
            BankAccount account = null;
            HttpResponseMessage response = await client.PutAsJsonAsync($"/api/BankAccount/user/{IdUser}", AccounAmount);
            if (response.IsSuccessStatusCode)
            {
                account = await response.Content.ReadAsAsync<BankAccount>();

                Console.WriteLine("co" + account.IdUser);
                return account;
            }

            return null;
        }

    }
    


}