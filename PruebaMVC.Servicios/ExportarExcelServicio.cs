using PruebaMVC.Dominio.Modelos;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;
using System;

namespace PruebaMVC.Servicios
{
    public class ExportarExcelServicio
    {
        public byte[] ExportFile(IEnumerable<CompradorParaListadoModel> compradores)
        {
            var memoryStream = new MemoryStream();
            using (ExcelPackage excelPackage = new ExcelPackage(memoryStream))
            {
                excelPackage.Workbook.Properties.Author = "Riqui";
                excelPackage.Workbook.Properties.Title = "Listado de compradores";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Compradores");

                // Títulos:
                worksheet.Cells[1, 1].Value = "Nombre";
                worksheet.Cells[1, 2].Value = "Primer apellido";
                worksheet.Cells[1, 3].Value = "Segundo apellido";

                int i = 2;

                foreach (var comprador in compradores)
                {
                    worksheet.Cells[i, 1].Value = comprador.Nombre;
                    worksheet.Cells[i, 2].Value = comprador.PrimerApellido;
                    worksheet.Cells[i, 3].Value = comprador.SegundoApellido;

                    i++;
                }
                return excelPackage.GetAsByteArray();
            }
        }
    }
}
