using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMVC.Dominio.Modelos
{
    public class CompradorParaListadoModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

    }
}
