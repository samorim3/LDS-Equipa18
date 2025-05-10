using System;
using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using ReservaEspacos.Model;

namespace ReservaEspacos
{
    public static class PDFGenerator
    {
        public static void GerarComprovativo(Reserva reserva, string caminhoFicheiro)
        {
            // Criar documento e página
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Comprovativo de Reserva";
            PdfPage page = document.AddPage();

            // Criar contexto gráfico
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Definir fontes (usar apenas fontes seguras)
            XFont tituloFont = new XFont("Arial", 16, PdfSharp.Drawing.XFontStyle.Bold);
            XFont corpoFont = new XFont("Arial", 12, PdfSharp.Drawing.XFontStyle.Regular);

            // Título centrado no topo
            gfx.DrawString("Comprovativo de Reserva", tituloFont, XBrushes.Black,
                new XRect(0, 40, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

            // Texto com os dados da reserva
            gfx.DrawString($"Nome: {reserva.NomeUtilizador}", corpoFont, XBrushes.Black, 40, 100);
            gfx.DrawString($"Espaço: {reserva.Espaco}", corpoFont, XBrushes.Black, 40, 130);
            gfx.DrawString($"Data e Hora: {reserva.DataHoraReserva:dd/MM/yyyy HH:mm}", corpoFont, XBrushes.Black, 40, 160);

            // Guardar PDF
            document.Save(caminhoFicheiro);

            // Abrir o ficheiro no visualizador por defeito
            Process.Start(new ProcessStartInfo
            {
                FileName = caminhoFicheiro,
                UseShellExecute = true
            });
        }
    }
}
