using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Domain.core;

namespace Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IVentaService" en el código y en el archivo de configuración a la vez.
    public interface IVentaService
    {
        [OperationContract]
        List<DataRow> GetProductos();

        [OperationContract]
        List<DataRow> GetClientes();
 
        [OperationContract]
        bool GuardarComprobante(Venta vta);
    }
}
