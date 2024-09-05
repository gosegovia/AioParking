using ADODB;
using System;
using System.Data;

namespace CapaNegocio
{
    public class Parking
    {
        protected int _plaza;
        protected int _idparking;
        protected string _estadoPlaza;
        protected DateTime _horaEntrada;
        protected DateTime _horaSalida;
        protected Connection _conexion;

        public int Plaza
        {
            get { return _plaza; }
            set { _plaza = value; }
        }

        public int IdParking
        {
            get { return _idparking; }
            set { _idparking = value; }
        }

        public string EstadoPlaza
        {
            get { return _estadoPlaza; }
            set { _estadoPlaza = value; }
        }

        public DateTime HoraEntrada
        {
            get { return _horaEntrada; }
            set { _horaEntrada = value; }
        }

        public DateTime HoraSalida
        {
            get { return _horaSalida; }
            set { _horaSalida = value; }
        }

        public ADODB.Connection Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public Parking()
        {
            _plaza = 0;
            _idparking = 0;
            _estadoPlaza = "";
            _conexion = new Connection();
        }

        public Parking(int plaza, int parking, string estado, Connection cn)
        {
            _plaza = plaza;
            _idparking = parking;
            _estadoPlaza = estado;
            _conexion = cn;
        }

        public DataTable ListarPlazas()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT nro_plaza, estado_plaza FROM Plaza"; // Consulta actualizada para MySQL

            Recordset rs = new Recordset();

            try
            {
                rs.Open(sql, _conexion, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, -1);

                // Agregar columnas al DataTable
                dt.Columns.Add("Número Plaza");
                dt.Columns.Add("Estado Plaza");

                // Llenar el DataTable con los datos del Recordset
                while (!rs.EOF)
                {
                    DataRow row = dt.NewRow();
                    row["Número Plaza"] = rs.Fields["nro_plaza"].Value;
                    row["Estado Plaza"] = rs.Fields["estado_plaza"].Value;
                    dt.Rows.Add(row);
                    rs.MoveNext();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de plazas: " + ex.Message);
            }
            finally
            {
                // Cerrar y liberar el Recordset
                if (rs != null && rs.State == 1) // 1 indica que el Recordset está abierto
                {
                    rs.Close();
                }
            }

            return dt;
        }

        public byte ObtenerPlaza(string matricula)
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
                sql = "SELECT p.nro_plaza " +
                    "FROM Vehiculo v " +
                    "JOIN Posee po ON v.matricula = po.matricula " +
                    "JOIN Factura f ON po.matricula = f.matricula " +
                    "JOIN Solicita s ON f.id_factura = s.id_factura " +
                    "JOIN Reserva r ON s.id_parking = r.id_parking " +
                    "JOIN Plaza p ON r.id_plaza = p.id_plaza " +
                    "WHERE v.matricula = '" + matricula + "';";

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
                    _plaza = rs.Fields["nro_plaza"].Value;
                }
            }
            return resultado;
        }

        public byte GuardarParking()
        {
            byte resultado = 0;
            object filasAfectadas;
            string sql;

            if (_conexion.State == 0) // La conexión está cerrada
            {
                return 1; // Error: Conexión cerrada
            }

            // Convertir las fechas a cadenas en el formato adecuado
            string HoraEntradaRepair = HoraEntrada.ToString("yyyy-MM-dd HH:mm:ss");
            string HoraSalidaRepair = HoraSalida.ToString("yyyy-MM-dd HH:mm:ss");

            // Consulta para insertar en la tabla Parking
            sql = $"INSERT INTO Parking (hora_entrada, hora_salida) VALUES ('{HoraEntradaRepair}', '{HoraSalidaRepair}');";

            // Ejecutar la primera consulta para insertar en Parking
            _conexion.Execute(sql, out filasAfectadas);

            // Obtener el último id_parking insertado
            sql = "SELECT LAST_INSERT_ID();";

            var recordset = _conexion.Execute(sql, out filasAfectadas); // Ejecutar y obtener el Recordset
                                                                        // Verificar si el Recordset no está vacío
            if (!recordset.EOF)
            {
                // Obtener el valor del id_parking
                int idParking = Convert.ToInt32(recordset.Fields[0].Value);

                // Consulta para insertar en la tabla Reserva
                sql = $"INSERT INTO Reserva (id_parking, id_plaza) VALUES ({idParking}, {Plaza});";

                // Ejecutar la segunda consulta para insertar en Reserva
                _conexion.Execute(sql, out filasAfectadas);
            }
            else
            {
                resultado = 4; // Error al obtener el id_parking
            }

            recordset.Close(); // Cerrar el Recordset
            recordset = null; // Liberar memoria del Recordset
            return resultado;
        }
    }
}