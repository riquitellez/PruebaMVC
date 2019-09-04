using PruebaMVC.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMVC.Servicios.Interfaces
{
    public interface ICompradoresRepositorio
    {
        void AnadirComprador(string nombre, string primerApellido, string segundoApellido);

        void EditarComprador(Guid id, string nombre, string primerApellido, string segundoApellido);

        void EliminarComprador(Guid id);

        CompradorDetalleModel ObtenerDetallesComprador(Guid id);
        IEnumerable<CompradorParaListadoModel> ObtenerListado(string busqueda, int numPagina, int tamanoPagina);
        int CountCompradores(string busqueda);
    }
}
