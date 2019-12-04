using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_de_clases;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class UsuarioABM
    {
        ConectarYDesconectar CM;
        public UsuarioABM() { }

        public bool validar(string email, string contrasenia)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM logueo WHERE email=?email";
                comm.Parameters.AddWithValue("?email", email);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                    if (email == myreader["email"].ToString() && contrasenia == myreader["pass"].ToString())
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }

            CM.desconectar();
            return false;
        } 

        public bool tipoUsuario(string usuario) // true = cliente 
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM logueo WHERE email=?email";
                comm.Parameters.AddWithValue("?email", usuario);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                    
                    string id = myreader["id_cliente"].ToString();
                    if (id!="")
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }

            CM.desconectar();
            return false;
        }

        public bool tipoContacto(string usuario) // true = Duenio
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM logueo WHERE email=?email";
                comm.Parameters.AddWithValue("?email", usuario);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {

                    string id = myreader["id_duenio"].ToString();
                    if (id != "")
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }

            CM.desconectar();
            return false;
        }

        //public void ingresarUsuario(Cliente C)
        //{
        //    ClienteABM clienteABM = new ClienteABM();
        //    CM = new ConectarYDesconectar();
        //    int id=clienteABM.SelectClienteId(C);
        //    CM.conectar();
        //    try
        //    {
              
               

        //        MySqlCommand comm = CM.con.CreateCommand();
        //        comm.CommandText = "INSERT INTO logueo(id_cliente,email,pass)VALUES(?id_cliente,?email,?contrasenia)";
        //        comm.Parameters.AddWithValue("?id_cliente", id);
        //        comm.Parameters.AddWithValue("?email", C.EmailC);
        //        comm.Parameters.AddWithValue("?contrasenia", C.ContraseniaC);
                
        //        comm.ExecuteNonQuery();
        //        comm.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un error: " + ex.ToString());
        //    }
        //    CM.desconectar();
        //}

        //public void ingresarUsuario(Contacto C)
        //{
        //    CM = new ConectarYDesconectar();
        //    CM.conectar();
        //    try
        //    {

        //        //MySqlCommand commID = CM.con.CreateCommand();
        //        //commID.CommandText = "SELECT id_cliente FROM  WHERE email = ?email";
        //        //commID.Parameters.AddWithValue("?email", C.Email);

        //        MySqlCommand comm = CM.con.CreateCommand();
        //        comm.CommandText = "INSERT INTO logueo(id_cliente,email,pass)VALUES(?id_cliente,?email,?contrasenia)";
        //        //comm.Parameters.AddWithValue("?id_cliente", commID);
        //        comm.Parameters.AddWithValue("?email", C.Email);
        //        comm.Parameters.AddWithValue("?contrasenia", C.Contrasenia);

        //        comm.ExecuteNonQuery();
        //        comm.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un error: " + ex.ToString());
        //    }
        //    CM.desconectar();
        //}

    }
}
