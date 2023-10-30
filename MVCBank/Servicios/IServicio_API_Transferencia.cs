using MVCBank.Models;

namespace MVCBank.Servicios
{
    public interface IServicio_API_Transferencia
    {
        Task<List<Transferencia>> Lista();
        Task<Transferencia> Obtener(int IdTransfer);
        Task<List<Transferencia>> Transferencias(int IdTransfer);
        Task<bool> Crear(Transferencia transfer);
        Task<bool> Editar(Transferencia transfer);
        Task<bool> Eliminar(int IdTransfer);
    }
}
