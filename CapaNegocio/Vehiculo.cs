using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace CapaNegocio
{
    public class Vehiculo
    {
        protected string _matricula;
        protected int _marca;
        protected string _nombreMarca;
        protected int _tipoVehiculo;
        protected string _nombreTipo;
        protected string _nombreVehiculo;
        protected bool _estadoVehiculo;
        protected Conexion _conexion;

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        public int marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public string NombreMarca
        {
            get { return _nombreMarca; }
            set { _nombreMarca = value; }
        }

        public int TipoVehiculo
        {
            get { return _tipoVehiculo; }
            set { _tipoVehiculo = value; }
        }

        public string NombreTipo
        {
            get { return _nombreTipo; }
            set { _nombreTipo = value; }
        }

        public string NombreVehiculo
        {
            get { return _nombreVehiculo; }
            set { _nombreVehiculo = value; }
        }

        public bool EstadoVehiculo
        {
            get { return _estadoVehiculo; }
            set { _estadoVehiculo = value; }
        }

        public Conexion Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public class Marca
        {
            public int IdMarca { get; set; }
            public string NombreMarca { get; set; }
        }


        public Vehiculo()
        {
            _matricula = "";
            _marca = 0;
            _nombreMarca = "";
            _tipoVehiculo = 0;
            _nombreTipo = "";
            _nombreVehiculo = "";
            _estadoVehiculo = false;
            _conexion = new Conexion();
        }

        public Vehiculo(string mat, int mar, string nommar, int tipo, string nombtipo, string nomve, bool es, Conexion cn)
        {
            _matricula = mat;
            _marca = mar;
            _nombreMarca = nommar;
            _tipoVehiculo = tipo;
            _nombreTipo = nombtipo;
            _nombreVehiculo = nomve;
            _estadoVehiculo = es;
            _conexion = cn;
        }

        public byte BuscarMatricula(int ci)
        {
            if (!_conexion.Abierta())
                return 1; // Conexión cerrada

            string sql = "SELECT p.ci, p.matricula, m.nombre_marca, t.nombre_tipo " +
                "FROM Posee p " +
                "JOIN Vehiculo v ON p.matricula = v.matricula " +
                "JOIN Marca m ON v.id_marca = m.id_marca " +
                "JOIN Tipo_Vehiculo t ON t.id_tipo = v.id_tipo " +
                "WHERE p.ci = " + ci + " AND p.matricula = '" + Matricula + "';";

            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);
                if (dt.Rows.Count == 0)
                {
                    return 3; // No encontrado
                } else
                {
                    // Asignar los valores a las propiedades y convertir a int
                    DataRow row = dt.Rows[0];
                    NombreMarca = row["nombre_marca"].ToString();
                    NombreTipo = row["nombre_tipo"].ToString();
                }
            }
            catch
            {
                return 2; // Error en la ejecución
            }

            return 0; // Encontrado
        }

        public byte BuscarVehiculo(Cliente c)
        {
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            string sql = $"SELECT v.matricula, v.id_marca, v.id_tipo, v.estado_vehiculo, p.ci " +
                         $"FROM Vehiculo v " +
                         $"JOIN Posee p ON v.matricula = p.matricula " +
                         $"WHERE v.matricula = '{_matricula}'";

            DataTable dt = _conexion.EjecutarSelect(sql);

            if (dt.Rows.Count == 0)
            {
                return 3; // No encontrado
            }

            DataRow row = dt.Rows[0];
            _matricula = row["matricula"].ToString();
            _marca = Convert.ToInt32(row["id_marca"]);
            _tipoVehiculo = Convert.ToInt32(row["id_tipo"]);
            EstadoVehiculo = Convert.ToBoolean(row["estado_vehiculo"]);
            c.ci = Convert.ToInt32(row["ci"]);

            return 0; // Encontrado
        }

        public List<Marca> ObtenerMarcas()
        {
            // Lista para almacenar las marcas obtenidas
            var marcas = new List<Marca>();
            string sql = "SELECT id_marca, nombre_marca FROM Marca order by id_marca";

            try
            {
                // Ejecutar la consulta y obtener los resultados en un DataTable
                DataTable dt = _conexion.EjecutarSelect(sql);

                // Convertir cada fila del DataTable en un objeto Marca
                marcas = dt.AsEnumerable()
                           .Select(row => new Marca
                           {
                               IdMarca = row.Field<int>("id_marca"),
                               NombreMarca = row.Field<string>("nombre_marca")
                           })
                           .ToList();
            }
            catch (Exception ex)
            {
                // Lanzar una excepción con más información sobre el error
                throw new Exception("Error al obtener las marcas: " + ex.Message, ex);
            }

            return marcas;
        }

        public byte Guardar(bool modificacion, Cliente c)
        {
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            string sql;
            string sql1 = null; // Inicializamos sql1 como null

            if (modificacion)
            {
                // Consulta para actualizar los datos del vehículo
                sql = "UPDATE Vehiculo " +
                      "SET id_marca = " + marca + ", id_tipo = " + TipoVehiculo + ", estado_vehiculo = 1 " +
                      "WHERE matricula = '" + Matricula + "';";
            }
            else
            {
                sql = "INSERT INTO Vehiculo (matricula, id_marca, id_tipo, estado_vehiculo) VALUES " +
                      "('" + Matricula + "', " + marca + ", " + TipoVehiculo + ", 1);";

                sql1 = "INSERT INTO Posee (ci, matricula) VALUES (" + c.ci + ", '" + Matricula + "');";
            }

            try
            {
                // Ejecutar la consulta SQL para el vehículo
                _conexion.Ejecutar(sql);

                // Solo ejecutamos el segundo SQL si estamos en modo alta
                if (!modificacion && sql1 != null)
                {
                    _conexion.Ejecutar(sql1);
                }
            }
            catch
            {
                return 2; // Error en el insert o update
            }

            return 0; // Guardado correctamente
        }


        public byte Eliminar()
        {
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            string sql = "UPDATE Vehiculo " +
                    "SET estado_vehiculo = 0 " +
                    "WHERE matricula = '" + Matricula + "'"; ;

            try
            {
                _conexion.Ejecutar(sql);
            }
            catch
            {
                return 2; // Error en la eliminación
            }

            return 0; // Eliminado correctamente
        }

        public List<Vehiculo> ListarVehiculo(out Dictionary<string, int> vehiculosClientes)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            vehiculosClientes = new Dictionary<string, int>();

            string sql = "SELECT v.matricula, c.ci, v.id_tipo, v.estado_vehiculo, m.nombre_marca " +
             "FROM Vehiculo v " +
             "JOIN Marca m ON v.id_marca = m.id_marca " +
             "JOIN Posee p ON v.matricula = p.matricula " +
             "JOIN Cliente c ON p.ci = c.ci;";


            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);

                foreach (DataRow row in dt.Rows)
                {
                    // Convertimos el estado del vehículo antes de evaluar
                    bool estadoVehiculo = Convert.ToBoolean(row["estado_vehiculo"]);

                    // Comprobamos si el estado del vehículo es 1 (inactivo)
                    if (estadoVehiculo == false) // Si 'estado_vehiculo' es 0, lo ignoramos
                    {
                        continue; // Salta a la siguiente iteración del bucle
                    }

                    string matricula = row["matricula"].ToString();
                    int ciCliente = Convert.ToInt32(row["ci"]);
                    int tipoVehiculo = Convert.ToInt32(row["id_tipo"]);
                    string nombreVehiculo = ObtenerNombreVehiculo(tipoVehiculo);

                    vehiculos.Add(new Vehiculo
                    {
                        Matricula = matricula,
                        TipoVehiculo = tipoVehiculo,
                        NombreMarca = row["nombre_marca"].ToString(),
                        NombreVehiculo = nombreVehiculo,

                    });

                    vehiculosClientes[matricula] = ciCliente;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los vehículos: " + ex.Message);
            }

            return vehiculos;
        }

        private string ObtenerNombreVehiculo(int tipoVehiculo)
        {
            switch (tipoVehiculo)
            {
                case 1: return "Moto";
                case 2: return "Auto";
                case 3: return "Camioneta";
                case 4: return "Utilitario";
                case 5: return "Camión";
                default: return "Desconocido";
            }
        }

        public Dictionary<int, int> VehiculosActuales()
        {
            if (!_conexion.Abierta())
                throw new InvalidOperationException("La conexión está cerrada.");

            var resultado = new Dictionary<int, int>();
            string sql = "SELECT id_tipo, COUNT(*) AS Cantidad FROM Vehiculo GROUP BY id_tipo;";

            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);

                foreach (DataRow row in dt.Rows)
                {
                    int tipoVehiculo = Convert.ToInt32(row["id_tipo"]);
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    resultado[tipoVehiculo] = cantidad;
                }
            }
            catch
            {
                throw new Exception("Error al obtener la cantidad de vehículos actuales.");
            }

            return resultado;
        }
    }
}
