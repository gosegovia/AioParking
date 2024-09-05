using ADODB;
using CapaPersistencia;
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
        protected Conexion _conexion;

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

        public Conexion conexion
        {
            set { _conexion = value; }
            get { return (_conexion); }
        }

        public Parking()
        {
            _plaza = 0;
            _idparking = 0;
            _estadoPlaza = "";
            _conexion = new Conexion();
        }

        public Parking(int plaza, int parking, string estado, Conexion cn)
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

            try
            {
                // Ejecutar la consulta y obtener el DataTable directamente
                dt = _conexion.EjecutarSelect(sql);

                // Cambiar los nombres de las columnas en el DataTable si es necesario
                dt.Columns["nro_plaza"].ColumnName = "Número Plaza";
                dt.Columns["estado_plaza"].ColumnName = "Estado Plaza";
            }
            catch
            {
                
            }

            return dt;
        }


        public byte ObtenerPlaza(string matricula)
        {
            string sql;
            DataTable dt;
            byte resultado = 0;

            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            sql = "SELECT p.nro_plaza " +
                  "FROM Vehiculo v " +
                  "JOIN Posee po ON v.matricula = po.matricula " +
                  "JOIN Factura f ON po.matricula = f.matricula " +
                  "JOIN Solicita s ON f.id_factura = s.id_factura " +
                  "JOIN Reserva r ON s.id_parking = r.id_parking " +
                  "JOIN Plaza p ON r.id_plaza = p.id_plaza " +
                  "WHERE v.matricula = @matricula;";

            try
            {
                // Usar parámetros para evitar SQL Injection
                dt = _conexion.EjecutarSelect(sql);
            }
            catch
            {
                return 2; // Error en la ejecución
            }

            if (dt.Rows.Count == 0)
            {
                return 3; // No encontrado
            }
            else
            {
                // Asumiendo que _plaza es una variable de instancia para almacenar el resultado
                _plaza = Convert.ToByte(dt.Rows[0]["nro_plaza"]);
            }

            return resultado;
        }

        public byte GuardarParking()
        {
            byte resultado = 0;
            DataTable dt;
            string sql;

            if (!_conexion.Abierta()) // La conexión está cerrada
            {
                return 1; // Error: Conexión cerrada
            }

            // Convertir las fechas a cadenas en el formato adecuado
            string HoraEntradaRepair = HoraEntrada.ToString("yyyy-MM-dd HH:mm:ss");
            string HoraSalidaRepair = HoraSalida.ToString("yyyy-MM-dd HH:mm:ss");

            // Consulta para insertar en la tabla Parking
            sql = $"INSERT INTO Parking (hora_entrada, hora_salida) VALUES ('{HoraEntradaRepair}', '{HoraSalidaRepair}');";

            // Ejecutar la primera consulta para insertar en Parking
            dt = _conexion.EjecutarSelect(sql);

            // Obtener el último id_parking insertado
            sql = "SELECT LAST_INSERT_ID();";

            dt = _conexion.EjecutarSelect(sql);

            if (dt != null)
            {
                // Obtener el valor del id_parking
                int idParking = Convert.ToInt32(dt.Rows[0][0]);

                // Consulta para insertar en la tabla Reserva
                sql = $"INSERT INTO Reserva (id_parking, id_plaza) VALUES ({idParking}, {Plaza});";

                // Ejecutar la segunda consulta para insertar en Reserva
                _conexion.EjecutarSelect(sql);
            }
            else
            {
                resultado = 4; // Error al obtener el id_parking
            }
            return resultado;
        }
    }
}