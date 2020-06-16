using ComiteEvaluativo.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

namespace ComiteEvaluativo
{
    public partial class estadisticas : System.Web.UI.Page
    {
        int contadorPermisoDashboard;

        SqlComite com = new SqlComite();
        string idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            Chart4.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            try
            {
                if (!IsPostBack)
                {
                    this.BindGrid();
                }
                idUsuario = HttpContext.Current.User.Identity.Name.ToString().ToUpper();
                idUsuario = (idUsuario.Replace("CORPORATIVO\\", ""));
                //idUsuario = Environment.UserName;
                lblUserID.Text = idUsuario.ToUpper();
                SqlComite com = new SqlComite();
                DataSet dsVal = new DataSet();
                dsVal = com.GetPermisosDashboard(idUsuario);

                contadorPermisoDashboard = Convert.ToInt32(dsVal.Tables[0].Rows[0].ItemArray[0].ToString());


                if (contadorPermisoDashboard == 0)
                {
                    HttpContext.Current.Response.Redirect("noacceso.aspx", true);

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }


        private void BindGrid()
        {
            string sConnStr = ConfigurationManager.ConnectionStrings["conexionComiteUAH"].ConnectionString;
            using (SqlConnection con = new SqlConnection(sConnStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UPPER(A.NOMBRE) AS 'NOMBRE', UPPER(A.CORREO) AS 'CORREO ELECTRONICO', UPPER(B.NOMBRE) AS 'PLANTA', UPPER(A.COMENTARIO) AS 'OPINION', CONVERT(VARCHAR(10),A.FECHA,105) AS 'FECHA', CONVERT(VARCHAR(10),A.FECHA,108) AS 'HORA' FROM dbo.DETALLE_ENCUESTA A INNER JOIN PLANTA B ON A.ID_PLANTA = B.ID_PLANTA ORDER BY A.FECHA DESC"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                        }
                    }
                }
            }
        }


        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        protected void ButtonExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ComiteConsultivo.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView2.AllowPaging = false;


                GridView2.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView2.HeaderRow.Cells)
                {
                    cell.BackColor = GridView2.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView2.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView2.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView2.RenderControl(hw);

                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
}