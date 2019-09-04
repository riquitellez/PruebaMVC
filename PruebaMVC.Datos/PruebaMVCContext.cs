using Microsoft.EntityFrameworkCore;
using PruebaMVC.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMVC.Datos
{
    public class PruebaMVCContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=PruebaMVC;Trusted_Connection=True;");
            }
        }
        public DbSet<Comprador> Compradores { get; set; }
    }
}
