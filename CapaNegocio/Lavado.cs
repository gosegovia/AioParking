using CapaPersistencia;
using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Lavado
    {
        protected int _lavado_id;
        protected string _lavado_nombre;
        protected double _lavado_precio;
        protected Conexion _conexion;

        public int LavadoId
        {
            set { _lavado_id = value; }
            get { return (_lavado_id); }
        }

        public string LavadoNombre
        {
            set { _lavado_nombre = value; }
            get { return (_lavado_nombre); }
        }

        public double LavadoPrecio
        {
            set { _lavado_precio = value; }
            get { return (_lavado_precio); }
        }

        public Conexion Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public Lavado()
        {
            _lavado_id = 0;
            _lavado_nombre = "";
            _lavado_precio = 0;
            _conexion = new Conexion();
        }

        public Lavado(int lav, string lavnom, double lavpre, Conexion cn)
        {
            _lavado_id = lav;
            _lavado_nombre = lavnom;
            _lavado_precio = lavpre;
            _conexion = cn;
        }

        // Metodo para buscar lavado
        public byte BuscarLavado()
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
                string sql = "SELECT id_lavado, nombre_lavado, precio_lavado " +
                    "FROM Lavado " +
                    "WHERE id_lavado = " + LavadoId;

                // Ejecutamos la consulta
                DataTable dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count == 0)
                {
                    return 3; // No encontrado el lavado
                }

                // Asignar valores desde la consulta
                DataRow row = dt.Rows[0];
                LavadoId = Convert.ToInt32(row["id_lavado"]);
                LavadoNombre = row["nombre_lavado"].ToString();
                LavadoPrecio = Convert.ToDouble(row["precio_lavado"]);
            }
            catch
            {
                return 2; // Error en la ejecución de la consulta
            }
            return resultado; // Todo funciono correctamente
        }

        public byte ActualizarLavado()
        {
            byte resultado = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Definir las consultas SQL para insertar o actualizar
            string sql = $"UPDATE Lavado " +
                $"SET precio_lavado = {LavadoPrecio} " +
                $"WHERe id_lavado = {LavadoId};";

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

        public (byte resultado, DateTime? fecha) UsoLavadoGratis(int ci)
        {
            byte resultado = 0;
            DateTime? fechaLavado = null; // Usar nullable para manejar el caso sin fecha

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return (1, fechaLavado); // Código 1: Conexión cerrada
            }

            // Definir la consulta SQL
            string sql = "SELECT u.id_factura, f.fecha " +
                         "FROM Usa u " +
                         "JOIN Factura f ON u.id_factura = f.id_factura " +
                         "WHERE u.id_lavado = 6 " +
                         $"AND f.ci_cliente = {ci} " +
                         "AND f.fecha >= DATE_SUB(NOW(), INTERVAL 1 MONTH);";

            try
            {
                // Ejecutar la consulta SQL y obtener el resultado
                DataTable dt = _conexion.EjecutarSelect(sql);

                // Validar si se encontraron registros
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    int lavadoId = Convert.ToInt32(row["id_factura"]); // Variable local, si es necesaria en otro contexto, puedes retornarla
                    fechaLavado = Convert.ToDateTime(row["fecha"]);
                    resultado = 0; // Código 0: Registro encontrado y fecha obtenida
                }
                else
                {
                    resultado = 3; // Código 3: No se encontraron registros dentro del último mes
                }
            }
            catch (Exception)
            {
                return (2, fechaLavado); // Código 2: Error en la consulta
            }

            return (resultado, fechaLavado); // Retornar resultado y fecha
        }

        public List<Lavado> ListarLavados()
        {
            // Lista para almacenar los servicios/neumáticos
            List<Lavado> lavado = new List<Lavado>();
            Dictionary<int, Lavado> lavadoDict = new Dictionary<int, Lavado>();

            // Verifica si la conexión está abierta
            if (!_conexion.Abierta())
            {
                throw new Exception("La conexión a la base de datos está cerrada.");
            }

            // Consulta SQL para obtener los detalles de los neumáticos
            string sql = "SELECT id_lavado, nombre_lavado, precio_lavado FROM Lavado";

            try
            {
                // Ejecuta la consulta y obtiene el DataTable
                DataTable dt = _conexion.EjecutarSelect(sql);

                // Procesa cada fila del DataTable
                foreach (DataRow row in dt.Rows)
                {
                    int idLavado = Convert.ToInt32(row["id_lavado"]);

                    // Verifica si el neumático ya está en el diccionario
                    if (!lavadoDict.ContainsKey(idLavado))
                    {
                        // Crear un nuevo servicio (neumático) y agregarlo al diccionario
                        lavadoDict[idLavado] = new Lavado
                        {
                            LavadoId = idLavado,
                            LavadoNombre = row["nombre_lavado"].ToString(),
                            LavadoPrecio = Convert.ToDouble(row["precio_lavado"])                            
                        };
                    }
                }

                // Convierte el diccionario a una lista de servicios
                lavado = lavadoDict.Values.ToList();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al listar los neumáticos: " + ex.Message);
            }

            return lavado;
        }
    }
}
