using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Biblioteca_de_clases;

namespace AccesoDatos
{
    public class InmobiliariaABM
    {
        ConectarYDesconectar CM;

        public InmobiliariaABM()
        {
        }

        public void InsertInmobiliaria(Inmobiliaria I)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "INSERT INTO inmobiliaria(nombre,email,telefono, direccion, sitioweb) VALUES(?nombre,?email,?telefono,?direccion,?sitioweb)";
                comm.Parameters.AddWithValue("?nombre", I.Nombre);
                comm.Parameters.AddWithValue("?email", I.Email);
                comm.Parameters.AddWithValue("?telefono", I.Telefono);
                comm.Parameters.AddWithValue("?direccion", I.Direccion);
                comm.Parameters.AddWithValue("?sitioweb", I.SitioWeb);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            int id = SelectInmobiliariaId(I);
            ingresarcontrasenia(I, id);
        }
        public void Updateinmobiliaria(Inmobiliaria I)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "UPDATE inmobiliaria SET nombre=?nombre,email=?email,telefono=?telefono, " +
                                    "direccion=?direccion,sitioweb=?sitioweb WHERE email=?email";
                
                comm.Parameters.AddWithValue("?nombre", I.Nombre);
                comm.Parameters.AddWithValue("?email", I.Email);
                comm.Parameters.AddWithValue("?telefono", I.Telefono);
                comm.Parameters.AddWithValue("?direccion", I.Direccion);
                comm.Parameters.AddWithValue("?sitioweb", I.SitioWeb);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            modificarcontrasenia(I);
        }
        public void DeleteInmobiliaria(Inmobiliaria I)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "DELETE FROM Inmobiliaria WHERE email=?email";
                comm.Parameters.AddWithValue("?email", I.Email);
                
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }

        public void SelectInmobiliaria(ref Inmobiliaria I)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM inmobiliaria INNER JOIN logueo USING(id_inmobiliaria) WHERE logueo.email=?email";
                comm.Parameters.AddWithValue("?email", I.Email);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                    I.Nombre = myreader["nombre"].ToString();
                    I.Email = myreader["email"].ToString();
                    I.Direccion = myreader["direccion"].ToString();
                    I.SitioWeb = myreader["sitioweb"].ToString();
                    I.Telefono = int.Parse(myreader["telefono"].ToString());
                    I.Contrasenia=myreader["pass"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }
        public int SelectInmobiliariaId(Contacto I)
        {
            int id = 0;
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM inmobiliaria WHERE email=?email";
                comm.Parameters.AddWithValue("?email", I.Email);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                   
                    id= int.Parse(myreader["id_inmobiliaria"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return id;
        }

        public void modificarcontrasenia(Inmobiliaria I)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "UPDATE logueo SET pass=?contrasenia WHERE email=?email";
                comm.Parameters.AddWithValue("?email", I.Email);
                comm.Parameters.AddWithValue("?contrasenia", I.Contrasenia);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();

        }
        public void ingresarcontrasenia(Inmobiliaria I, int id)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "INSERT INTO logueo(id_inmobiliaria, pass, email) VALUES(?id_inmobiliaria,?contrasenia,?email)";
                comm.Parameters.AddWithValue("?email", I.Email);
                comm.Parameters.AddWithValue("?contrasenia", I.Contrasenia);
                comm.Parameters.AddWithValue("?id_inmobiliaria", id);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();

        }
    }
}
