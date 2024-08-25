using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaNegocio
{
    public class Vehiculo
    {
        // Definición de la clase Vehiculo
        protected string _matricula;
        protected int _marca;
        protected int _tipoVehiculo;
        protected Connection _conexion;

        public string matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        public int marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public int tipoVehiculo
        {
            get { return _tipoVehiculo; }
            set { _tipoVehiculo = value; }
        }

        public ADODB.Connection conexion
        {
            set { _conexion = value; }
            get { return (_conexion); }
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
            _tipoVehiculo = 0;
            _conexion = new Connection();
        }

        public Vehiculo(string mat, int mar, int tipo, Connection cn)
        {
            _matricula = mat;
            _marca = mar;
            _tipoVehiculo = tipo;
            _conexion = cn;
        }

        public byte BuscarMatricula(int ci)
        {
            string sql;
            object filasAfectadas;
            Recordset rs;
            byte resultado = 0;

            if (_conexion.State == 0)
            {
                resultado = 1; // Conexión cerrada
            }
            else
            {
                sql = "SELECT ci, matricula " +
                      "FROM Posee " +
                      "WHERE ci = " + ci + " AND matricula = '" + matricula + "';";

                try
                {
                    rs = _conexion.Execute(sql, out filasAfectadas);
                }
                catch
                {
                    return 2; // Error en la ejecución
                }

                if (rs.RecordCount == 0)
                {
                    resultado = 3; // No encontrado
                }
            }
            return resultado;
        }

        public byte BuscarVehiculo(Cliente c)
        {
            string sql;
            object filasAfectadas;
            Recordset rs;
            byte resultado = 0;

            if (_conexion.State == 0)
            {
                resultado = 1; // Conexión cerrada
            }
            else
            {
                sql = "SELECT v.matricula, v.id_marca, v.tipo_vehiculo, p.ci " +
                      "FROM Vehiculo v " +
                      "JOIN Posee p ON v.matricula = p.matricula " +
                      "WHERE v.matricula = '" + matricula + "'";

                try
                {
                    rs = _conexion.Execute(sql, out filasAfectadas);
                }
                catch
                {
                    return 2; // Error en la ejecución
                }

                if (rs.RecordCount == 0)
                {
                    resultado = 3; // No encontrado
                }
                else
                {
                    _matricula = Convert.ToString(rs.Fields["matricula"].Value);
                    _marca = Convert.ToInt32(rs.Fields["id_marca"].Value);
                    _tipoVehiculo = Convert.ToInt32(rs.Fields["tipo_vehiculo"].Value);
                    c.ci = Convert.ToInt32(rs.Fields["ci"].Value);

                }
            }
            return resultado;
        }

        // Método para obtener las marcas
        public List<Marca> ObtenerMarcas()
        {
            List<Marca> marcas = new List<Marca>();
            string sql = "SELECT id_marca, nombre_marca FROM Marca";
            Recordset rs;
            object filasAfectadas;

            try
            {
                rs = _conexion.Execute(sql, out filasAfectadas);

                while (!rs.EOF)
                {
                    marcas.Add(new Marca
                    {
                        IdMarca = Convert.ToInt32(rs.Fields["id_marca"].Value),
                        NombreMarca = Convert.ToString(rs.Fields["nombre_marca"].Value)
                    });
                    rs.MoveNext();
                }
            }
            catch
            {
                throw new Exception("Error al obtener las marcas");
            }

            return marcas;
        }

        // Método Guardar
        public byte Guardar(bool modificacion, Cliente c)
        {
            byte resultado = 0;
            object filasAfectadas;
            string sql;

            if (_conexion.State == 0) // La conexión está cerrada
            {
                resultado = 1;
            }
            else
            {
                if (modificacion)
                {
                    sql = "UPDATE Vehiculo " +
                        "SET id_marca = " + marca + ", tipo_vehiculo = " + tipoVehiculo + " " +
                        "WHERE matricula = '" + matricula + "'";
                }
                else
                {
                    sql = "INSERT INTO Vehiculo (matricula, id_marca, tipo_vehiculo) " +
                          "VALUES ('" + matricula + "', " + marca + ", "+ tipoVehiculo +")";
                    try
                    {
                        _conexion.Execute(sql, out filasAfectadas);
                    }
                    catch
                    {
                        return 2; // Error al hacer el update o el insert    
                    }

                    sql = "insert into Posee (ci, matricula) " +
                        "values (" + c.ci + ", '" + matricula + "');";

                    try
                    {
                        _conexion.Execute(sql, out filasAfectadas);
                    }
                    catch
                    {
                        return 3; // Error al insertar en la tabla posee 
                    }
                }
            }
            return resultado;
        }

        public byte Eliminar()
        {
            byte resultado = 0;
            object filasAfectadas;
            string sql;

            if (_conexion.State == 0)
            {
                resultado = 1;
            }
            else
            {
                sql = "DELETE FROM Factura WHERE matricula = '" + matricula + "'; ";


                _conexion.Execute(sql, out filasAfectadas);

                try
                {
                    _conexion.Execute(sql, out filasAfectadas);
                }
                catch
                {
                    return (2);
                }

                sql = "DELETE FROM Posee WHERE matricula = '" + matricula + "'; ";

                try
                {
                    _conexion.Execute(sql, out filasAfectadas);
                }
                catch
                {
                    return (3);
                }

                sql = "DELETE FROM Vehiculo WHERE matricula = '" + matricula + "'; ";

                try
                {
                    _conexion.Execute(sql, out filasAfectadas);
                }
                catch
                {
                    return (4);
                }

                filasAfectadas = null;
            }
            return (resultado);
        }

        public List<Vehiculo> ListarVehiculo(out Dictionary<string, int> vehiculosClientes)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            Dictionary<string, Vehiculo> vehiculosDict = new Dictionary<string, Vehiculo>();
            vehiculosClientes = new Dictionary<string, int>();
            Recordset rs;
            object filasAfectadas;

            string sql = "SELECT DISTINCT v.matricula, c.ci, v.tipo_vehiculo, m.nombre_marca " +
                "FROM Vehiculo v " +
                "JOIN Marca m ON v.id_marca = m.id_marca " +
                "JOIN Posee p ON v.matricula = p.matricula " +
                "JOIN Cliente c ON p.ci = c.ci;";

            try
            {
                rs = conexion.Execute(sql, out filasAfectadas);

                while (!rs.EOF)
                {
                    string matricula = Convert.ToString(rs.Fields["matricula"].Value);
                    int ciCliente = Convert.ToInt32(rs.Fields["ci"].Value);

                    // Verificar si el vehículo ya está en el diccionario
                    if (!vehiculosDict.ContainsKey(matricula))
                    {
                        vehiculosDict[matricula] = new Vehiculo
                        {
                            _matricula = matricula,
                            _tipoVehiculo = Convert.ToInt32(rs.Fields["tipo_vehiculo"].Value),
                            _marca = Convert.ToString(rs.Fields["nombre_marca"].Value)
                        };

                        vehiculosClientes[matricula] = ciCliente;
                    }

                    rs.MoveNext();
                }

                vehiculos = vehiculosDict.Values.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los vehículos: " + ex.Message);
            }
            return vehiculos;
        }
    }
}
