using ADODB;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class Vehiculo
    {
        // Definición de la clase Vehiculo
        protected int _ci;
        protected string _matricula;
        protected int _marca;
        protected int _tipoVehiculo;
        protected Connection _conexion;

        public int ci
        {
            get { return _ci; }
            set { _ci = value; }
        }

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
            _ci = 0;
            _matricula = "";
            _marca = 0;
            _tipoVehiculo = 0;
            _conexion = new Connection();
        }

        public Vehiculo(int ci, string mat, int mar, int tipo, Connection cn)
        {
            _ci = ci;
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

        public byte BuscarVehiculo()
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
                    _ci = Convert.ToInt32(rs.Fields["ci"].Value);
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
        public byte Guardar(bool modificacion)
        {
            byte resultado = 0;
            object filasAfectadas;
            string sql, sql1;

            if (_conexion.State == 0) // La conexión está cerrada
            {
                resultado = 1;
            }
            else
            {
                if (modificacion)
                {
                    // Aquí va el código para modificar un registro
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
                        "values ("+ci+", '" + matricula + "');";
                }
            }

            return resultado;
        }
    }
}
