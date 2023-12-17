using MVCBank.Models;
using System.Net.Http;
using System.Security.Principal;

namespace MVCBank.Servicios
{
    public class Servicio_API_Transferencia : IServicio_API_Transferencia
    {
        public HttpClient client;
        public static string _baseUrl;

        public Servicio_API_Transferencia()
        {
            client = new HttpClient();
            _baseUrl = "https://apibankservice20231127083449.azurewebsites.net/";
            client.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<bool> Editar(Transferencia transfer)
        {
            var response = await client.PutAsJsonAsync($"/api/Transferencia/{transfer.IdTransfer}", transfer);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Eliminar(int IdTransfer)
        {
            var response = await client.DeleteAsync($"/api/Transferencia/{IdTransfer}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Crear(Transferencia transfer)
        {
            var response = await client.PostAsJsonAsync($"/api/Transferencia", transfer);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Transferencia>> Lista()
        {
            List<Transferencia>? lista = new List<Transferencia>();
            HttpResponseMessage response = await client.GetAsync($"/api/Transferencia");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<Transferencia>>();
            }

            return lista;
        }

        public async Task<Transferencia> Obtener(int IdTransfer)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/Transferencia/{IdTransfer}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Transferencia>();
            }

            return null;
        }

        public async Task<List<Transferencia>> Transferencias(int IdReSe)
        {
            List<Transferencia>? lista = new List<Transferencia>();
            HttpResponseMessage response = await client.GetAsync($"/api/Transferencia/{IdReSe}/{IdReSe}");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<Transferencia>>();
            }

            return lista;
        }
    }
}
