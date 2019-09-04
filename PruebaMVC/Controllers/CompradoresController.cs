using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Dominio.Modelos;
using PruebaMVC.Servicios;

namespace PruebaMVC.Web.Controllers
{
    public class CompradoresController : Controller
    {
        private CompradoresServicio _servicio;
        private ExportarExcelServicio _excelServicio;

        public CompradoresController(CompradoresServicio servicio, ExportarExcelServicio excelServicio)
        {
            _servicio = servicio;
            _excelServicio = excelServicio;
        }

        public IActionResult Index()
        {            
            var listado = _servicio.ObtenerListado();
            var buscador = new BuscadorModel
            {
                TextoABuscar = string.Empty,
                NumPagina = 1,
                TamanoPagina = 10
            };

            return View(new IndexModel
            {
                Buscador = buscador,
                Compradores = listado.Item1,
                NumTotalDeRegistros = listado.Item2
            });           
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            var listado = _servicio.ObtenerListado(model.Buscador.TextoABuscar,model.Buscador.NumPagina, model.Buscador.TamanoPagina);
            var indexModel =  new IndexModel
            {
                Buscador = model.Buscador,
                Compradores = listado.Item1,
                NumTotalDeRegistros = listado.Item2
            };
            return View(indexModel);
        }
        public IActionResult Anadir()
        {
            AnadirCompradorModel model = new AnadirCompradorModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Anadir(AnadirCompradorModel model)
        {
            _servicio.AnadirComprador(model);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(Guid idComprador)
        {
            var detalle = _servicio.ObtenerDetallesComprador(idComprador);
            return View(new EditarCompradorModel
            {
                Id = detalle.Id,
                Nombre = detalle.Nombre,
                PrimerApellido = detalle.PrimerApellido,
                SegundoApellido = detalle.SegundoApellido
            });
        }

        [HttpPost]
        public IActionResult Editar(EditarCompradorModel model)
        {
            _servicio.EditarComprador(model);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(Guid idComprador)
        {
            _servicio.EliminarComprador(idComprador);
            return RedirectToAction("Index");
        }

        public IActionResult ExportarExcel()
        {
            var compradores = _servicio.ObtenerListado();
            var data = _excelServicio.ExportFile(compradores.Item1);
            return File(data, "application/octet-stream", "Compradores.xlsx");
        }
    }
}