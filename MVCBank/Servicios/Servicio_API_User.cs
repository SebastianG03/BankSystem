using MVCBank.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BankSystem.Web.Servicios
{
    public class Servicio_API_User : IServicio_API_User
    
    {
        public static string port = "5142";
        public HttpClient client;
        public static string _baseUrl;

        public Servicio_API_User()
        {
            client = new HttpClient();
            _baseUrl = "https://apibankservice20231127083449.azurewebsites.net/";
            client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<User> Autenticar(string Email, string Password)
        {
            User user = null;
            var response = await client.GetAsync($"/api/User/{Email}/{Password}");

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
                Console.WriteLine(user);
            }
            return user;
        }

        public async Task<int> Crear(User user)
            
        {
            int indice = 0;
            var response = await client.PostAsJsonAsync("/api/User", user);
            indice = await response.Content.ReadAsAsync<int>();
            Console.WriteLine(indice);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(indice);
                return indice;
            }
            return indice;
        }
        

        public async Task<bool> Eliminar(User user)
        {
            HttpResponseMessage response = await client.DeleteAsync($"/api/User/{user.IdUser}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Guardar(User user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"/api/User/{user.IdUser}", user);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>> Lista()
        {
            List<User> lista = new List<User>();
            HttpResponseMessage response = await client.GetAsync($"/api/User");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<User>>();
            }

            return lista;
        }

        public async Task<User> Obtener(int IdUser)
        {
            User user = null;
            HttpResponseMessage response = await client.GetAsync($"/api/User/{IdUser}");

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }

            return user;
        }
    }
}