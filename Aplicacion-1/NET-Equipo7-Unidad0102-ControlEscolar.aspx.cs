using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Aplicacion_1
{
    public partial class NET_Equipo7_Unidad0102_ControlEscolar : System.Web.UI.Page
    {
        DataTable TblAlumnos = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

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
                if (!Regex.IsMatch(txt_ncontrol.Text, @" [0-9][0-9][1-2][3-9][0-9][0-9][0-9][0-9]{8}") || txt_ncontrol.Text == "")
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
            CrearArchivo();
            String luis = Server.HtmlEncode(txt_ncontrol.Text);
            String luis1 = Server.HtmlDecode(txt_numalumno.Text);
            TblAlumnos.Rows.Add(txt_ncontrol.Text, txt_numalumno.Text, CmbCarreras.SelectedItem.ToString().ToUpper(), txt_semestre.Text,txt_correo.Text);
            GrdAlumnos.DataBind();
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
    }
}   
       