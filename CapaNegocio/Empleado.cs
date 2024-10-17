using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ADODB;
using CapaNegocio;
using CapaPersistencia;

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
        protected Conexion _conexion;
        protected string _usuario;
        protected int _rol;
        protected string _nombre_rol;

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

        public Conexion conexion
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

        public string Rol_Nombre
        {
            set { _nombre_rol = value; }
            get { return (_nombre_rol); }
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
            _conexion = new Conexion();  // Iniciar la conexión de la clase persistencia
            _usuario = "";
            _rol = 0;
            _nombre_rol = "";
        }

        public Empleado(int ci, string nom, string ape, string calle, string ciudad, int np, sbyte estado, List<string> tel, Conexion cn, string tc, string user, int rol, string nrol)
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
            _nombre_rol = nrol;
        }

        public byte BuscarEmpleado()
        {
            string sql;
            byte resultado = 0;
            DataTable dt;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                resultado = 1; // Conexión cerrada
            }
            else
            {
                // Consulta para obtener los datos del empleado
                sql = "SELECT p.nombre, p.apellido, p.nro_puerta, p.calle, p.ciudad, p.estado, e.id_rol, e.usuario " +
                      "FROM Persona p " +
                      "JOIN Empleado e ON p.ci = e.ci " +
                      "WHERE p.ci = " + _ci;

                try
                {
                    // Ejecutar la consulta y almacenar el resultado en un DataTable
                    dt = _conexion.EjecutarSelect(sql);
                }
                catch
                {
                    return 2; // Error en la ejecución
                }

                // Verificar si se encontró el empleado
                if (dt.Rows.Count == 0)
                {
                    resultado = 3; // No encontrado
                }
                else
                {
                    // Asignar los valores obtenidos a las propiedades del empleado
                    DataRow row = dt.Rows[0];
                    _nombre = Convert.ToString(row["nombre"]);
                    _apellido = Convert.ToString(row["apellido"]);
                    _nro_puerta = Convert.ToInt32(row["nro_puerta"]);
                    _calle = Convert.ToString(row["calle"]);
                    _ciudad = Convert.ToString(row["ciudad"]);
                    _estado = Convert.ToSByte(row["estado"]);
                    _usuario = Convert.ToString(row["usuario"]);
                    _rol = Convert.ToInt32(row["id_rol"]);

                    // Consulta para obtener los teléfonos asociados al empleado
                    sql = "SELECT telefono FROM Telefono WHERE ci = " + _ci;

                    try
                    {
                        // Ejecutar la consulta para obtener los teléfonos
                        dt = _conexion.EjecutarSelect(sql);
                    }
                    catch
                    {
                        return 4; // Error al obtener los teléfonos
                    }

                    // Limpiar la lista de teléfonos actual y agregar los nuevos
                    _telefonos.Clear();
                    foreach (DataRow telefonoRow in dt.Rows)
                    {
                        _telefonos.Add(Convert.ToString(telefonoRow["telefono"]));
                    }
                }
            }
            return resultado;
        }

        public byte Eliminar()
        {
            byte resultado = 0;
            string sql;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                resultado = 1; // Conexión cerrada
            }
            else
            {
                // SQL para actualizar el estado de la persona a 0 (eliminar lógicamente)
                sql = "UPDATE Persona " +
                      "SET estado = 0 " +
                      "WHERE ci = " + _ci;

                try
                {
                    // Ejecutar la consulta y verificar si se modificaron registros
                    object filasAfectadas = _conexion.Ejecutar(sql);
                    if (filasAfectadas == null)
                    {
                        resultado = 3; // No se modificaron registros, posible CI inexistente
                    }

                }
                catch
                {
                    return 2; // Error en la ejecución
                }
            }
            return resultado;
        }


        // Metodo guardar
        public byte Guardar(Boolean modificacion)
        {
            byte resultado = 0;
            string sql, sql1;

            if (!_conexion.Abierta()) // La conexión está cerrada
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
                    _conexion.Ejecutar(sql);
                    _conexion.Ejecutar(sql1);
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
                        _conexion.Ejecutar(sql);
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
                        _conexion.Ejecutar(sql);
                    }
                    catch
                    {
                        return 4; // Error al ejecutar el insert
                    }
                }
            }
            return resultado;
        } // Fin Método guardar

        public List<Empleado> ListarEmpleados(int numeroPagina, int tamanioPagina)
        {
            List<Empleado> empleados = new List<Empleado>();
            Dictionary<int, Empleado> empleadosDict = new Dictionary<int, Empleado>();

            if (!_conexion.Abierta())
            {
                throw new Exception("La conexión a la base de datos está cerrada.");
            }

            // Consulta SQL para listar empleados con paginación
            string sql = $@"
                SELECT p.ci, p.nombre, p.apellido, p.nro_puerta, p.calle, p.ciudad, p.estado, r.nombre_rol, e.usuario, t.telefono
                FROM Persona p
                JOIN Empleado e ON p.ci = e.ci
                JOIN Rol r ON r.id_rol = e.id_rol
                JOIN Telefono t ON p.ci = t.ci
                WHERE p.estado = 1
                ORDER BY p.ci
                LIMIT {tamanioPagina} OFFSET {numeroPagina * tamanioPagina};";

            try
            {
                DataTable dt = _conexion.EjecutarSelect(sql);

                foreach (DataRow row in dt.Rows)
                {
                    int ci = Convert.ToInt32(row["ci"]);

                    // Verifica si el empleado ya está en el diccionario
                    if (!empleadosDict.ContainsKey(ci))
                    {
                        empleadosDict[ci] = new Empleado
                        {
                            ci = ci,
                            nombre = row["nombre"].ToString(),
                            apellido = row["apellido"].ToString(),
                            nroPuerta = Convert.ToInt32(row["nro_puerta"]),
                            calle = row["calle"].ToString(),
                            ciudad = row["ciudad"].ToString(),
                            estado = Convert.ToSByte(row["estado"]),
                            usuario = row["usuario"].ToString(),
                            Rol_Nombre = row["nombre_rol"].ToString(),
                            Telefonos = new List<string>()
                        };
                    }

                    // Agrega el teléfono al empleado existente
                    empleadosDict[ci].Telefonos.Add(row["telefono"].ToString());
                }

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