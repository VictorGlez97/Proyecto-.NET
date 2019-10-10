using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iText.Kernel.Geom;
using iText.StyledXmlParser.Jsoup.Nodes;
using iText.Kernel.Pdf;
using PdfWriter = iTextSharp.text.pdf.PdfWriter;
using PageSize = iTextSharp.text.PageSize;
using Document = iTextSharp.text.Document;
using System.Net.Mail;
using System.Text;

namespace Aplicacion_1
{
    public partial class NET_Equipo7_Unidad0102_ControlEscolar : System.Web.UI.Page
    {
        DataTable TblAlumnos = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            CrearArchivo();
        }

        protected void correo(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txt_correo.Text, @"\w+@\w+\.+[a-z]") || txt_correo.Text == "")
            {
                txt_correo.Text = "";
                Response.Write("<script> window.alert('ERROR: correo no valido'); </script>");
            }
        }

        protected void control(object sender, EventArgs e)
        {
            if (txt_ncontrol.Text.Length < 9)
            {
                if (!Regex.IsMatch(txt_ncontrol.Text, @"[0-9]{8}") || txt_ncontrol.Text == "")
                {
                    txt_ncontrol.Text = "";
                    txt_correo.Text = Convert.ToString(txt_ncontrol.MaxLength);
                    Response.Write("<script> window.alert('ERROR: Numero de Control no valido'); </script>");
                }
            }
            else
            {
                txt_ncontrol.Text = "";
                txt_correo.Text = Convert.ToString(txt_ncontrol.Text.Length);
                Response.Write("<script> window.alert('ERROR: Numero de Control Mayor 8 Digitos'); </script>");
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (txt_correo.Text == "" || txt_ncontrol.Text == "" || txt_numalumno.Text == "" || txt_semestre.Text == ""
                || CmbCarreras.SelectedItem.ToString().ToUpper() == "") {
                Response.Write("<script> window.alert('Necesita llenar todos los campos.'); </script>");
            }
            else
            {
                CrearArchivo();
                String luis = Server.HtmlEncode(txt_ncontrol.Text);
                String luis1 = Server.HtmlDecode(txt_numalumno.Text);
                TblAlumnos.Rows.Add(txt_ncontrol.Text, txt_numalumno.Text, CmbCarreras.SelectedItem.ToString().ToUpper(), txt_semestre.Text, txt_correo.Text);
                GrdAlumnos.DataBind();
                Response.Write("<script> window.alert('Alumno Agregado'); </script>");

            }
        }
        private void CrearArchivo()
        {
            if (Session["TblAlumnos"] != null)
            {
                TblAlumnos = (DataTable)Session["TblAlumnos"];
            }
            else
            {
                TblAlumnos.Columns.AddRange(new DataColumn[5] {
                new DataColumn("Control", typeof(string)),
                new DataColumn("Nombre", typeof(string)),
                new DataColumn("Carrera", typeof(string)),
                new DataColumn("Semestre", typeof(string)),
                new DataColumn("CORREO", typeof(string))});
            }
            GrdAlumnos.DataSource = TblAlumnos;
            GrdAlumnos.DataBind();
            Session["TblAlumnos"] = TblAlumnos;
        }
      
        private Boolean AñadirDatos()
        {
            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = null;
            // Indicamos donde vamos a guardar el documento
            int numero = 0;
            for (int i = 0;i <= numero; i++)
            {
                if (System.IO.File.Exists("C:/Users/vichg/OneDrive/Escritorio/ControlAlumnos" + numero + ".pdf"))
                {
                    numero++;
                }
                else
                {
                     writer = PdfWriter.GetInstance(doc,
                     new FileStream(@"C:\Users\vichg\OneDrive\Escritorio\ControlAlumnos" + numero +".pdf", FileMode.Create));
                }
            }
         
            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Lista de Alumnos ");
            doc.AddCreator("Luis Enrique García Rodríguez y Victor Hugo Gonzales Arreola");

            // Abrimos el archivo
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("         Lista de ALumnos 2019 Clase Desarrollo Asp.NET"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(5);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clControl = new PdfPCell(new Phrase("Numero Control", _standardFont));
            clControl.BorderWidth = 0;
            clControl.BorderWidthBottom = 0.50f;

            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre Alumno", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.50f;

            PdfPCell clCarrera = new PdfPCell(new Phrase("Carrera", _standardFont));
            clCarrera.BorderWidth = 0;
            clCarrera.BorderWidthBottom = 0.50f;

            PdfPCell clSemestre = new PdfPCell(new Phrase("Semestre", _standardFont));
            clSemestre.BorderWidth = 0;
            clSemestre.BorderWidthBottom = 0.50f;

            PdfPCell clCorreo = new PdfPCell(new Phrase("Correo", _standardFont));
            clCorreo.BorderWidth = 0;
            clCorreo.BorderWidthBottom = 0.50f;


            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clControl);
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clCarrera);
            tblPrueba.AddCell(clSemestre);
            tblPrueba.AddCell(clCorreo);

            int iPosicion = 0;
            foreach (GridViewRow row in GrdAlumnos.Rows)
            {
                doc.Add(Chunk.NEWLINE);
                iPosicion++;

                // Llenamos la tabla con información
                clControl = new PdfPCell(new Phrase(row.Cells[0].Text, _standardFont));
                clControl.BorderWidth = 0;

                clNombre = new PdfPCell(new Phrase(row.Cells[1].Text, _standardFont));
                clNombre.BorderWidth = 0;

                clCarrera = new PdfPCell(new Phrase(row.Cells[2].Text, _standardFont));
                clCarrera.BorderWidth = 0;

                clSemestre = new PdfPCell(new Phrase(row.Cells[3].Text, _standardFont));
                clSemestre.BorderWidth = 0;

                clCorreo = new PdfPCell(new Phrase(row.Cells[4].Text, _standardFont));
                clCorreo.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clControl);
                tblPrueba.AddCell(clNombre);
                tblPrueba.AddCell(clCarrera);
                tblPrueba.AddCell(clSemestre);
                tblPrueba.AddCell(clCorreo);
            }
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();
            return true;
        }

        protected void BtnSave2_Click(object sender, EventArgs e)
        {
           if( true == AñadirDatos())
            {
                Response.Write("<script>window.alert(' PDF generado Correctamente ');</script>");
            }
        }
        private void Enviar_Correo()
        {
            try
            {
                string fileName = "";
                Info i = new Info();

                int size = archivo.PostedFile.ContentLength;

                if (size < 5000)
                {
                    if (archivo.HasFile)
                    {
                        foreach (HttpPostedFile file in archivo.PostedFiles)
                        {
                            fileName = Path.GetFileName(file.FileName);

                            string strExtension = Path.GetExtension(fileName);
                            if (strExtension == ".docx" || strExtension == ".pdf" || strExtension == ".jpeg")
                            {
                                file.SaveAs(Server.MapPath("~/") + fileName);
                                i.Anexos = new Attachment(file.InputStream, fileName);
                            }
                        }
                    }
                }


                StringBuilder BodyMesage = new StringBuilder();


                if (i.EnviarMail(fileName.ToString(),"Envio de PDF") == true)
                {
                    Response.Write("<script> window.alert('Solicitud entregada con EXITO'); </script>");
                    Response.Redirect("/NET-Equipo7-Unidad0102-maildelsolicitante.aspx");
                }
                else
                {
                    Response.Write("<script> window.alert('ERROR: no se ha podido enviar la solicitud'); </script>");
                    Response.Redirect("/Site.Master");
                }

            }
            catch (Exception f)
            {
                Response.Write("<script> window.alert(" + f + "); </script>");
                throw;
            }
        }

        protected void EnviarC_Click(object sender, EventArgs e)
        {
               if (0 != archivo.PostedFile.ContentLength){
                Enviar_Correo();
                    
            }
            else
            {
                Response.Write("<script> window.alert('Necesita Agregar el pdf a Enviar'); </script>");
            }

        }

        protected void EnviarC_Click(object sender, EventArgs e)
        {
            
        }
    }
}   
       