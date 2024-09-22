using ADODB;
using CapaPersistencia;
using System;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.draw;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class Parking
    {
        protected int _plaza;
        protected int _id_parking;
        protected string _estadoPlaza;
        protected int _ticket;
        protected double _precio_parking;
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
            get { return _id_parking; }
            set { _id_parking = value; }
        }

        public int Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        public string EstadoPlaza
        {
            get { return _estadoPlaza; }
            set { _estadoPlaza = value; }
        }

        public double precioParking
        {
            get { return _precio_parking; }
            set { _precio_parking = value; }
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
            _id_parking = 0;
            _estadoPlaza = "";
            _ticket = 0;
            _precio_parking = 0;
            _horaEntrada = DateTime.MinValue;
            _horaSalida = DateTime.MinValue;
            _conexion = new Conexion();
        }

        public Parking(int plaza, int idpark, string estadopla, int ticket, double preciopark, DateTime he, DateTime hs, Conexion cn)
        {
            _plaza = plaza;
            _id_parking = idpark;
            _estadoPlaza = estadopla;
            _ticket = ticket;
            _precio_parking = preciopark;
            _horaEntrada = he;
            _horaSalida = hs;
            _conexion = new Conexion();
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

        public byte GenerarTicket(string matricula, int ci, int plaza, int plaza1, DateTime fecha)
        {
            byte resultado = 0;

            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            try
            {
                // Formatear la fecha en formato 'yyyy-MM-dd HH:mm:ss'
                string fechaFormateada = fecha.ToString("yyyy-MM-dd HH:mm:ss");

                // Insertar el primer ticket
                string sql = "INSERT INTO Ticket(matricula, ci, id_plaza, fecha_ticket) VALUES " +
                    "('" + matricula + "', " + ci + ", " + plaza + ", '" + fechaFormateada + "');";

                int filasAfectadas = _conexion.Ejecutar(sql);

                // Verificar si la inserción fue exitosa
                if (filasAfectadas <= 0)
                {
                    return 2; // Error en la inserción del primer ticket
                }

                // Insertar el segundo ticket si hay una segunda plaza
                if (plaza1 != 0)
                {
                    sql = "INSERT INTO Ticket(matricula, ci, id_plaza, fecha_ticket) VALUES " +
                    "('" + matricula + "', " + ci + ", " + plaza1 + ", '" + fechaFormateada + "');";

                    filasAfectadas = _conexion.Ejecutar(sql);

                    if (filasAfectadas <= 0)
                    {
                        return 3; // Error en la inserción del segundo ticket
                    }
                }

                // Obtener el id_ticket recién insertado
                string obtenerIdSql = "SELECT LAST_INSERT_ID();";
                Ticket = Convert.ToInt32(_conexion.EjecutarEscalar(obtenerIdSql));
            }
            catch
            {
                return 4; // Error en la inserción
            }

            return resultado; // 0 indica éxito
        }

        public void CrearTicketPDF(string matricula, int ci, int plaza, int plaza1, DateTime fecha)
        {
            // Ruta base para el archivo PDF
            string carpeta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreArchivo = "ticket_"+Ticket+".pdf";
            string rutaArchivo = Path.Combine(carpeta, nombreArchivo);

            // Crear el archivo en la ruta especificada
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (Document doc = new Document(PageSize.A7)) // A7 es más pequeño, similar al tamaño de un ticket
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                    // Abrir el documento para escribir en él
                    doc.Open();

                    // Fuentes personalizadas
                    Font tituloFont = FontFactory.GetFont(FontFactory.COURIER_BOLD, 10);
                    Font subTituloFont = FontFactory.GetFont(FontFactory.COURIER_BOLD, 8);
                    Font contenidoFont = FontFactory.GetFont(FontFactory.COURIER, 7);
                    Font fechaFont = FontFactory.GetFont(FontFactory.COURIER, 12);
                    Font footerFont = FontFactory.GetFont(FontFactory.COURIER_OBLIQUE, 6);

                    // Agregar nombre de la empresa
                    Paragraph empresa = new Paragraph("Aio Parking", tituloFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(empresa);

                    // Línea separadora
                    doc.Add(new Paragraph("--------------------------------", contenidoFont));

                    // Agregar título del ticket
                    Paragraph titulo = new Paragraph("Ticket de Parking", subTituloFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(titulo);

                    // Línea separadora
                    doc.Add(new Paragraph("--------------------------------", contenidoFont));

                    // Datos del ticket (centrados)
                    doc.Add(new Paragraph($"{fecha.ToString("HH:mm:ss")}", fechaFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    doc.Add(new Paragraph($"Ticket: {Ticket}", contenidoFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });
                    doc.Add(new Paragraph($"Fecha: {fecha.ToString("dd/MM/yyyy")}", contenidoFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    });

                    // Si hay dos plazas, las mostramos ambas, sino una sola
                    if (plaza1 == 0)
                    {
                        doc.Add(new Paragraph($"Plaza: {plaza}", contenidoFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        });
                    }
                    else if (plaza1 > 21)
                    {
                        doc.Add(new Paragraph($"Plazas: {plaza}, {plaza1}", contenidoFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        });
                    }

                    // Línea separadora
                    doc.Add(new Paragraph("--------------------------------", contenidoFont));

                    // Generar el código de barras basado en la matrícula
                    Barcode128 codigoBarras = new Barcode128
                    {
                        Code = matricula,
                        BarHeight = 25f, // Altura del código de barras ajustada
                        X = 1.25f,        // Ancho del código de barras ajustado
                        TextAlignment = Element.ALIGN_CENTER,  // Centrar el texto del código de barras debajo
                        Font = null      // Sin texto debajo del código de barras
                    };

                    // Convertir el código de barras en una imagen que pueda ser agregada al documento
                    Image imagenCodigoBarras = codigoBarras.CreateImageWithBarcode(writer.DirectContent, BaseColor.BLACK, BaseColor.BLACK);
                    imagenCodigoBarras.Alignment = Element.ALIGN_CENTER; // Centrar la imagen del código de barras
                    doc.Add(imagenCodigoBarras); // Agregar la imagen del código de barras al PDF

                    // Mensaje de agradecimiento (centrado)
                    Paragraph footer = new Paragraph("¡Gracias por su preferencia!", footerFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(footer);

                    // Cerrar el documento para finalizar la escritura
                    doc.Close();
                }
            }
        }


    }
}