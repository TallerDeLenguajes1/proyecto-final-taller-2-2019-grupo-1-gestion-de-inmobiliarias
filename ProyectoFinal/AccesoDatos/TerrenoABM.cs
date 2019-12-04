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
    public class TerrenoABM
    {
        ConectarYDesconectar CM;

        public TerrenoABM()
        {
        }
        public void InsertTerreno(Terreno T1, Contacto C)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
                MySqlCommand comm = CM.con.CreateCommand();
                if (C.getTipo() == "Duenio")
                {
                    comm.CommandText = "INSERT INTO terreno(id_duenio,nombre, superficie, direccion," +
                        " estado, precio) VALUES(?id_duenio,?nombre,?superficie,?direccion,?estado,?precio)";
                    DuenioABM D = new DuenioABM();
                    int idDuenio = D.SelectDuenioId(C);
                    comm.Parameters.AddWithValue("?id_duenio", idDuenio);
                }
                else
                {
                    comm.CommandText = "INSERT INTO terreno(id_inmobiliaria,nombre, superficie," +
                        " direccion, estado, precio) VALUES(?id_inmobiliaria,?nombre,?superficie,?direccion,?estado,?precio)";
                    InmobiliariaABM I = new InmobiliariaABM();
                    int idInmo = I.SelectInmobiliariaId(C);
                    comm.Parameters.AddWithValue("?id_inmobiliaria", idInmo);
                }
                //comm.CommandText = "INSERT INTO terreno(nombre, superficie, direccion, estado, precio) VALUES(?nombre,?superficie,?direccion,?estado,?precio)";

                comm.Parameters.AddWithValue("?nombre", T1.NombreI);
                comm.Parameters.AddWithValue("?superficie", T1.SuperficieI);
                comm.Parameters.AddWithValue("?direccion", T1.DireccionI);
                comm.Parameters.AddWithValue("?estado", T1.EstadoI);
                comm.Parameters.AddWithValue("?precio", T1.PrecioI);
                comm.ExecuteNonQuery();
                comm.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }

        public void UpdateTerreno(Terreno T1)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "UPDATE terreno SET nombre=?nombre, superficie=?superficie, estado=?estado, precio=?precio WHERE direccion=?direccion";

                comm.Parameters.AddWithValue("?nombre", T1.NombreI);
                comm.Parameters.AddWithValue("?superficie", T1.SuperficieI);
                comm.Parameters.AddWithValue("?estado", T1.EstadoI);
                comm.Parameters.AddWithValue("?precio", T1.PrecioI);
                comm.Parameters.AddWithValue("?direccion", T1.DireccionI);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }

        public void DeleteTerreno(Terreno T1)
        {

            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "DELETE FROM terreno WHERE direccion=?direccion";
                comm.Parameters.AddWithValue("?direccion", T1.DireccionI);

                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }

        public void SelectTerreno(ref Terreno T1)
        {
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM terreno WHERE direccion=?direccion";
                comm.Parameters.AddWithValue("?email", T1.DireccionI);

                MySqlDataReader myreader = comm.ExecuteReader();
                myreader.Read();
                if (myreader.HasRows)
                {
                    T1.NombreI = myreader["nombre"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "2":
                            T1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            T1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    T1.DireccionI = myreader["direccion"].ToString();
                    T1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
        }

        public List<Terreno> SelectTerreno()
        {
            List<Terreno> lista = new List<Terreno>();
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM Terreno";
                DuenioABM D = new DuenioABM();

                //comm.CommandText = "SELECT * FROM propiedad WHERE direccion=?direccion AND nombre=?nombre";
                //comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                //comm.Parameters.AddWithValue("?nombre", P1.NombreI);

                MySqlDataReader myreader = comm.ExecuteReader();

                while (myreader.Read())
                {
                    Terreno T1 = new Terreno();
                    T1.NombreI = myreader["nombre"].ToString();
                    T1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    T1.DireccionI = myreader["direccion"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "2":
                            T1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            T1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    T1.PrecioI = Convert.ToDouble(myreader["precio"].ToString());
                    lista.Add(T1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return lista;
        }
    


        public List<Terreno> SelectTerreno(Contacto C)//mostrar todos los inmuebles
        {
            List<Terreno> lista = new List<Terreno>();
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {
                MySqlCommand comm = CM.con.CreateCommand();
                if (C.getTipo() == "Duenio")
                {
                    comm.CommandText = "SELECT * FROM terreno INNER JOIN duenio USING(id_duenio) WHERE email=?email";

                    comm.Parameters.AddWithValue("?email", C.Email);
                }
                else
                {
                    comm.CommandText = comm.CommandText = "SELECT * FROM terreno INNER JOIN inmobiliaria" +
                        " USING(id_inmobiliaria) WHERE email=?email";

                    comm.Parameters.AddWithValue("?email", C.Email);
                }

                //comm.CommandText = "SELECT * FROM terreno WHERE direccion=?direccion";
                //comm.Parameters.AddWithValue("?email", T1.DireccionI);

                MySqlDataReader myreader = comm.ExecuteReader();

                while (myreader.Read())
                {
                    Terreno T1 = new Terreno();
                    T1.NombreI = myreader["nombre"].ToString();
                    switch (myreader["estado"].ToString())
                    {                       
                        case "2":
                            T1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            T1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    T1.DireccionI = myreader["direccion"].ToString();
                    T1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    T1.PrecioI = float.Parse(myreader["precio"].ToString());
                    lista.Add(T1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return lista;
        }


        public List<Terreno> selecTerrenoporPrecio(double precio)
        {
            List<Terreno> lista = new List<Terreno>();
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM Terreno WHERE precio>=?precio";
                DuenioABM D = new DuenioABM();
                comm.Parameters.AddWithValue("?precio", precio);




                //comm.CommandText = "SELECT * FROM propiedad WHERE direccion=?direccion AND nombre=?nombre";
                //comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                //comm.Parameters.AddWithValue("?nombre", P1.NombreI);

                MySqlDataReader myreader = comm.ExecuteReader();

                while (myreader.Read())
                {
                    Terreno T1 = new Terreno();
                    T1.NombreI = myreader["nombre"].ToString();
                    T1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    T1.DireccionI = myreader["direccion"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "2":
                            T1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            T1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    T1.PrecioI = float.Parse(myreader["precio"].ToString());
                    lista.Add(T1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
            }
            CM.desconectar();
            return lista;
        }
        public List<Terreno> selecTerrenoporSuperficie(int superficie)
        {
            List<Terreno> lista = new List<Terreno>();
            CM = new ConectarYDesconectar();
            CM.conectar();
            try
            {

                MySqlCommand comm = CM.con.CreateCommand();
                comm.CommandText = "SELECT * FROM Terreno WHERE superficie>=?superficie";
                DuenioABM D = new DuenioABM();
                comm.Parameters.AddWithValue("?superficie", superficie);




                //comm.CommandText = "SELECT * FROM propiedad WHERE direccion=?direccion AND nombre=?nombre";
                //comm.Parameters.AddWithValue("?direccion", P1.DireccionI);
                //comm.Parameters.AddWithValue("?nombre", P1.NombreI);

                MySqlDataReader myreader = comm.ExecuteReader();

                while (myreader.Read())
                {
                    Terreno T1 = new Terreno();
                    T1.NombreI = myreader["nombre"].ToString();
                    T1.SuperficieI = int.Parse(myreader["superficie"].ToString());
                    T1.DireccionI = myreader["direccion"].ToString();
                    switch (myreader["estado"].ToString())
                    {
                        case "2":
                            T1.EstadoI = estado.NoDisponible;
                            break;
                        case "1":
                            T1.EstadoI = estado.Venta;
                            break;
                        default:
                            Console.WriteLine("errror");
                            break;
                    }
                    T1.PrecioI = float.Parse(myreader["precio"].ToString());
                    lista.Add(T1);
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


