using PruebaMVC.Dominio.Modelos;
using PruebaMVC.Servicios.Interfaces;
using System;
using System.Collections.Generic;

namespace PruebaMVC.Servicios
{
    public class CompradoresServicio
    {
        private ICompradoresRepositorio _repositorio;

        public CompradoresServicio(ICompradoresRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void AnadirComprador(AnadirCompradorModel model)
        {
            _repositorio.AnadirComprador(model.Nombre, model.PrimerApellido, model.SegundoApellido);
        }

        public void EditarComprador(EditarCompradorModel model)
        {
            _repositorio.EditarComprador(model.Id, model.Nombre, model.PrimerApellido, model.SegundoApellido);
        }

        public (IEnumerable<CompradorParaListadoModel>, int) ObtenerListado(string busqueda = null, int numPagina = 1, int tamanoPagina = 10)
        {
            var listado = _repositorio.ObtenerListado(busqueda, numPagina, tamanoPagina);
            var count = _repositorio.CountCompradores(busqueda);
            return (listado, count);
        }

        public void EliminarComprador(Guid idComprador)
        {
            _repositorio.EliminarComprador(idComprador);
        }

        public CompradorDetalleModel ObtenerDetallesComprador(Guid idComprador)
        {
            return _repositorio.ObtenerDetallesComprador(idComprador);
        }
    }
}
