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
            // Crear una nueva instancia de DataTable para almacenar los resultados.
            DataTable dt = new DataTable();
            string sql = "SELECT id_plaza AS 'Número Plaza', estado_plaza AS 'Estado Plaza' FROM Plaza"; // Consulta SQL simplificada con alias.

            try
            {
                // Ejecutar la consulta SQL y obtener los resultados en el DataTable.
                dt = _conexion.EjecutarSelect(sql);

                // Verificar si el DataTable tiene filas; si no, mostrar un mensaje de depuración.
                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No se encontraron datos en la tabla Plaza.");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones y mostrar el error para facilitar la depuración.
                Console.WriteLine("Error al listar las plazas: " + ex.Message);
            }

            // Devolver el DataTable con los resultados.
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

        /*
        public byte GuardarPlaza()
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
        */

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