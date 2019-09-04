using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMVC.Dominio.Modelos
{
    public class BuscadorModel
    {
        public string TextoABuscar {get; set;}
        public int NumPagina { get; set; }
        public int TamanoPagina { get; set; }
    }
}
