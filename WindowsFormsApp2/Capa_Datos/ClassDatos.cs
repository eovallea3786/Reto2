using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;
using System.Configuration;

using static System.Net.Mime.MediaTypeNames;

namespace Capa_Datos
{
    public class ClassDatos


    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_libros()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_libros ", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_libros(ClassEntidad obje){
            SqlCommand cmd = new SqlCommand(" sp_buscar_libros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@titulo", obje.titulo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_mantenimiento_libros(ClassEntidad obje)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("sp_mantenimiento_libros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", obje.codigo);
            cmd.Parameters.AddWithValue("@titulo", obje.titulo);
            cmd.Parameters.AddWithValue("@autor", obje.autor);
            cmd.Parameters.AddWithValue("@editorial", obje.editorial);
            cmd.Parameters.AddWithValue("@precio", obje.precio);
            cmd.Parameters.AddWithValue("@cantidad", obje.cantidad);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;
        }



    }
}
