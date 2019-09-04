using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMVC.Dominio.Modelos
{
    public class IndexModel
    {
        public BuscadorModel Buscador { get; set; }
        public IEnumerable<CompradorParaListadoModel> Compradores { get; set; }
        public int NumTotalDeRegistros { get; set; }
    }
}
