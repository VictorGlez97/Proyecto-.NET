using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Aplicacion_1
{
    public partial class NET_Equipo7_Unidad0102_ControlEscolar : System.Web.UI.Page
    {

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
    }
}   
       