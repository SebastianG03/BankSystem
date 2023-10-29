using MVCBank.Models;
using System.Security.Principal;

namespace MVCBank.Servicios
{
    public class Servicio_API_Transferencia : IServicio_API_Transferencia
    {
        public static string port = "5142";
        public async Task<bool> Editar(Transferencia transfer)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync($"http://localhost:{port}/api/Transferencia/{transfer.IdTransfer}", transfer);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Eliminar(int IdTransfer)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync($"http://localhost:{port}/api/Transferencia/{IdTransfer}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Crear(Transferencia transfer)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync($"http://localhost:5142/api/Transferencia", transfer);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Transferencia>> Lista()
        {
            List<Transferencia>? lista = new List<Transferencia>();
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:{port}/api/Transferencia");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<Transferencia>>();
            }

            return lista;
        }

        public async Task<Transferencia> Obtener(int IdTransfer)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:{port}/api/Transferencia/{IdTransfer}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Transferencia>();
            }

            return null;
        }

        public async Task<List<Transferencia>> Transferencias(int IdReSe)
        {
            List<Transferencia>? lista = new List<Transferencia>();
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:{port}/api/Transferencia/{IdReSe}/{IdReSe}");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<Transferencia>>();
            }

            return lista;
        }
    }
}
