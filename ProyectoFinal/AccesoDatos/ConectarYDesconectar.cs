using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class ConectarYDesconectar
    {
        public MySqlConnection con;
        public ConectarYDesconectar()//crea las variable para la coneccion a la base de datos 
        {
            string conneccion = "server=localhost;port=3306;user id=root;password=admin;database=sitiowebinmobiliaria";
            con = new MySqlConnection(conneccion);
        }
        public void conectar()//abre la conneccion a la base de datos
        {

            try
            {
                con.Open();//se abre la conexion
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos: " + ex.ToString());
            }


        }
        public void desconectar()//se cierra la coneccion
        {
            try
            {
                con.Close();//se abre la desconexion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en la Desconexión: " + ex.ToString());
            }
        }
    }
}
