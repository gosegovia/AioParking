using ADODB;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        protected Cliente _cliente;
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

        public Cliente Cliente
        {
            set { _cliente = value; }
            get { return _cliente; }
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
            _cliente = new Cliente();
            _conexion = new Conexion();
        }

        public Vehiculo(string mat, int mar, string nommar, int tipo, string nombtipo, string nomve, bool es, Cliente cli, Conexion cn)
        {
            _matricula = mat;
            _marca = mar;
            _nombreMarca = nommar;
            _tipoVehiculo = tipo;
            _nombreTipo = nombtipo;
            _nombreVehiculo = nomve;
            _estadoVehiculo = es;
            _cliente = cli;
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

        public byte BuscarVehiculo()
        {
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            string sql = $"SELECT v.matricula, v.id_marca, v.id_tipo, v.estado_vehiculo, p.ci, m.nombre_marca, tv.nombre_tipo " +
                         $"FROM Vehiculo v " +
                         $"JOIN Posee p ON v.matricula = p.matricula " +
                         $"JOIN Marca m ON v.id_marca = m.id_marca " +
                         $"JOIN Tipo_Vehiculo tv ON v.id_tipo = tv.id_tipo " +
                         $"WHERE v.matricula = '{Matricula}'";

            DataTable dt = _conexion.EjecutarSelect(sql);

            if (dt.Rows.Count == 0)
            {
                return 3; // No encontrado
            }

            DataRow row = dt.Rows[0];
            Matricula = row["matricula"].ToString();
            marca = Convert.ToInt32(row["id_marca"]);
            NombreMarca = row["nombre_marca"].ToString();
            TipoVehiculo = Convert.ToInt32(row["id_tipo"]);
            NombreTipo = row["nombre_tipo"].ToString();
            EstadoVehiculo = Convert.ToBoolean(row["estado_vehiculo"]);
            Cliente.ci = Convert.ToInt32(row["ci"]);

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

        public List<Vehiculo> ListarVehiculo(int numeroPagina, int tamanioPagina, out Dictionary<string, int> vehiculosClientes)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            vehiculosClientes = new Dictionary<string, int>();

            if (!_conexion.Abierta())
            {
                throw new Exception("La conexión a la base de datos está cerrada.");
            }

            // Consulta SQL para listar vehículos con paginación
            string sql = $@"
                SELECT v.matricula, c.ci, v.id_tipo, v.estado_vehiculo, m.nombre_marca 
                FROM Vehiculo v 
                JOIN Marca m ON v.id_marca = m.id_marca 
                JOIN Posee p ON v.matricula = p.matricula 
                JOIN Cliente c ON p.ci = c.ci 
                WHERE v.estado_vehiculo = 1
                ORDER BY v.matricula
                LIMIT {tamanioPagina} OFFSET {numeroPagina * tamanioPagina};";

            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);

                foreach (DataRow row in dt.Rows)
                {
                    // Convertimos el estado del vehículo antes de evaluar
                    bool estadoVehiculo = Convert.ToBoolean(row["estado_vehiculo"]);

                    // Comprobamos si el estado del vehículo es 1 (activo)
                    if (!estadoVehiculo)
                    {
                        continue; // Si no está activo, saltamos al siguiente
                    }

                    string matricula = row["matricula"].ToString();
                    int ciCliente = Convert.ToInt32(row["ci"]);
                    int tipoVehiculo = Convert.ToInt32(row["id_tipo"]);
                    string nombreVehiculo = ObtenerNombreVehiculo(tipoVehiculo);

                    // Crear instancia del cliente
                    Cliente cliente = new Cliente
                    {
                        ci = ciCliente // Asignar el CI del cliente
                    };

                    vehiculos.Add(new Vehiculo
                    {
                        Matricula = matricula,
                        TipoVehiculo = tipoVehiculo,
                        NombreMarca = row["nombre_marca"].ToString(),
                        NombreVehiculo = nombreVehiculo,
                        Cliente = cliente // Asignar el cliente al vehículo
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
            string sql = "SELECT v.id_tipo, COUNT(*) AS Cantidad " +
                "FROM Vehiculo v " +
                "JOIN Factura f ON v.matricula = f.matricula " +
                "JOIN Solicita s ON f.id_factura = s.id_factura " +
                "JOIN Parking p ON s.id_parking = p.id_parking " +
                "JOIN Reserva r ON p.id_parking = r.id_parking " +
                "JOIN Plaza pla ON r.id_plaza = pla.id_plaza " +
                "WHERE p.hora_salida > NOW();";

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
