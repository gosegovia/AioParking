using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Neumatico
    {
        protected int _neumatico_id;
        protected string _neumatico_nombre;
        protected double _neumatico_precio;
        protected string _neumatico_marca;
        protected int _neumatico_cantidad;
        protected byte _neumatico_estado;
        protected Conexion _conexion;

        public int neumaticoId
        {
            set { _neumatico_id = value; }
            get { return (_neumatico_id); }
        }

        public string neumaticoNombre
        {
            set { _neumatico_nombre = value; }
            get { return (_neumatico_nombre); }
        }

        public double neumaticoPrecio
        {
            set { _neumatico_precio = value; }
            get { return (_neumatico_precio); }
        }

        public string neumaticoMarca
        {
            set { _neumatico_marca = value; }
            get { return (_neumatico_marca); }
        }

        public int neumaticoCantidad
        {
            set { _neumatico_cantidad = value; }
            get { return (_neumatico_cantidad); }
        }

        public byte neumaticoEstado
        {
            set { _neumatico_estado = value; }
            get { return (_neumatico_estado); }
        }

        public Conexion Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public Neumatico()
        {
            _neumatico_id = 0;
            _neumatico_nombre = "";
            _neumatico_precio = 0;
            _neumatico_marca = "";
            _neumatico_cantidad = 0;
            _conexion = new Conexion();
        }

        public Neumatico(int neu_id, string neu_nom, double neu_pre, string neu_mar, int neu_cant, Conexion cn)
        {
            _neumatico_id = neu_id;
            _neumatico_nombre = neu_nom;
            _neumatico_precio = neu_pre;
            _neumatico_marca = neu_mar;
            _neumatico_cantidad = neu_cant;
            _conexion = cn;
        }

        public byte BuscarNeumatico()
        {
            byte resultado = 0;

            // Chequeo el estado de la conexion
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            try
            {
                // Consulta SQL sin parámetros (pero cuidado con inyecciones SQL)
                string sql = "SELECT nombre_neumatico, marca_neumatico, precio_neumatico, stock_neumatico, estado_neumatico " +
                             "FROM Neumatico " +
                             "WHERE id_neumatico = " + neumaticoId + ";"; // Usamos el ID validado

                // Ejecutamos la consulta
                DataTable dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count == 0)
                {
                    return 3; // No encontrado el neumatico
                }

                // Asignar valores desde la consulta
                DataRow row = dt.Rows[0];
                neumaticoNombre = row["nombre_neumatico"].ToString();
                neumaticoMarca = row["marca_neumatico"].ToString();
                neumaticoPrecio = Convert.ToInt32(row["precio_neumatico"]);
                neumaticoCantidad = Convert.ToInt32(row["stock_neumatico"]);
                neumaticoEstado = Convert.ToByte(row["estado_neumatico"]);
            }
            catch
            {
                return 2; // Error en la ejecución de la consulta
            }
            return resultado; // Todo funciono correctamente
        }

        public byte GuardarNeumatico(bool modificacion)
        {
            byte resultado = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Definir las consultas SQL para insertar o actualizar
            string sql;

            if (modificacion)
            {
                // Consulta para actualizar los datos del neumático
                sql = $"UPDATE Neumatico SET nombre_neumatico = '" + neumaticoNombre + "', " +
                      "marca_neumatico = '" + neumaticoMarca + "', precio_neumatico = " + neumaticoPrecio + ", " +
                      "stock_neumatico = " + neumaticoCantidad + ", estado_neumatico = 1 " +
                      "WHERE id_neumatico = " + neumaticoId;
            }
            else
            {
                // Consulta para insertar un nuevo neumático
                sql = "INSERT INTO Neumatico (nombre_neumatico, marca_neumatico, precio_neumatico, stock_neumatico, estado_neumatico) " +
                      "VALUES ('" + neumaticoNombre + "', '" + neumaticoMarca + "', " + neumaticoPrecio + ", " + neumaticoCantidad + ", 1)";
            }

            try
            {
                // Ejecutar la consulta SQL
                _conexion.Ejecutar(sql);
            }
            catch
            {
                // Manejar errores en las consultas
                return 2; // Error en el insert o update
            }

            return resultado; // Todo salió bien
        }

        public byte EliminarNeumatico()
        {
            byte resultado = 0;

            // Chequeo el estado de la conexion
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Consulta para hacer borrado logico de cliente
            string sql = $"UPDATE Neumatico SET estado_neumatico = 0 WHERE id_neumatico = " + neumaticoId;

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

        public List<Neumatico> ListarNeumaticos()
        {
            // Lista para almacenar los servicios/neumáticos
            List<Neumatico> neumatico = new List<Neumatico>();
            Dictionary<int, Neumatico> neumaticoDict = new Dictionary<int, Neumatico>();

            // Verifica si la conexión está abierta
            if (!_conexion.Abierta())
            {
                throw new Exception("La conexión a la base de datos está cerrada.");
            }

            // Consulta SQL para obtener los detalles de los neumáticos
            string sql = "SELECT id_neumatico, nombre_neumatico, marca_neumatico, precio_neumatico, stock_neumatico " +
                         "FROM Neumatico;";

            try
            {
                // Ejecuta la consulta y obtiene el DataTable
                DataTable dt = _conexion.EjecutarSelect(sql);

                // Procesa cada fila del DataTable
                foreach (DataRow row in dt.Rows)
                {
                    int idNeumatico = Convert.ToInt32(row["id_neumatico"]);

                    // Verifica si el neumático ya está en el diccionario
                    if (!neumaticoDict.ContainsKey(idNeumatico))
                    {
                        // Crear un nuevo servicio (neumático) y agregarlo al diccionario
                        neumaticoDict[idNeumatico] = new Neumatico
                        {
                            neumaticoId = idNeumatico,
                            neumaticoNombre = row["nombre_neumatico"].ToString(),
                            neumaticoMarca = row["marca_neumatico"].ToString(),
                            neumaticoPrecio = Convert.ToDouble(row["precio_neumatico"]),
                            neumaticoCantidad = Convert.ToInt32(row["stock_neumatico"])
                        };
                    }
                }

                // Convierte el diccionario a una lista de servicios
                neumatico = neumaticoDict.Values.ToList();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al listar los neumáticos: " + ex.Message);
            }

            return neumatico;
        }
    }
}
