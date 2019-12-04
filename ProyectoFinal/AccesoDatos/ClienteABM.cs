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
    public class ClienteABM
    {
        ConectarYDesconectar CM;

        public ClienteABM()
        {
        }

        public void insertarCliente(Cliente cliente)//inserta en la tabla clientes los datos y tambien en la tabla logueo
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "INSERT INTO Cliente(nombre,apellido,email,telefono)VALUES(?nombre,?apellido ,?email,?telefono)";
                
                comm.Parameters.AddWithValue("?nombre", cliente.NombreC);
                comm.Parameters.AddWithValue("?apellido", cliente.ApellidoC);
                comm.Parameters.AddWithValue("?email", cliente.EmailC);
                comm.Parameters.AddWithValue("?telefono", cliente.TelefonoC);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            int id = SelectClienteId(cliente);
            ingresarcontrasenia(cliente, id);
        }
        public void updateCliente(Cliente cliente)//modifica los datos del cliente en las tablas
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "UPDATE Cliente SET nombre=?nombre,apellido=?apellido,email=?email,telefono=?telefono WHERE email=?email";
                
                comm.Parameters.AddWithValue("?nombre", cliente.NombreC);
                comm.Parameters.AddWithValue("?apellido", cliente.ApellidoC);
                comm.Parameters.AddWithValue("?email", cliente.EmailC);
                comm.Parameters.AddWithValue("?telefono", cliente.TelefonoC);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            modificarcontrasenia(cliente);
        }
        public void deleteCliente(Cliente cliente)//elimina el cliente especificado de las tablas
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "DELETE FROM Cliente WHERE email=?email";
                comm.Parameters.AddWithValue("?email", cliente.EmailC);

                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }
        public void SelectCliente(ref Cliente cliente)//seleccion un cliente y lo guarda en el parametro q esta mandado como referencia
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM cliente INNER JOIN logueo USING(id_cliente) WHERE logueo.email=?email";
                comm.Parameters.AddWithValue("?email", cliente.EmailC);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                    cliente.NombreC = myreader["nombre"].ToString();
                    cliente.ApellidoC = myreader["apellido"].ToString();
                    cliente.EmailC = myreader["email"].ToString();
                    cliente.TelefonoC = int.Parse(myreader["telefono"].ToString());
                    cliente.ContraseniaC = myreader["pass"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            
        }
        public int SelectClienteId(Cliente C)//selecciona el id del cliente para utilizarlo en insertercliente
        {
            int id_cliente = 0;
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand commID = CM.con.CreateCommand();
                commID.CommandText = "SELECT id_cliente FROM cliente WHERE email = ?email";
                commID.Parameters.AddWithValue("?email", C.EmailC);

                MySqlDataReader myreader = commID.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                   id_cliente = Convert.ToInt32( myreader["id_cliente"].ToString());
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return id_cliente;
        }
        public void modificarcontrasenia(Cliente cliente)//se utilisa para modificar la contraseña en la tabla logueo cunado se hace updatecliente
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "UPDATE logueo SET pass=?contrasenia WHERE email=?email";
                comm.Parameters.AddWithValue("?email", cliente.EmailC);
                comm.Parameters.AddWithValue("?contrasenia", cliente.ContraseniaC);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
           
        }
        public void ingresarcontrasenia(Cliente C, int id)//se utiliza en insertarcliente para insertar datos en tabla logueo
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "INSERT INTO logueo(id_cliente, pass, email) VALUES(?id_cliente,?contrasenia,?email)";
                comm.Parameters.AddWithValue("?email", C.EmailC);
                comm.Parameters.AddWithValue("?contrasenia", C.ContraseniaC);
                comm.Parameters.AddWithValue("?id_cliente", id);
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
