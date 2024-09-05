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
        protected string _nombreVehiculo;
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

        public string NombreVehiculo
        {
            get { return _nombreVehiculo; }
            set { _nombreVehiculo = value; }
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
            _nombreVehiculo = "";
            _conexion = new Conexion();
        }

        public Vehiculo(string mat, int mar, string nommar, int tipo, string nomve, Conexion cn)
        {
            _matricula = mat;
            _marca = mar;
            _nombreMarca = nommar;
            _tipoVehiculo = tipo;
            _nombreVehiculo = nomve;
            _conexion = cn;
        }

        public byte BuscarMatricula(int ci)
        {
            if (!_conexion.Abierta())
                return 1; // Conexión cerrada

            string sql = $"SELECT ci, matricula FROM Posee WHERE ci = {ci} AND matricula = '{_matricula}'";

            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);
                if (dt.Rows.Count == 0)
                    return 3; // No encontrado
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
                return 1; // Conexión cerrada

            string sql = $"SELECT v.matricula, v.id_marca, v.tipo_vehiculo, p.ci FROM Vehiculo v " +
                         $"JOIN Posee p ON v.matricula = p.matricula WHERE v.matricula = '{_matricula}'";

            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);
                if (dt.Rows.Count == 0)
                    return 3; // No encontrado

                DataRow row = dt.Rows[0];
                _matricula = row["matricula"].ToString();
                _marca = Convert.ToInt32(row["id_marca"]);
                _tipoVehiculo = Convert.ToInt32(row["tipo_vehiculo"]);
                c.ci = Convert.ToInt32(row["ci"]);
            }
            catch
            {
                return 2; // Error en la ejecución
            }
            return 0; // Encontrado
        }

        public List<Marca> ObtenerMarcas()
        {
            // Lista para almacenar las marcas obtenidas
            var marcas = new List<Marca>();
            string sql = "SELECT id_marca, nombre_marca FROM Marca";

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
                return 1; // Conexión cerrada

            string sql = modificacion
                ? $"UPDATE Vehiculo SET id_marca = {marca}, tipo_vehiculo = {TipoVehiculo} WHERE matricula = '{Matricula}'"
                : $"INSERT INTO Vehiculo (matricula, id_marca, tipo_vehiculo) VALUES ('{Matricula}', {marca}, {TipoVehiculo})";

            try
            {
                _conexion.Ejecutar(sql);

                if (!modificacion)
                {
                    sql = $"INSERT INTO Posee (ci, matricula) VALUES ({c.ci}, '{Matricula}')";
                    _conexion.Ejecutar(sql);
                }
            }
            catch
            {
                return modificacion ? (byte)2 : (byte)3; // Error en ejecución de actualización o inserción
            }

            return 0; // Guardado correctamente
        }

        public byte Eliminar()
        {
            if (!_conexion.Abierta())
                return 1; // Conexión cerrada

            string sql = $"DELETE FROM Factura WHERE matricula = '{Matricula}';";

            try
            {
                _conexion.Ejecutar(sql);
                sql = $"DELETE FROM Posee WHERE matricula = '{Matricula}';";
                _conexion.Ejecutar(sql);
                sql = $"DELETE FROM Vehiculo WHERE matricula = '{Matricula}';";
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

            string sql = "SELECT DISTINCT v.matricula, c.ci, v.tipo_vehiculo, m.nombre_marca " +
                         "FROM Vehiculo v " +
                         "JOIN Marca m ON v.id_marca = m.id_marca " +
                         "JOIN Posee p ON v.matricula = p.matricula " +
                         "JOIN Cliente c ON p.ci = c.ci;";

            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);

                foreach (DataRow row in dt.Rows)
                {
                    string matricula = row["matricula"].ToString();
                    int ciCliente = Convert.ToInt32(row["ci"]);
                    int tipoVehiculo = Convert.ToInt32(row["tipo_vehiculo"]);
                    string nombreVehiculo = ObtenerNombreVehiculo(tipoVehiculo);

                    vehiculos.Add(new Vehiculo
                    {
                        Matricula = matricula,
                        TipoVehiculo = tipoVehiculo,
                        NombreMarca = row["nombre_marca"].ToString(),
                        NombreVehiculo = nombreVehiculo
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
                case 1: return "Auto";
                case 2: return "Utilitario";
                case 3: return "Moto";
                case 4: return "Camioneta";
                case 5: return "Camión";
                default: return "Desconocido";
            }
        }


        public Dictionary<int, int> VehiculosActuales()
        {
            if (!_conexion.Abierta())
                throw new InvalidOperationException("La conexión está cerrada.");

            var resultado = new Dictionary<int, int>();
            string sql = "SELECT tipo_vehiculo, COUNT(*) AS Cantidad FROM Vehiculo GROUP BY tipo_vehiculo;";

            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);

                foreach (DataRow row in dt.Rows)
                {
                    int tipoVehiculo = Convert.ToInt32(row["tipo_vehiculo"]);
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
