using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AlineacionBalanceo
    {
        protected int _ayb_id;
        protected string _ayb_nombre;
        protected double _ayb_precio;
        protected Conexion _conexion;

        public int aybId
        {
            set { _ayb_id = value; }
            get { return (_ayb_id); }
        }

        public string aybNombre
        {
            set { _ayb_nombre = value; }
            get { return (_ayb_nombre); }
        }

        public double aybPrecio
        {
            set { _ayb_precio = value; }
            get { return (_ayb_precio); }
        }

        public Conexion Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public AlineacionBalanceo() {
            _ayb_id = 0;
            _ayb_nombre = "";
            _ayb_precio = 0;
            _conexion = new Conexion();
        }

        public AlineacionBalanceo(int ayb_id, string ayb_nom, double ayb_precio, Conexion cn)
        {
            _ayb_id = ayb_id;
            _ayb_nombre = ayb_nom;
            _ayb_precio = ayb_precio;
            _conexion = cn;
        }

        // Metodo para buscar ayb
        public byte BuscarAyB()
        {
            byte resultado = 0;

            // Chequeo el estado de la conexion
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            try
            {
                // Consulta principal para obtener los datos del lavado
                string sql = "SELECT id_ayb, nombre_ayb, precio_ayb " +
                    "FROM Alineacion_Balanceo " +
                    "WHERE id_ayb = " + aybId;

                // Ejecutamos la consulta
                DataTable dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count == 0)
                {
                    return 3; // No encontrado el lavado
                }

                // Asignar valores desde la consulta
                DataRow row = dt.Rows[0];
                aybId = Convert.ToInt32(row["id_ayb"]);
                aybNombre = row["nombre_ayb"].ToString();
                aybPrecio = Convert.ToDouble(row["precio_ayb"]);
            }
            catch
            {
                return 2; // Error en la ejecución de la consulta
            }
            return resultado; // Todo funciono correctamente
        }

        public byte ActualizarAyB()
        {
            byte resultado = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Definir las consultas SQL para insertar o actualizar
            string sql = $"UPDATE Alineacion_Balanceo " +
                $"SET precio_ayb = {aybPrecio} " +
                $"WHERE id_ayb = {aybId};";

            try
            {
                // Ejecutar la consulta SQL y obtener el número de filas afectadas
                bool filasAfectadas = _conexion.Ejecutar(sql);

                // Validar si se realizaron cambios
                if (filasAfectadas == false)
                {
                    return 3; // No se realizaron cambios
                }

            }
            catch
            {
                return 2; // Error en el insert o update
            }

            return resultado;
        }

        public List<AlineacionBalanceo> ListarAyB()
        {
            // Lista para almacenar los servicios/neumáticos
            List<AlineacionBalanceo> ayb = new List<AlineacionBalanceo>();
            Dictionary<int, AlineacionBalanceo> aybDict = new Dictionary<int, AlineacionBalanceo>();

            // Verifica si la conexión está abierta
            if (!_conexion.Abierta())
            {
                throw new Exception("La conexión a la base de datos está cerrada.");
            }

            // Consulta SQL para obtener los detalles de ayb
            string sql = "SELECT id_ayb, nombre_ayb, precio_ayb FROM Alineacion_Balanceo";

            try
            {
                // Ejecuta la consulta y obtiene el DataTable
                DataTable dt = _conexion.EjecutarSelect(sql);

                // Procesa cada fila del DataTable
                foreach (DataRow row in dt.Rows)
                {
                    int idayb = Convert.ToInt32(row["id_ayb"]);

                    // Verifica si el neumático ya está en el diccionario
                    if (!aybDict.ContainsKey(idayb))
                    {
                        // Crear un nuevo servicio (neumático) y agregarlo al diccionario
                        aybDict[idayb] = new AlineacionBalanceo
                        {
                            aybId = idayb,
                            aybNombre = row["nombre_ayb"].ToString(),
                            aybPrecio = Convert.ToDouble(row["precio_ayb"])
                        };
                    }
                }

                // Convierte el diccionario a una lista de servicios
                ayb = aybDict.Values.ToList();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al listar los neumáticos: " + ex.Message);
            }

            return ayb;
        }
    }
}
