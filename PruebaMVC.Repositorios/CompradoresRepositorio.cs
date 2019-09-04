using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruebaMVC.Datos;
using PruebaMVC.Datos.Entidades;
using PruebaMVC.Dominio.Modelos;
using PruebaMVC.Servicios.Interfaces;

namespace PruebaMVC.Repositorios
{
    public class CompradoresRepositorio:ICompradoresRepositorio
    {

        private PruebaMVCContext _contexto;

        public CompradoresRepositorio(PruebaMVCContext contexto)
        {
            _contexto = contexto;
        }
        public CompradoresRepositorio()
        {
            _contexto = new PruebaMVCContext();
        }

        public void AnadirComprador(string nombre, string primerApellido, string segundoApellido)
        {
            var comprador = new Comprador(nombre, primerApellido, segundoApellido);
            _contexto.Add(comprador);
            _contexto.SaveChanges();
        }

        public void EditarComprador(Guid id, string nombre, string primerApellido, string segundoApellido)
        {
            var comprador = _contexto.Compradores.Find(id);
            comprador.ModificarDatos(nombre, primerApellido, segundoApellido);
            _contexto.SaveChanges();
        }

        public void EliminarComprador(Guid id)
        {
            var comprador = _contexto.Compradores.Find(id);
            _contexto.Remove(comprador);
            _contexto.SaveChanges();
        }

        public CompradorDetalleModel ObtenerDetallesComprador(Guid id)
        {
            return _contexto.Compradores.Where(x => x.Id == id).Select(x => new CompradorDetalleModel
            {
                Id = id,
                Nombre = x.Nombre,
                PrimerApellido = x.PrimerApellido,
                SegundoApellido = x.SegundoApellido
            }).Single();
        }

        public IEnumerable<CompradorParaListadoModel> ObtenerListado(string busqueda, int numPagina, int tamanoPagina)
        {
            var query = _contexto.Compradores.AsQueryable();
            if (busqueda != null && !string.IsNullOrWhiteSpace(busqueda))
            {
                query = query.Where(x => x.Nombre.Contains(busqueda) || x.PrimerApellido.Contains(busqueda) || x.SegundoApellido.Contains(busqueda));
            }

            if (numPagina > 1)
            {
                query = query.Skip(tamanoPagina * (numPagina - 1));
            }
            return query.Take(tamanoPagina).Select(x => new CompradorParaListadoModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                PrimerApellido = x.PrimerApellido,
                SegundoApellido = x.SegundoApellido
            }).ToList();           
        }

        public int CountCompradores(string busqueda)
        {
            var query = _contexto.Compradores.AsQueryable();
            if (busqueda != null && !string.IsNullOrWhiteSpace(busqueda))
            {
                query = query.Where(x => x.Nombre.Contains(busqueda) || x.PrimerApellido.Contains(busqueda) || x.SegundoApellido.Contains(busqueda));
            }
            return query.Count();
        }
    }
}
