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
    public class PropiedadABM
    {
        ConectarYDesconectar CM;

        public PropiedadABM()
        {
        }
        public void InsertPropiedad(Propiedad P1, Contacto C)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
                MySqlCommand comm = CM.con.CreateCommand();

                if (C.getTipo() == "Duenio") {
                    comm.CommandText = "INSERT INTO propiedad(id_duenio, nombre, superficie, direccion, estado, cantbanios," +
                   " canthabitaciones, cantcocheras, cantsuites,condicion, fechahabitable, precio) VALUES(?id_duenio,?nombre,?superficie," +
                   "?direccion,?estado,?cantbanios,?canthabitaciones,?cantcocheras,?cantsuites,?condicion,?fechahabitable, ?precio)";
                    DuenioABM D = new DuenioABM();
                    int idDuenio = D.SelectDuenioId(C);
                    comm.Parameters.AddWithValue("?id_duenio", idDuenio);
                }
                else
                {
                    comm.CommandText = "INSERT INTO propiedad(id_inmobiliaria,nombre, superficie, direccion, estado, cantbanios," +
                   " canthabitaciones, cantcocheras, cantsuites,condicion, fechahabitable, precio) VALUES(?id_inmobiliaria,?nombre,?superficie," +
                   "?direccion,?estado,?cantbanios,?canthabitaciones,?cantcocheras,?cantsuites,?condicion,?fechahabitable, ?precio)";
                    InmobiliariaABM I = new InmobiliariaABM();
                    int idInmo = I.SelectInmobiliariaId(C);
                    comm.Parameters.AddWithValue("?id_inmobiliaria", idInmo);
                }
                //comm.CommandText = "INSERT INTO propiedad(nombre, superficie, direccion, estado, cantbanios, canthabitaciones, cantacocheras, cantsuites,condicion, fechahabitable) VALUES(?nombre,?superficie,?direccion,?estado,?cantbanios,?canthabitaciones,?cantacocheras,?cantsuites,?condicion,?fechahabitable)";
       
                comm.Parameters.AddWithValue("?nombre", P1.NombreI);
                comm.Parameters.AddWithValue("?superficie", P1.SuperficieI);
                comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                comm.Parameters.AddWithValue("?estado", P1.EstadoI);
                comm.Parameters.AddWithValue("?precio", P1.PrecioI);
                comm.Parameters.AddWithValue("?cantbanios", P1.CantidadBanios);
                comm.Parameters.AddWithValue("?canthabitaciones", P1.CantidadHabitaciones);
                comm.Parameters.AddWithValue("?cantcocheras", P1.CantidadCocheras);
                comm.Parameters.AddWithValue("?cantsuites", P1.CantidadSuites);
                comm.Parameters.AddWithValue("?condicion", P1.Condicion);
                comm.Parameters.AddWithValue("?fechahabitable", P1.FechaHabitable);
                comm.ExecuteNonQuery();
                comm.Dispose();


            }catch(Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }

        public void UpdatePropiedad(Propiedad P1)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "UPDATE propiedad SET nombre=?nombre, superficie=?superficie, estado=?estado," +
                    " cantbanios=?cantbanios, canthabitaciones=?canthabitaciones, cantcocheras=?cantcocheras," +
                    " cantsuites=?cantsuites, condicion=?condicion, fechahabitable=?fechahabitable, precio=?precio " +
                    "WHERE direccion=?direccion";
                
                comm.Parameters.AddWithValue("?nombre", P1.NombreI);
                comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                comm.Parameters.AddWithValue("?superficie", P1.SuperficieI);
                comm.Parameters.AddWithValue("?estado", P1.EstadoI);
                comm.Parameters.AddWithValue("?precio", P1.PrecioI);
                comm.Parameters.AddWithValue("?cantbanios", P1.CantidadBanios);
                comm.Parameters.AddWithValue("?canthabitaciones", P1.CantidadHabitaciones);
                comm.Parameters.AddWithValue("?cantcocheras", P1.CantidadCocheras);
                comm.Parameters.AddWithValue("?cantsuites", P1.CantidadSuites);
                comm.Parameters.AddWithValue("?condicion", P1.Condicion);
                comm.Parameters.AddWithValue("?fechahabitable", P1.FechaHabitable);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }

        public void DeletePropiedad(Propiedad P1){

            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "DELETE FROM propiedad WHERE direccion=?direccion ";
                comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                

                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }

        public void SelectPropiedad(ref Propiedad P1)
        {

            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM propiedad WHERE direccion=?direccion";
                comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                    P1.NombreI = myreader["nombre"].ToString();
                    P1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    P1.DireccionI = myreader["direccion"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "Alquiler":
                            P1.EstadoI = estado.Alquiler;
                            break;
                        case "NoDisponible":
                            P1.EstadoI = estado.NoDisponible;
                            break;
                        case "Venta":
                            P1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    P1.PrecioI = float.Parse(myreader["precio"].ToString());
                    P1.CantidadBanios = int.Parse(myreader["cantbanios"].ToString());
                    P1.CantidadHabitaciones = int.Parse(myreader["canthabitaciones"].ToString());
                    P1.CantidadCocheras = int.Parse(myreader["cantcocheras"].ToString());
                    P1.CantidadSuites = int.Parse(myreader["cantsuites"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }
        public List<Propiedad> SelectPropiedad(Contacto C)
        {
            List<Propiedad> lista = new List<Propiedad>();
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
               
                MySqlCommand comm = CM.con.CreateCommand();
                if (C.getTipo() == "Duenio")
                {
                    comm.CommandText = "SELECT * FROM propiedad INNER JOIN duenio USING(id_duenio) WHERE email=?email";
                    
                    comm.Parameters.AddWithValue("?email", C.Email);
                }
                else
                {
                    comm.CommandText = comm.CommandText = "SELECT * FROM propiedad INNER JOIN inmobiliaria USING(id_inmobiliaria)" +
                        " WHERE email=?email";
                    comm.Parameters.AddWithValue("?email", C.Email);
                }
                //comm.CommandText = "SELECT * FROM propiedad WHERE direccion=?direccion AND nombre=?nombre";
                //comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                //comm.Parameters.AddWithValue("?nombre", P1.NombreI);

                MySqlDataReader myreader = comm.ExecuteReader();
              
                while (myreader.Read())
                {
                    Propiedad P1 = new Propiedad();
                    P1.NombreI = myreader["nombre"].ToString();
                    P1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    P1.DireccionI = myreader["direccion"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "0":
                            P1.EstadoI = estado.Alquiler;
                            break;
                        case "2":
                            P1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            P1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    P1.PrecioI = float.Parse(myreader["precio"].ToString());
                    P1.CantidadBanios = int.Parse(myreader["cantbanios"].ToString());
                    P1.CantidadHabitaciones = int.Parse(myreader["canthabitaciones"].ToString());
                    P1.CantidadCocheras = int.Parse(myreader["cantcocheras"].ToString());
                    P1.CantidadSuites = int.Parse(myreader["cantsuites"].ToString());
                    P1.FechaHabitable = myreader["fechahabitable"].ToString();
                    lista.Add(P1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return lista;
        }

        public List<Propiedad> SelectPropiedades()
        {
            List<Propiedad> lista = new List<Propiedad>();
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();              
                comm.CommandText = "SELECT * FROM propiedad";
                DuenioABM D = new DuenioABM();
              
                //comm.CommandText = "SELECT * FROM propiedad WHERE direccion=?direccion AND nombre=?nombre";
                //comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                //comm.Parameters.AddWithValue("?nombre", P1.NombreI);

                MySqlDataReader myreader = comm.ExecuteReader();

                while (myreader.Read())
                {
                    Propiedad P1 = new Propiedad();
                    P1.NombreI = myreader["nombre"].ToString();
                    P1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    P1.DireccionI = myreader["direccion"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "0":
                            P1.EstadoI = estado.Alquiler;
                            break;
                        case "2":
                            P1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            P1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    P1.PrecioI = float.Parse(myreader["precio"].ToString());
                    P1.CantidadBanios = int.Parse(myreader["cantbanios"].ToString());
                    P1.CantidadHabitaciones = int.Parse(myreader["canthabitaciones"].ToString());
                    P1.CantidadCocheras = int.Parse(myreader["cantcocheras"].ToString());
                    P1.CantidadSuites = int.Parse(myreader["cantsuites"].ToString());
                    P1.FechaHabitable = myreader["fechahabitable"].ToString();
                    lista.Add(P1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return lista;
        }

        public List<Propiedad> selecPropiedadporPrecio(double precio)
        {
            List<Propiedad> lista = new List<Propiedad>();
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM propiedad WHERE precio>=?precio";
                DuenioABM D = new DuenioABM();
                comm.Parameters.AddWithValue("?precio", precio);

               
              
              
                //comm.CommandText = "SELECT * FROM propiedad WHERE direccion=?direccion AND nombre=?nombre";
                //comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                //comm.Parameters.AddWithValue("?nombre", P1.NombreI);

                MySqlDataReader myreader = comm.ExecuteReader();

                while (myreader.Read())
                {
                    Propiedad P1 = new Propiedad();
                    P1.NombreI = myreader["nombre"].ToString();
                    P1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    P1.DireccionI = myreader["direccion"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "0":
                            P1.EstadoI = estado.Alquiler;
                            break;
                        case "2":
                            P1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            P1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    P1.PrecioI = float.Parse(myreader["precio"].ToString());
                    P1.CantidadBanios = int.Parse(myreader["cantbanios"].ToString());
                    P1.CantidadHabitaciones = int.Parse(myreader["canthabitaciones"].ToString());
                    P1.CantidadCocheras = int.Parse(myreader["cantcocheras"].ToString());
                    P1.CantidadSuites = int.Parse(myreader["cantsuites"].ToString());
                    P1.FechaHabitable = myreader["fechahabitable"].ToString();
                    lista.Add(P1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return lista;
        }

        public List<Propiedad> selecPropiedadporSuperficie(int superficie)
        {
            List<Propiedad> lista = new List<Propiedad>();
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM Propiedad WHERE superficie>=?superficie";
                DuenioABM D = new DuenioABM();
                comm.Parameters.AddWithValue("?superficie", superficie);




                //comm.CommandText = "SELECT * FROM propiedad WHERE direccion=?direccion AND nombre=?nombre";
                //comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                //comm.Parameters.AddWithValue("?nombre", P1.NombreI);

                MySqlDataReader myreader = comm.ExecuteReader();

                while (myreader.Read())
                {
                    Propiedad P1 = new Propiedad();
                    P1.NombreI = myreader["nombre"].ToString();
                    P1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    P1.DireccionI = myreader["direccion"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "0":
                            P1.EstadoI = estado.Alquiler;
                            break;
                        case "2":
                            P1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            P1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    P1.PrecioI = float.Parse(myreader["precio"].ToString());
                    lista.Add(P1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return lista;
        }
    }
}
