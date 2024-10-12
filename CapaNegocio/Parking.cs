using ADODB;
using CapaPersistencia;
using System;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.draw;
using System.Collections.Generic;
using iTextSharp.text.pdf.codec.wmf;
using System.Diagnostics;

namespace CapaNegocio
{
    public class Parking
    {
        protected int _plaza;
        protected string _estadoPlaza;
        protected int _ticket;
        protected int _id_parking;
        protected double _precio_parking;
        protected DateTime _horaEntrada;
        protected DateTime _horaSalida;
        protected Cliente _cliente;
        protected Vehiculo _vehiculo;
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

        public Cliente Cliente
        {
            set { _cliente = value; }
            get { return (_cliente); }
        }

        public Vehiculo Vehiculo
        {
            set { _vehiculo = value; }
            get { return (_vehiculo); }
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
            _cliente = new Cliente();
            _vehiculo = new Vehiculo();
            _conexion = new Conexion();
        }

        public Parking(int plaza, int idpark, string estadopla, int ticket, double preciopark, DateTime he, DateTime hs, Cliente cli, Vehiculo ve, Conexion cn)
        {
            _plaza = plaza;
            _id_parking = idpark;
            _estadoPlaza = estadopla;
            _ticket = ticket;
            _precio_parking = preciopark;
            _horaEntrada = he;
            _horaSalida = hs;
            _cliente = cli;
            _vehiculo = ve;
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

                bool filasAfectadas = _conexion.Ejecutar(sql);

                // Verificar si la inserción fue exitosa
                if (!filasAfectadas)
                {
                    return 2; // Error en la inserción del primer ticket
                }

                // Insertar el segundo ticket si hay una segunda plaza
                if (plaza1 != 0)
                {
                    sql = "INSERT INTO Ticket(matricula, ci, id_plaza, fecha_ticket) VALUES " +
                    "('" + matricula + "', " + ci + ", " + plaza1 + ", '" + fechaFormateada + "');";

                    filasAfectadas = _conexion.Ejecutar(sql);

                    if (!filasAfectadas)
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
            // Ruta base para la carpeta de "tickets" dentro de Documentos
            string carpetaBase = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string carpetaTickets = Path.Combine(carpetaBase, "Tickets");

            // Crear la carpeta "tickets" si no existe
            if (!Directory.Exists(carpetaTickets))
            {
                Directory.CreateDirectory(carpetaTickets);
            }

            // Nombre del archivo PDF
            string nombreArchivo = "ticket_" + Ticket + ".pdf";
            string rutaArchivo = Path.Combine(carpetaTickets, nombreArchivo);

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

                    // Abrir el archivo PDF en el visor predeterminado
                    Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
                }
            }
        }

        public byte buscarTicket()
        {
            string sql;
            DataTable dt;
            byte resultado = 0;

            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            sql = "SELECT matricula, ci, id_plaza, fecha_ticket " +
                "FROM ticket " +
                "WHERE id_ticket = " + Ticket + ";";

            dt = _conexion.EjecutarSelect(sql);
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
                Cliente.ci = Convert.ToInt32(dt.Rows[0]["ci"]);
                Vehiculo.Matricula = Convert.ToString(dt.Rows[0]["matricula"]);
                Plaza = Convert.ToByte(dt.Rows[0]["id_plaza"]);
                HoraEntrada = Convert.ToDateTime(dt.Rows[0]["fecha_ticket"]);
            }
            return resultado;
        }

        public byte GuardarParking()
        {
            string sql;
            DataTable dt;
            byte resultado = 0;
            int existeFacturaSinParking = 0;
            int id_factura = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Verificar si existe una factura no pagada y sin parking asignado
            sql = "SELECT f.id_factura " +
                  "FROM Factura f " +
                  "LEFT JOIN Solicita s ON f.id_factura = s.id_factura " +
                  "WHERE f.factura_paga = '0' " +
                  "  AND f.matricula = '" + Vehiculo.Matricula + "' " +
                  "  AND s.id_parking IS NULL;";

            try
            {
                dt = _conexion.EjecutarSelect(sql);
            }
            catch
            {
                return 2; // Error al ejecutar la consulta
            }

            if (dt.Rows.Count > 0)
            {
                // Existe una factura pendiente sin parking
                existeFacturaSinParking = 1;
                id_factura = Convert.ToInt32(dt.Rows[0]["id_factura"]);
            }

            string HoraEntradaFormateada = HoraEntrada.ToString("yyyy-MM-dd HH:mm:ss");
            string HoraSalidaFormateada = HoraSalida.ToString("yyyy-MM-dd HH:mm:ss");

            if (existeFacturaSinParking == 0)
            {
                try
                {
                    // Crear una nueva factura si no existe ninguna sin parking
                    sql = "INSERT INTO Factura (ci, matricula, factura_paga, fecha) " +
                          "VALUES (" + Cliente.ci + ", '" + Vehiculo.Matricula + "', '0', '" + HoraSalidaFormateada + "');";

                    // Ejecutar la inserción
                    bool filasAfectadas = _conexion.Ejecutar(sql);

                    // Verificar que se haya insertado la factura
                    if (!filasAfectadas)
                    {
                        return 3; // Error: No se insertó la factura
                    }

                    // Obtener el ID de la factura recién generada
                    string ultimoID = "SELECT LAST_INSERT_ID();";
                    dt = _conexion.EjecutarSelect(ultimoID);

                    // Verificar que se haya obtenido el ID
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        id_factura = Convert.ToInt32(dt.Rows[0][0]); // Obtener el id_factura recién generado
                    }
                    else
                    {
                        return 4; // Error: No se obtuvo el ID de la factura
                    }
                }
                catch
                {
                    return 5; // Error en la inserción de la factura
                }
            }

            try
            {
                // Insertar el parking
                sql = "INSERT INTO Parking (hora_entrada, hora_salida, precio_parking) " +
                      "VALUES('" + HoraEntradaFormateada + "', '" + HoraSalidaFormateada + "', " + precioParking.ToString().Replace(",", ".") + ");";

                // Ejecutar el comando de inserción
                bool filasAfectadas = _conexion.Ejecutar(sql);

                if (!filasAfectadas)
                {
                    return 3; // Error: No se insertó la factura
                }

                // Obtener el ID del parking recién insertado
                string ultimoID = "SELECT LAST_INSERT_ID();";
                dt = _conexion.EjecutarSelect(ultimoID);

                // Verificar que se haya obtenido el ID
                if (dt != null && dt.Rows.Count > 0)
                {
                    IdParking = Convert.ToInt32(dt.Rows[0][0]); // Obtener el id_parking recién generado
                }
                else
                {
                    return 7; // Error: No se obtuvo el ID del parking
                }
            }
            catch
            {
                return 8;
            }

            try
            {
                // Actualizar el estado de la plaza
                sql = "UPDATE Plaza " +
                       "SET estado_plaza = 'Libre' " +
                       "WHERE id_plaza = " + Plaza + ";";

                bool filasAfectadas = _conexion.Ejecutar(sql);
                if (!filasAfectadas)
                {
                    return 9; // Error: No se actualizó el estado de la plaza
                }

                // Insertar la reserva
                sql = "INSERT INTO Reserva (id_parking, id_plaza) " +
                       "VALUES (" + IdParking + ", " + Plaza + ");";

                filasAfectadas = _conexion.Ejecutar(sql);
                if (!filasAfectadas)
                {
                    return 10; // Error: No se insertó la reserva
                }

                // Asociar el parking con la factura en la tabla Solicita
                sql = "INSERT INTO Solicita (id_factura, id_plaza, id_parking, precio_solicita) " +
                       "VALUES (" + id_factura + ", " + Plaza + ", " + IdParking + ", " + precioParking.ToString().Replace(",", ".") + ");";

                filasAfectadas = _conexion.Ejecutar(sql);
                if (!filasAfectadas)
                {
                    return 11; // Error: No se insertó la solicitud
                }
            }
            catch
            {
                return 12; // Error en las consultas de actualización
            }

            return resultado;
        }

        public byte EstadoAuto()
        {
            byte resultado = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
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
                if (dt.Rows.Count != 0)
                {
                    DataRow row = dt.Rows[0];
                    LavadoId = Convert.ToInt32(row["id_factura"]);
                    fechaLavado = Convert.ToDateTime(row["fecha"]);
                }
            }
            catch
            {
                return 2;
            }

            return resultado;
        }

        public byte ActualizarPlaza()
        {
            byte resultado = 0;
            string sql;

            if (!_conexion.Abierta()) // La conexión está cerrada
            {
                return 1; // Error: Conexión cerrada
            }

            // Consulta para alternar el estado de la plaza
            sql = "UPDATE Plaza " +
                  "SET estado_plaza = CASE " +
                  "WHEN estado_plaza = 'Ocupada' THEN 'Libre' " +
                  "WHEN estado_plaza = 'Libre' THEN 'Ocupada' " +
                  "END " +
                  "WHERE id_plaza = " + Plaza + ";";

            // Ejecutar la consulta
            _conexion.EjecutarSelect(sql);

            return resultado;
        }

        public byte calcularPrecio()
        {
            byte resultado = 0;
            string sql;

            if (!_conexion.Abierta()) // La conexión está cerrada
            {
                return 1; // Error: Conexión cerrada
            }

            // Consulta para obtener el tipo de cliente y tipo de vehículo
            sql = "SELECT p.nombre, c.tipo_cliente, v.id_tipo " +
                  "FROM Persona p " +
                  "JOIN Cliente c ON c.ci = p.ci " +
                  "JOIN Posee po ON po.ci = c.ci " +
                  "JOIN Vehiculo v ON v.matricula = po.matricula " + // Corrección aquí
                  "WHERE c.ci=" + Cliente.ci + " AND v.matricula = '" + Vehiculo.Matricula + "';";

            // Ejecutar la consulta
            DataTable dt = _conexion.EjecutarSelect(sql);

            if (dt.Rows.Count == 0) // Verificar si hay resultados
            {
                return 2; // Error: No se encontraron registros
            }

            Cliente.TipoCliente = Convert.ToString(dt.Rows[0]["tipo_cliente"]);
            Vehiculo.TipoVehiculo = Convert.ToInt32(dt.Rows[0]["id_tipo"]);

            double total = 0;
            double precio = 0;
            TimeSpan horas = HoraSalida - HoraEntrada;
            int descuento = 0;

            // Obtener el precio según el tipo de vehículo
            switch (Vehiculo.TipoVehiculo)
            {
                case 1: precio = 50; break;
                case 2: precio = 100; break;
                case 3: precio = 120; break;
                case 4:
                case 5: precio = 150; break;
            }

            // Obtener el descuento según el tipo de cliente
            switch (Cliente.TipoCliente)
            {
                case "Mensual": descuento = 10; break; // 10% de descuento
                case "Sistemático": descuento = 7; break; // 7% de descuento
                case "Eventual": descuento = 0; break; // Sin descuento
            }

            // Calcular total de horas
            double horasTotales = horas.TotalHours; // Obtener las horas totales como decimal

            // Calcular el total antes del descuento
            precioParking = precio * horasTotales;

            // Aplicar el descuento
            if (descuento > 0)
            {
                precioParking = total * (1 - (descuento / 100.0)); // Aplicar el descuento
            }

            // Redondear a dos decimales
            precioParking = Math.Round(precioParking, 2);

            return resultado;
        }
    }
}