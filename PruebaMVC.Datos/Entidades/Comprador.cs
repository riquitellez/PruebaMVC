using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaMVC.Datos.Entidades
{
    public class Comprador
    {
        public Comprador(){}
        public Comprador(string nombre, string primerApellido, string segundoApellido)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
        }

        [Key]
        public Guid Id { get; protected set; }
        [Required]
        public string Nombre { get; protected set; }
        [Required]
        public string PrimerApellido { get; protected set; }
        [Required]
        public string SegundoApellido { get; protected set; }

        public void ModificarDatos(string nombre, string primerApellido, string segundoApellido)
        {
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
        }
    }
}
