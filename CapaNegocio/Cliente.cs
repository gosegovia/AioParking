using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CapaPersistencia; // Asegúrate de importar la nueva capa de persistencia

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
        protected Conexion _conexion;  // Cambiado a usar la clase Conexion
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

        public Conexion conexion
        {
            set { _conexion = value; }
            get { return (_conexion); }
        }

        public string TipoCliente
        {
            set { _tipoCliente = value; }
            get { return (_tipoCliente); }
        }

        // Propiedades

        // Constructor sin parámetros
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
            _conexion = new Conexion();  // Iniciar la conexión de la clase persistencia
            _tipoCliente = "";
        }

        // Constructor con parámetros
        public Cliente(int ci, string nom, string ape, string calle, string ciudad, int np, sbyte estado, List<string> tel, Conexion cn, string tc)
        {
            _ci = ci;
            _nombre = nom;
            _apellido = ape;
            _calle = calle;
            _ciudad = ciudad;
            _nro_puerta = np;
            _estado = estado;
            _telefonos = tel;
            _conexion = cn;  // Usar la nueva clase Conexion
            _tipoCliente = tc;
        }

        // Método para buscar cliente por CI
        public byte BuscarCI()
        {
            byte resultado = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Definir la consulta SQL para buscar por CI
            string sql = $"SELECT ci FROM Cliente WHERE ci = " + ci;

            try
            {
                // Ejecutar la consulta y obtener los resultados en un DataTable
                DataTable dt = _conexion.EjecutarSelect(sql);

                // Verificar si se encontraron filas en el resultado
                if (dt == null || dt.Rows.Count == 0)
                {
                    resultado = 3; // No encontrado
                }
            }
            catch
            {
                return 2; // Error en la ejecución de la consulta
            }

            return resultado;
        }

        // Metodo para buscar cliente
        public byte Buscar()
        {
            byte resultado = 0;

            // Chequeo el estado de la conexion
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            try
            {
                // Consulta principal para obtener los datos del cliente
                string sql = $"SELECT p.nombre, p.apellido, p.nro_puerta, p.calle, p.ciudad, p.estado, c.tipo_cliente " +
                             $"FROM Persona p JOIN Cliente c ON p.ci = c.ci WHERE p.ci = " + ci;

                // Ejecutamos la consulta
                DataTable dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count == 0)
                {
                    return 3; // No encontrado un cliennte
                }

                // Asignar valores desde la consulta
                DataRow row = dt.Rows[0];
                _nombre = row["nombre"].ToString();
                _apellido = row["apellido"].ToString();
                _nro_puerta = Convert.ToInt32(row["nro_puerta"]);
                _calle = row["calle"].ToString();
                _ciudad = row["ciudad"].ToString();
                _estado = Convert.ToSByte(row["estado"]);
                _tipoCliente = row["tipo_cliente"].ToString();

                // Obtener los teléfonos del cliente
                sql = $"SELECT telefono FROM Telefono WHERE ci = " + ci;

                // Ejecutar la consulta para los telefonos
                dt = _conexion.EjecutarSelect(sql);

                // Convertir los teléfonos a string y guardarlos en la lista
                _telefonos = dt.AsEnumerable().Select(r => r.Field<object>("telefono").ToString()).ToList();
            }
            catch
            {
                return 2; // Error en la ejecución de la consulta
            }
            return resultado; // Todo funciono correctamente
        }


        // Método para eliminar un cliente
        public byte Eliminar()
        {
            byte resultado = 0;

            // Chequeo el estado de la conexion
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Consulta para hacer borrado logico de cliente
            string sql = $"UPDATE Persona SET estado = 0 WHERE ci = " + ci;

            try
            {
                // Ejecuto la consulta
                _conexion.Ejecutar(sql);
            }
            catch
            {
                return 2; // Error al ejecutar la actualización
            }
            return resultado; // Datos obtenidos correctamente
        } // Fin metodo para eliminar cliente

        public byte Guardar(bool modificacion)
        {
            byte resultado = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Definir las consultas SQL para insertar o actualizar
            string sql, sql1;

            if (modificacion)
            {
                // Consulta para actualizar los datos del cliente
                sql = $"UPDATE Persona SET nombre = '{nombre}', apellido = '{apellido}', nro_puerta = {nroPuerta}, calle = '{calle}', ciudad = '{ciudad}', estado = {estado} WHERE ci = {ci}";
                sql1 = $"UPDATE Cliente SET tipo_cliente = '{TipoCliente}' WHERE ci = {ci}";
            }
            else
            {
                // Consulta para insertar un nuevo cliente
                sql = $"INSERT INTO Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado) VALUES ({ci}, '{nombre}', '{apellido}', {nroPuerta}, '{calle}', '{ciudad}', 1)";
                sql1 = $"INSERT INTO Cliente (ci, tipo_cliente) VALUES ({ci}, '{TipoCliente}')";
            }

            try
            {
                // Ejecutar la consulta SQL para Persona
                _conexion.Ejecutar(sql);
                // Ejecutar la consulta SQL para Cliente
                _conexion.Ejecutar(sql1);
            }
            catch
            {
                // Manejar errores en las consultas
                return 2; // Error en el insert o update
            }

            // Manejo de teléfonos si es una modificación
            if (modificacion)
            {
                sql = $"DELETE FROM Telefono WHERE ci = {_ci}";
                try
                {
                    _conexion.Ejecutar(sql);
                }
                catch
                {
                    // Manejar errores al borrar los teléfonos
                    return 3; // Error al borrar los teléfonos
                }
            }

            // Insertar teléfonos nuevos
            foreach (string telefono in _telefonos)
            {
                sql = $"INSERT INTO Telefono(ci, telefono) VALUES({_ci}, '{telefono}')";
                try
                {
                    _conexion.Ejecutar(sql);
                }
                catch
                {
                    // Manejar errores al insertar los teléfonos
                    return 4; // Error al insertar los teléfonos
                }
            }

            return resultado;
        }


        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            Dictionary<int, Cliente> clientesDict = new Dictionary<int, Cliente>();

            // Verifica si la conexión está abierta
            if (!_conexion.Abierta())
            {
                throw new Exception("La conexión a la base de datos está cerrada.");
            }

            string sql = "SELECT p.ci, p.nombre, p.apellido, p.nro_puerta, p.calle, p.ciudad, p.estado, t.telefono, c.tipo_cliente " +
                         "FROM Persona p " +
                         "JOIN Telefono t ON p.ci = t.ci " +
                         "JOIN Cliente c ON p.ci = c.ci";

            try
            {
                // Ejecuta la consulta y obtiene el DataTable
                DataTable dt = _conexion.EjecutarSelect(sql);

                // Procesa cada fila del DataTable
                foreach (DataRow row in dt.Rows)
                {
                    int ci = Convert.ToInt32(row["ci"]);

                    // Verifica si el cliente ya está en el diccionario
                    if (!clientesDict.ContainsKey(ci))
                    {
                        // Crear un nuevo cliente y agregarlo al diccionario
                        clientesDict[ci] = new Cliente
                        {
                            _ci = ci,
                            _nombre = row["nombre"].ToString(),
                            _apellido = row["apellido"].ToString(),
                            _nro_puerta = Convert.ToInt32(row["nro_puerta"]),
                            _calle = row["calle"].ToString(),
                            _ciudad = row["ciudad"].ToString(),
                            _estado = Convert.ToSByte(row["estado"]),
                            _tipoCliente = row["tipo_cliente"].ToString(),
                            _telefonos = new List<string>()
                        };
                    }

                    // Agregar el teléfono al cliente existente
                    clientesDict[ci]._telefonos.Add(row["telefono"].ToString());
                }

                // Convierte el diccionario a lista
                clientes = clientesDict.Values.ToList();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al listar los clientes: " + ex.Message);
            }

            return clientes;
        }
    }
}
