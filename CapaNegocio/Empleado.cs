using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ADODB;
using CapaNegocio;

namespace CapaNegocio
{
    public class Empleado
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
        protected string _usuario;
        protected int _rol;

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

        public string usuario
        {
            set { _usuario = value; }
            get {  return (_usuario); }
        }

        public int rol
        {
            set { _rol = value; }
            get { return (_rol); }
        }

        public Empleado()
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
            _usuario = "";
            _rol = 0;
        }

        public Empleado(int ci, string nom, string ape, string calle, string ciudad, int np, sbyte estado, List<string> tel, Connection cn, string tc, string user, int rol)
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
            _usuario = user;
            _rol = rol;
        }

        // Implementación de los métodos abstractos
        public byte BuscarEmpleado()
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
                sql = "SELECT p.nombre, p.apellido, p.nro_puerta, p.calle, p.ciudad, p.estado, e.id_rol, e.usuario " +
                    "FROM Persona p " +
                    "JOIN Empleado e ON p.ci = e.ci " +
                    "WHERE p.ci = " + ci;

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
                    _usuario = Convert.ToString(rs.Fields["usuario"].Value);
                    _rol = rs.Fields["id_rol"].Value;


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
                          "set nombre = '" + nombre + "', apellido = '" + apellido + "', nro_puerta = " + nroPuerta + ", calle = '" + calle + "', ciudad = '" + ciudad + "', estado = " + estado + " " +
                          "where ci = " + ci;

                    sql1 = "update Empleado " +
                           "set id_rol = " + rol + ", usuario = '" + usuario + "' " +
                           "where ci = " + ci;
                }
                else
                {
                    sql = "insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado) " +
                          "values (" + ci + ", '" + nombre + "', '" + apellido + "', " + nroPuerta + ", '" + calle + "', '" + ciudad + "', 1);";

                    sql1 = "insert into Empleado (ci, id_rol, usuario) " +
                           "values (" + ci + ", " + rol + ", '" + usuario + "');";
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

        public List<Empleado> ListarEmpleado()
        {
            List<Empleado> empleados = new List<Empleado>();
            Dictionary<int, Empleado> empleadosDict = new Dictionary<int, Empleado>();
            Recordset rs;
            object filasAfectadas;

            string sql = "SELECT p.ci, p.nombre, p.apellido, p.nro_puerta, p.calle, p.ciudad, p.estado, e.id_rol, e.usuario, t.telefono " +
                         "FROM Persona p " +
                         "JOIN Empleado e ON p.ci = e.ci " +
                         "JOIN Telefono t ON p.ci = t.ci " +
                         "WHERE p.estado = 1;";

            try
            {
                rs = _conexion.Execute(sql, out filasAfectadas);

                while (!rs.EOF)
                {
                    int ci = Convert.ToInt32(rs.Fields["ci"].Value);

                    // Verificar si el empleado ya está en el diccionario
                    if (!empleadosDict.ContainsKey(ci))
                    {
                        // Crear un nuevo empleado y agregarlo al diccionario
                        empleadosDict[ci] = new Empleado
                        {
                            ci = ci,
                            nombre = Convert.ToString(rs.Fields["nombre"].Value),
                            apellido = Convert.ToString(rs.Fields["apellido"].Value),
                            nroPuerta = Convert.ToInt32(rs.Fields["nro_puerta"].Value),
                            calle = Convert.ToString(rs.Fields["calle"].Value),
                            ciudad = Convert.ToString(rs.Fields["ciudad"].Value),
                            estado = Convert.ToSByte(rs.Fields["estado"].Value),
                            Telefonos = new List<string>(),
                            usuario = Convert.ToString(rs.Fields["usuario"].Value),
                            rol = Convert.ToInt32(rs.Fields["id_rol"].Value)
                        };
                    }

                    // Agregar el teléfono al empleado existente
                    empleadosDict[ci].Telefonos.Add(Convert.ToString(rs.Fields["telefono"].Value));

                    rs.MoveNext();
                }

                // Convertir el diccionario a lista
                empleados = empleadosDict.Values.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los empleados: " + ex.Message);
            }
            return empleados;
        }
    }
}