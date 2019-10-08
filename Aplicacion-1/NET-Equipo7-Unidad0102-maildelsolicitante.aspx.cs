using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Aplicacion_1
{
    public partial class NET_Equipo7_Unidad0102_maildelsolicitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txt_correo.Text, @"[A-Z0-9._%+-]+@[A-Z0-9-]+.+.[A-Z]{2,4}") || txt_correo.Text == "")
            {
                Response.Write("<script> window.alert('ERROR: Correo no valido'); </script>");
            }

            if (!Regex.IsMatch(txt_tel.Text, @"{3}[0-9]+{7}[0-9]") || txt_tel.Text == "")
            {
                Response.Write("<script> window.alert('ERROR: Telefono celular no valido'); </scrip");
            }

        }
    }
}