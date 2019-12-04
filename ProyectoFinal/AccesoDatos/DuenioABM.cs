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
    public class DuenioABM
    {
        ConectarYDesconectar CM;

        public DuenioABM()
        {
        }

        public void insertarDuenio(Duenio D)//inserta los datos en la tabla duenio y en logueo
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "INSERT INTO duenio(nombre,email,telefono, direccion, horariodisp) VALUES(?nombre,?email,?telefono,?direccion,?horariodisp)";
              
                comm.Parameters.AddWithValue("?nombre", D.Nombre);
                comm.Parameters.AddWithValue("?email", D.Email);
                comm.Parameters.AddWithValue("?telefono", D.Telefono);
                comm.Parameters.AddWithValue("?direccion", D.Direccion);
                comm.Parameters.AddWithValue("?horariodisp", D.HorarioDeDisponibilidad);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            int id = SelectDuenioId(D);
            ingresarcontrasenia(D, id);
        }
        public void updateDuenio(Duenio D)//actualiza los datos de duenio en la tabla y en logueo
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "UPDATE duenio SET nombre=?nombre,email=?email,telefono=?telefono, direccion=?direccion,horariodisp=?horariodisp WHERE email=?email";
                comm.Parameters.AddWithValue("?nombre", D.Nombre);
                comm.Parameters.AddWithValue("?email", D.Email);
                comm.Parameters.AddWithValue("?telefono", D.Telefono);
                comm.Parameters.AddWithValue("?direccion", D.Direccion);
                comm.Parameters.AddWithValue("?horariodisp", D.HorarioDeDisponibilidad);
                
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            modificarcontrasenia(D);
        }
        public void deleteDuenio(Duenio D)//elimina el duenio de la tabla
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "DELETE FROM duenio WHERE email=?email";
                comm.Parameters.AddWithValue("?email", D.Email);
                
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }
        public void SelectDuenio(ref Duenio D)//trae los datos de duenio de la base de datos y los guarda en el parametro enviado 
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM duenio INNER JOIN logueo USING(id_duenio) WHERE logueo.email=?email";
                comm.Parameters.AddWithValue("?email", D.Email);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                    D.Nombre = myreader["nombre"].ToString();
                    D.Email = myreader["email"].ToString();
                    D.Direccion = myreader["direccion"].ToString();
                    D.HorarioDeDisponibilidad = myreader["horariodisp"].ToString();
                    D.Telefono = int.Parse(myreader["telefono"].ToString());
                    D.Contrasenia = myreader["pass"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }
        public int SelectDuenioId(Contacto D)//devuelve el id delduenio
        {
            int id = 0;
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM duenio WHERE email=?email";
                comm.Parameters.AddWithValue("?email", D.Email);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                    id = int.Parse(myreader["id_duenio"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }

            CM.desconectar();
            return id;
        }

        public void modificarcontrasenia(Duenio D)//modifica duenio en la tabla logueo(se la utilisa en updateduenio)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "UPDATE logueo SET pass=?contrasenia WHERE email=?email";
                comm.Parameters.AddWithValue("?email", D.Email);
                comm.Parameters.AddWithValue("?contrasenia", D.Contrasenia);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();

        }

        public void ingresarcontrasenia(Duenio D, int id)//ingresa los datos de logueo dell duenio en la tabla logueo
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "INSERT INTO logueo(id_duenio, pass, email) VALUES(?id_duenio,?contrasenia,?email)";
                comm.Parameters.AddWithValue("?email", D.Email);
                comm.Parameters.AddWithValue("?contrasenia", D.Contrasenia);
                comm.Parameters.AddWithValue("?id_duenio", id);
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
