using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[HttpPost]
        public ActionResult DownloadPDF()
        {
            PdfDocument document = new PdfDocument();

            document.Info.Title = "A sample invoice";
            document.Info.Author = "Rolf Baxter";
            document.Info.Subject = "Demonstrates how to create an invoice.";
            //document.Info.Keywords = "PdfSharp, Examples, C#";


            PdfPage page = document.AddPage();
            page.Size = PageSize.Letter;
            int margmargins = 30;
            int widthPage = (int)page.Width - (margmargins * 2);
            int top = margmargins;
            int fontbase = 10;

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XTextFormatter tf = new XTextFormatter(gfx);
            tf.Alignment = XParagraphAlignment.Center;

            tf.DrawString("UNIVERSIDAD TECNOLÓGICA DE MÉXICO", new XFont("Arial", fontbase + 4, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top, widthPage, fontbase + 4), XStringFormats.TopLeft);
            tf.DrawString("CAMPUS SUR", new XFont("Arial", fontbase + 1, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top + 15, widthPage, fontbase + 2), XStringFormats.TopLeft);
            tf.DrawString("DIRECCIÓN DE CIENCIAS DE LA SALUD\nCOORDINACIÓN DE CAMPOS CLÍNICOS Y SERVICIO SOCIAL\nLICENCIATURA EN ENFERMERÍA\nCICLO 18-3", new XFont("Arial", fontbase - 1), XBrushes.Black, new XRect(margmargins, top + 30, widthPage, fontbase * 5), XStringFormats.TopLeft);
            tf.DrawString("12°. CUATRIMESTRE\nENFERMERÍA EN TRAUMA Y URGENCIAS", new XFont("Arial", fontbase + 1, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top + 80, widthPage, fontbase * 3), XStringFormats.TopLeft);


            top = 145;
            gfx.DrawLine(XPens.LightGray, margmargins, top - 5, page.Width - margmargins, top - 5);

            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("GRUPO TEORÍA: ENF12A", new XFont("Arial", fontbase + 3, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins + 30, top, widthPage / 2, fontbase + 2), XStringFormats.TopLeft);
            tf.DrawString("GRUPO PRACTICA: ENF12A", new XFont("Arial", fontbase + 3, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins + widthPage / 2 + 30, top, widthPage / 2, fontbase + 2), XStringFormats.TopLeft);


            top += 25;
            gfx.DrawLine(XPens.LightGray, margmargins, top - 5, page.Width - margmargins, top - 5);

            tf.DrawString("DATOS DE ALUMNO", new XFont("Arial", fontbase + 1, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top, widthPage / 2, fontbase + 2), XStringFormats.TopLeft);
            tf.DrawString("Nombre del alumno: SANDRA DEL CARMEN MACEDO DOMINGUEZ", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 15, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Número de cuenta: 00412031", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 27, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Promedio: 8.9", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 39, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Correo electrónico:", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 51, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Teléfono:", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 63, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("En caso de emergencia llamar:", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 80, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Tel.emergencia:", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 92, widthPage / 2, fontbase), XStringFormats.TopLeft);
            
            top += 115;
            gfx.DrawLine(XPens.LightGray, margmargins, top - 5, page.Width - margmargins, top - 5);

            tf.DrawString("DATOS DE LA INSTITUCIÓN", new XFont("Arial", fontbase + 1, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top, widthPage / 2, fontbase + 2), XStringFormats.TopLeft);
            tf.DrawString("Institución asignada práctica: HOSPITAL ANGELES MEXICO MATUTINO 1°", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 15, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Dirección de institución: Escandón I Secc, 11800 Ciudad de México, CDMX", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 27, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Horario de práctica 06:45 A 14:00", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 39, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Fecha de practica: ", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 51, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Periodo: Primero", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 63, widthPage / 2, fontbase), XStringFormats.TopLeft);
            tf.DrawString("Fecha de inducción:Periodo de prácticas del Thursday, June 7, 2018 al Friday, July 27, 2018", new XFont("Arial", fontbase), XBrushes.Black, new XRect(margmargins + 30, top + 75, widthPage / 2, fontbase), XStringFormats.TopLeft);

            top += 100;
            gfx.DrawLine(XPens.LightGray, margmargins, top - 5, page.Width - margmargins, top - 5);

            tf.DrawString("ESTOY INFORMADO Y ACEPTO", new XFont("Arial", fontbase, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top, widthPage, fontbase + 2), XStringFormats.TopLeft);
            tf.DrawString("La duración de la práctica clínica será de forma obligatoria, 5 días de inducción en campus y 6 semanas en campo clínico asignado.", new XFont("Arial", fontbase - 1), XBrushes.Black, new XRect(margmargins, top + 15, widthPage, fontbase * 2), XStringFormats.TopLeft);
            string acepto = " 1. Los Campos Clínicos quedan sujetos a CAMBIO SIN PREVIO AVISO cuando la Institución Receptora así lo disponga.\n" +
" 2. La asistencia de campo clínico se toma en cuenta desde el primer día de Inducción y deberá ser del 100 %.\n" +
" 3. Es obligación del alumno el acceso puntual a las unidades de salud, por lo que deberá presentarse con 15 minutos de antelación.\n" +
" 4. Es obligación del alumno acudir debidamente uniformado a los campos clínicos, de lo contrario no se permitirá el acceso.\n" +
" 5. Durante la estancia en las unidades de salud deberá cumplir con las políticas internas de la institución donde realice la práctica clínica.\n" +
" 6. Está prohibido salir de la Unidad de salud asignada dentro del horario estipulado, de lo contrario será causa de sanción.\n" +
" 7. El estudiante no podrá ser acompañado por ningún familiar y / o amigo en el tiempo que realice su práctica.\n" +
" 8. El alumno no podrá realizar gestiones con el campo clínico para modificaciones en las condiciones de práctica clínica(Unidad Asignada, horarios, justificación de falta, etc.) de lo contrario, será acreedor a sanción por la Universidad.\n" +
" 9. Presentarse a la práctica sin mochilas voluminosas ni objetos de valor(tabletas, laptop, iPhone, etc.).\n" +
"10. Cumplir con las tareas en tiempo y forma asignados por el docente y / o Institución.\n" +
"11. Está prohibido tomar fotografías y / o video de los pacientes y la Institución de salud.\n" +
"12. El uso del celular queda restringido dentro del servicio y/ o en la atención del paciente.\n" +
"13. El alumno NO podrá permanecer en el campo clínico después de su horario de práctica.\n" +
"14. Es obligación del alumno notificar de forma inmediata incidentes que pongan en riesgo la estancia en la unidad o institución donde se realice la práctica, así como incidentes que pongan en riesgo la salud del practicante.\n" +
"15. Si el alumno abandona el campo clínico por su propia voluntad o es dado de baja por la institución receptora, perderá su derecho a la reincorporación de la práctica clínica y/ o acreditación de la materia.\n" +
"16. La institución de salud podrá dar de baja al alumno que no cumpla con los acuerdos establecidos en esta carta compromiso y reglamento institucional, notificándolo al área de Dirección Académica de Enfermería de UNITEC.";
            tf.DrawString(acepto, new XFont("Arial", fontbase - 2), XBrushes.Black, new XRect(margmargins + 10, top + 27, widthPage - 10, 190), XStringFormats.TopLeft);

            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString("NOTA IMPORTANTE: RESPETAR EL GRUPO DE PRÁCTICA QUE SE TE OTORGO EL DÍA DE LA ASIGNACIÓN DE CAMPOS CLÍNICOS, DE OTRA FORMA SE PERDERÁ EL LUGAR Y EL SISTEMA NO LO RECONOCERÁ.",
                new XFont("Arial", fontbase - 2, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top + 225, widthPage, fontbase * 3), XStringFormats.TopLeft);

            top = (int)page.Height - margmargins;

            gfx.DrawLine(XPens.Black, margmargins + 150, top - 75, page.Width - margmargins - 150, top - 75);
            tf.DrawString("NOMBRE Y FIRMA DEL ALUMNO", new XFont("Arial", fontbase, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top - 70, widthPage, fontbase + 2), XStringFormats.TopLeft);

            tf.DrawString("ESTOY ENTERADO Y ME COMPROMETO A CUMPLIR EL REGLAMENTO DE CAMPOS CLÍNICOS, ASÍ MISMO, CONFIRMO QUE LA DOCUMENTACIÓN ENTREGADA EL DÍA DE LA ASIGNACIÓN ES VERÍDICA, QUEDANDO BAJO MI RESPONSABILIDAD EL MANTENERLA VIGENTE, ADEMÁS DE REVISAR Y VERIFICAR QUE MI HORARIO SEA EL CORRECTO EL DÍA DE MI INSCRIPCIÓN.",
                new XFont("Arial", fontbase - 2, XFontStyle.Bold), XBrushes.Black, new XRect(margmargins, top - 50, widthPage, fontbase * 3), XStringFormats.TopLeft);

            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString("Fecha de elaboración de la asignación, Sunday, July 22, 2018",
             new XFont("Arial", fontbase - 2, XFontStyle.Italic), XBrushes.Black, new XRect(margmargins, top - fontbase, widthPage, fontbase), XStringFormats.TopLeft);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, false);

            return File(stream, "application/pdf");
        }
    }
}