using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ComiteEvaluativo.clases.SqlComite))]

namespace ComiteEvaluativo.clases
{
    public class SqlComite
    {
        private string sConnStr;
        public void Inicio()
        {
            sConnStr = ConfigurationManager.ConnectionStrings["conexionComiteUAH"].ToString();
        }


        public DataSet GetCargaDatos(string idUsuario)
        {
            Inicio();
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                //1) conexion a BD
                conn = new SqlConnection(this.sConnStr);
                conn.Open();
                //configura SP a llamar
                SqlCommand cmd = new SqlCommand("SELECT_DATOS", conn);
                cmd.Parameters.AddWithValue("@USER", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(ds, "Tabla");
                conn.Close();
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                throw (ex);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }

        public DataSet GetInsertaEncuesta(string usuario, string nombre, string correo, int id_planta, string comentario)
        {
            Inicio();
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                //1) conexion a BD
                conn = new SqlConnection(this.sConnStr);
                conn.Open();
                //configura SP a llamar
                SqlCommand cmd = new SqlCommand("INSERT_ENCUESTA", conn);
                cmd.Parameters.AddWithValue("@USUARIO", usuario);
                cmd.Parameters.AddWithValue("@NOMBRE", nombre);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@ID_PLANTA", id_planta);
                cmd.Parameters.AddWithValue("@COMENTARIO", comentario);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(ds, "Tabla");
                conn.Close();
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                throw (ex);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }

        public DataSet GetEstado(string idUsuario)
        {
            Inicio();
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                //1) conexion a BD
                conn = new SqlConnection(this.sConnStr);
                conn.Open();
                //configura SP a llamar
                SqlCommand cmd = new SqlCommand("SELECT_BUSCA_ENCUESTA", conn);
                cmd.Parameters.AddWithValue("@USUARIO", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(ds, "Tabla");
                conn.Close();
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                throw (ex);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }

        public DataSet GetPermisosDashboard(string idUsuario)
        {
            Inicio();
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                //1) conexion a BD
                conn = new SqlConnection(this.sConnStr);
                conn.Open();
                //configura SP a llamar
                SqlCommand cmd = new SqlCommand("SELECT_PERMISOS_DASHBOARD", conn);
                cmd.Parameters.AddWithValue("@USER", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(ds, "Tabla");
                conn.Close();
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                throw (ex);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }


        public DataSet GetDatosMail(string idUsuario)
        {
            Inicio();
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                //1) conexion a BD
                conn = new SqlConnection(this.sConnStr);
                conn.Open();
                //configura SP a llamar
                SqlCommand cmd = new SqlCommand("SELECT_DATOS_MAIL", conn);
                cmd.Parameters.AddWithValue("@USUARIO", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(ds, "Tabla");
                conn.Close();
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                throw (ex);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }
        public DataSet GetDatosProceso()
        {
            Inicio();
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                //1) conexion a BD
                conn = new SqlConnection(this.sConnStr);
                conn.Open();
                //configura SP a llamar
                SqlCommand cmd = new SqlCommand("SELECT_VALIDA_PROCESO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(ds, "Tabla");
                conn.Close();
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                throw (ex);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }
        public DataSet GetDatosProcesoID()
        {
            Inicio();
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                //1) conexion a BD
                conn = new SqlConnection(this.sConnStr);
                conn.Open();
                //configura SP a llamar
                SqlCommand cmd = new SqlCommand("SELECT_PROCESO_ACTIVO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(ds, "Tabla");
                conn.Close();
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                throw (ex);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }
    }
}
