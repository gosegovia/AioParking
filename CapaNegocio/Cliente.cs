using System;
using System.Collections.Generic;
using System.Data;
using ADODB;
using CapaNegocio;

namespace CapaNegocio
{
    public class Cliente
    {
        protected int _ci;
        protected string _nombre;
        protected string _apellido;
        protected string _calle;
        protected string _ciudad;
        protected int _nro_puerta;
        protected sbyte _estado;
        protected List<string> _telefonos;
        protected Connection _conexion;
        protected string _tipoCliente;

        public int ci
        {
            set { _ci = value; }
            get { return (_ci); }
        }

        public string nombre
        {
            set { _nombre = value; }
            get { return (_nombre); }
        }

        public string apellido
        {
            set { _apellido = value; }
            get { return (_apellido); }
        }

        public string calle
        {
            set { _calle = value; }
            get { return (_calle); }
        }

        public string ciudad
        {
            set { _ciudad = value; }
            get { return (_ciudad); }
        }

        public int nroPuerta
        {
            set { _nro_puerta = value; }
            get { return (_nro_puerta); }
        }

        public sbyte estado
        {
            set { _estado = value; }
            get { return (_estado); }
        }

        public List<string> Telefonos
        {
            get { return _telefonos; }
            set { _telefonos = value; }
        }

        public ADODB.Connection conexion
        {
            set { _conexion = value; }
            get { return (_conexion); }
        }

        public string TipoCliente
        {
            set { _tipoCliente = value; }
            get { return (_tipoCliente); }
        }

        public Cliente()
        {
            _ci = 0;
            _nombre = "";
            _apellido = "";
            _calle = "";
            _ciudad = "";
            _nro_puerta = 0;
            _estado = 0;
            _telefonos = new List<string>();
            _conexion = new Connection();
            _tipoCliente = "";
        }

        public Cliente(int ci, string nom, string ape, string calle, string ciudad, int np, sbyte estado, List<string> tel, Connection cn, string tc)
        {
            _ci = ci;
            _nombre = nom;
            _apellido = ape;
            _calle = calle;
            _ciudad = ciudad;
            _nro_puerta = np;
            _estado = estado;
            _telefonos = tel;
            _conexion = cn;
            _tipoCliente = tc;
        }

        public byte BuscarCI()
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
                sql = "SELECT ci " +
                      "FROM Cliente " +
                      "WHERE ci = " + ci;

                rs = _conexion.Execute(sql, out filasAfectadas);

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

        // Implementación de los métodos abstractos
        public byte Buscar()
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
                sql = "SELECT p.nombre, p.apellido, p.nro_puerta, p.calle, p.ciudad, p.estado, c.tipo_cliente " +
                "FROM Persona p " +
                "JOIN Cliente c ON p.ci = c.ci " +
                "WHERE p.ci =" + ci;

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
                    _nombre = Convert.ToString(rs.Fields["nombre"].Value);
                    _apellido = Convert.ToString(rs.Fields["apellido"].Value);
                    _nro_puerta = rs.Fields["nro_puerta"].Value;
                    _calle = Convert.ToString(rs.Fields["calle"].Value);
                    _ciudad = Convert.ToString(rs.Fields["ciudad"].Value);
                    _estado = (sbyte)rs.Fields["estado"].Value;
                    _tipoCliente = Convert.ToString(rs.Fields["tipo_cliente"].Value);


                    // Obtener los teléfonos del cliente
                    sql = $"SELECT telefono FROM Telefono WHERE ci=" + _ci;

                    try
                    {
                        rs = _conexion.Execute(sql, out filasAfectadas);
                    }
                    catch
                    {
                        return 4; // Error al obtener los teléfonos
                    }

                    _telefonos.Clear();
                    while (!rs.EOF)
                    {
                        _telefonos.Add(Convert.ToString(rs.Fields["telefono"].Value));
                        rs.MoveNext();
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
                sql = "UPDATE Persona " +
                      "SET estado = 0 " +
                      "WHERE ci = " + _ci;


                try
                {
                    _conexion.Execute(sql, out filasAfectadas);
                }
                catch
                {
                    return (2);
                }
                filasAfectadas = null;
            }
            return (resultado);
        }

        // Metodo guardar
        public byte Guardar(Boolean modificacion)
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
                    sql = "update Persona " +
                          "set nombre = '" + nombre + "', apellido = '" + apellido + "', nro_puerta = " + nroPuerta + ", calle = '" + calle + "', ciudad = '" + ciudad + "' " +
                          "where ci = " + ci;
                    sql1 = "update Cliente " +
                           "set tipo_cliente = '" + TipoCliente + "' " +
                           "where ci = " + ci;
                }
                else
                {
                    sql = "insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado) " +
                          "values (" + ci + ", '" + nombre + "', '" + apellido + "', " + nroPuerta + ", '" + calle + "', '" + ciudad + "', 1);";
                    sql1 = "insert into Cliente (ci, tipo_cliente) " +
                           "values (" + ci + ", '" + TipoCliente + "');";
                }

                try
                {
                    _conexion.Execute(sql, out filasAfectadas);
                    _conexion.Execute(sql1, out filasAfectadas);
                }
                catch
                {
                    return 2; // Error al hacer el update o el insert    
                }

                if (modificacion)
                {
                    sql = "delete from Telefono where ci = " + ci;
                    try
                    {
                        _conexion.Execute(sql, out filasAfectadas);
                    }
                    catch
                    {
                        return 3; // Error al borrar los teléfonos
                    }
                }

                foreach (string telefono in _telefonos)
                {
                    sql = "insert into Telefono(ci, telefono) " +
                          "values(" + ci + ", '" + telefono + "')";

                    try
                    {
                        _conexion.Execute(sql, out filasAfectadas);
                    }
                    catch
                    {
                        return 4; // Error al ejecutar el insert
                    }
                }
            }

            filasAfectadas = null; // Liberar memoria

            return resultado;
        } // Fin Método guardar
    }
}