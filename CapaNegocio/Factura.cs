using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using iTextSharp.text.pdf.codec.wmf;

namespace CapaNegocio
{
    public class Factura
    {
        protected int _factura_id;
        protected DateTime _factura_fecha;
        protected Cliente _cliente;
        protected Empleado _empleado;
        protected Vehiculo _vehiculo;
        protected Parking _parking;
        protected Lavado _lavado;
        protected AlineacionBalanceo _alineacionBalanceo;
        protected Neumatico _neumatico;
        protected Conexion _conexion;

        public int facturaId
        {
            set { _factura_id = value; }
            get { return (_factura_id); }
        }

        public DateTime facturaFecha
        {
            set { _factura_fecha = value; }
            get { return (_factura_fecha); }
        }

        public Cliente Cliente
        {
            set { _cliente = value; }
            get { return _cliente; }
        }

        public Empleado Empleado
        {
            set { _empleado = value; }
            get { return _empleado; }
        }

        public Vehiculo Vehiculo
        {
            set { _vehiculo = value; }
            get { return _vehiculo; }
        }

        public Parking Parking
        {
            set { _parking = value; }
            get { return _parking; }
        }

        public Lavado Lavado
        {
            set { _lavado = value; }
            get { return _lavado; }
        }

        public AlineacionBalanceo AlineacionBalanceo
        {
            set { _alineacionBalanceo = value; }
            get { return _alineacionBalanceo; }
        }

        public Neumatico Neumatico
        {
            set { _neumatico = value; }
            get { return _neumatico; }
        }

        public Conexion Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public Factura()
        {
            _factura_id = 0;
            _factura_fecha = DateTime.MinValue;
            _cliente = new Cliente();
            _empleado = new Empleado();
            _vehiculo = new Vehiculo();
            _parking = new Parking();
            _lavado = new Lavado();
            _alineacionBalanceo = new AlineacionBalanceo();
            _neumatico = new Neumatico();
            _conexion = new Conexion();
        }

        public Factura(int f, DateTime ffecha, Cliente cli, Empleado emp, Vehiculo ve, Parking par, Lavado lav, AlineacionBalanceo ayb, Neumatico neu, Conexion cn)
        { 
            _factura_id = f;
            _factura_fecha = ffecha;

            _cliente = cli;
            _empleado = emp;
            _vehiculo = ve;
            _parking = par;
            _lavado = lav;
            _alineacionBalanceo = ayb;
            _neumatico = neu;
            _conexion = cn;
        }

        // Metodo para buscar cliente
        public byte BuscarServicios(string matricula)
        {
            byte resultado = 0;
            DataRow row;

            // Chequeo el estado de la conexion
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            try
            {
                // Consulta principal para obtener los datos del cliente
                string sql = "SELECT ayb.nombre_ayb, h.precio_hace, f.id_factura " +
                    "FROM Alineacion_Balanceo ayb " +
                    "JOIN Hace h ON ayb.id_ayb = h.id_ayb " +
                    "JOIN Factura f ON f.id_factura = h.id_factura " +
                    "WHERE f.factura_paga = '0' AND f.matricula = '" + matricula + "';";

                // Ejecutamos la consulta
                DataTable dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count != 0)
                {
                    // Asignar valores desde la consulta
                    row = dt.Rows[0];
                    AlineacionBalanceo.aybNombre = row["nombre_ayb"].ToString();
                    AlineacionBalanceo.aybPrecio = Convert.ToDouble(row["precio_hace"]);
                    facturaId = Convert.ToInt32(row["id_factura"]);
                } else
                {
                    AlineacionBalanceo.aybNombre = "ne";
                }

                sql = "SELECT l.nombre_lavado, u.precio_usa, f.id_factura " +
                    "FROM Lavado l " +
                    "JOIN Usa u ON l.id_lavado = u.id_lavado " +
                    "JOIN Factura f ON f.id_factura = u.id_factura " +
                    "WHERE f.factura_paga = '0' AND f.matricula = '" + matricula + "';";

                dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count != 0)
                {
                    row = dt.Rows[0];
                    Lavado.LavadoNombre = row["nombre_lavado"].ToString();
                    Lavado.LavadoPrecio = Convert.ToDouble(row["precio_usa"]);
                    facturaId = Convert.ToInt32(row["id_factura"]);
                } else
                {
                    Lavado.LavadoNombre = "ne";
                }

                sql = "SELECT n.nombre_neumatico, c.precio_compra, c.cantidad_compra, f.id_factura " +
                    "FROM Neumatico n " +
                    "JOIN Compra c ON n.id_neumatico = c.id_neumatico " +
                    "JOIN Factura f ON f.id_factura = c.id_factura " +
                    "WHERE f.factura_paga = '0' AND f.matricula = '" + matricula + "';";

                dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count != 0)
                {
                    row = dt.Rows[0];
                    Neumatico.neumaticoNombre = row["nombre_neumatico"].ToString();
                    Neumatico.neumaticoPrecio = Convert.ToDouble(row["precio_compra"]);
                    Neumatico.neumaticoCantidad = Convert.ToInt32(row["cantidad_compra"]);
                    facturaId = Convert.ToInt32(row["id_factura"]);
                } else
                {
                    Neumatico.neumaticoNombre = "ne";
                }

                sql = "SELECT p.hora_entrada, p.hora_salida, s.precio_solicita, f.id_factura " +
                    "FROM Parking p " +
                    "JOIN Reserva r ON r.id_parking = p.id_parking " +
                    "JOIN Solicita s ON s.id_parking = r.id_parking " +
                    "JOIN Factura f ON f.id_factura = s.id_factura " +
                    "WHERE f.factura_paga = '0' AND f.matricula = '" + matricula + "';";

                dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count != 0)
                {
                    row = dt.Rows[0];
                    Parking.HoraEntrada = Convert.ToDateTime(row["hora_entrada"]);
                    Parking.HoraSalida = Convert.ToDateTime(row["hora_salida"]);
                    Parking.precioParking = Convert.ToDouble(row["precio_solicita"]);
                    facturaId = Convert.ToInt32(row["id_factura"]);
                } else
                {
                    Parking.precioParking = 0;
                }
            }
            catch
            {
                return 2; // Error en la ejecución de la consulta
            }
            return resultado; // Todo funciono correctamente
        }

        public void GenerarFacturaPDF(string matricula)
        {
            try
            {
                // Obtener la ruta de la carpeta "Documentos"
                string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Crear la carpeta "Facturas" dentro de "Documentos", si no existe
                string carpetaFacturas = Path.Combine(documentosPath, "Facturas");
                if (!Directory.Exists(carpetaFacturas))
                {
                    Directory.CreateDirectory(carpetaFacturas);
                }

                // Configurar el nombre y la ruta del archivo PDF en la carpeta "Facturas"
                string pdfFilePath = Path.Combine(carpetaFacturas, $"Factura_{matricula}_{facturaId}.pdf");

                // Crear un documento PDF
                Document doc = new Document(PageSize.A4, 36, 36, 54, 54); // márgenes
                PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
                doc.Open();

                // Fuentes para diferentes secciones
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                Font sectionTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                Font regularFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                // Añadir título con el nombre de la empresa
                Paragraph title = new Paragraph("Aio Parking", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------", regularFont));

                // Información de la empresa
                doc.Add(new Paragraph("Jacinto Vera, Luis Alberto de Herrera, entre Marne y Gualeguay\n", regularFont));
                doc.Add(new Paragraph($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy}\n", regularFont));
                doc.Add(new Paragraph($"Factura N°: {facturaId}", regularFont));

                doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------", regularFont));

                // Datos del cliente
                doc.Add(new Paragraph("Datos de la factura:", sectionTitleFont));
                doc.Add(new Paragraph($"Matrícula: {matricula}", regularFont));
                doc.Add(new Paragraph(" ", sectionTitleFont));

                // Crear una tabla para listar los productos/servicios y precios
                PdfPTable table = new PdfPTable(4); // 4 columnas: Descripción, Cantidad, Precio Unitario, Precio Total
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 38f, 12f, 20f, 20f });

                // Encabezado de la tabla
                table.AddCell(new PdfPCell(new Phrase("Descripción", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Cantidad", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Precio Unitario", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Precio Total", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

                // Inicializar el total
                double precioTotal = 0;

                // Parking
                if (Parking.precioParking > 0)
                {
                    TimeSpan duracionParking = Parking.HoraSalida - Parking.HoraEntrada;
                    table.AddCell(new Phrase("Parking", regularFont));
                    table.AddCell(new Phrase($"{Math.Ceiling(duracionParking.TotalHours)}", regularFont)); // Cantidad en horas
                    table.AddCell(new Phrase($"${Parking.precioParking}", regularFont));
                    table.AddCell(new Phrase($"${Parking.precioParking}", regularFont));
                    precioTotal += Parking.precioParking;
                }

                // Alineación y Balanceo
                if (AlineacionBalanceo.aybNombre != "ne")
                {
                    table.AddCell(new Phrase($"{AlineacionBalanceo.aybNombre}", regularFont));
                    table.AddCell(new Phrase("1", regularFont)); // Cantidad siempre será 1 para servicios
                    table.AddCell(new Phrase($"${AlineacionBalanceo.aybPrecio}", regularFont));
                    table.AddCell(new Phrase($"${AlineacionBalanceo.aybPrecio}", regularFont));
                    precioTotal += AlineacionBalanceo.aybPrecio;
                }

                // Lavado
                if (Lavado.LavadoNombre != "ne")
                {
                    table.AddCell(new Phrase($"{Lavado.LavadoNombre}", regularFont));
                    table.AddCell(new Phrase("1", regularFont));
                    table.AddCell(new Phrase($"${Lavado.LavadoPrecio}", regularFont));
                    table.AddCell(new Phrase($"${Lavado.LavadoPrecio}", regularFont));
                    precioTotal += Lavado.LavadoPrecio;
                }

                // Neumáticos
                if (Neumatico.neumaticoNombre != "ne")
                {
                    double precioNeumaticoTotal = (Neumatico.neumaticoPrecio / Neumatico.neumaticoCantidad) * Neumatico.neumaticoCantidad;
                    table.AddCell(new Phrase($"{Neumatico.neumaticoNombre}", regularFont));
                    table.AddCell(new Phrase($"{Neumatico.neumaticoCantidad}", regularFont));
                    table.AddCell(new Phrase($"${(Neumatico.neumaticoPrecio / Neumatico.neumaticoCantidad)}", regularFont));
                    table.AddCell(new Phrase($"${precioNeumaticoTotal}", regularFont));
                    precioTotal += precioNeumaticoTotal;
                }

                // Añadir fila del total
                PdfPCell emptyCell = new PdfPCell(new Phrase("")); // Celda vacía para alineación
                emptyCell.Border = PdfPCell.NO_BORDER;
                table.AddCell(emptyCell); // Celda vacía para "Descripción"
                table.AddCell(emptyCell); // Celda vacía para "Cantidad"
                table.AddCell(new PdfPCell(new Phrase("Total a pagar:", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase($"${precioTotal}", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

                // Añadir la tabla al documento
                doc.Add(table);

                doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------", regularFont));

                // Pie de página con información adicional
                doc.Add(new Paragraph("Gracias por elegir Aio Parking.\n", regularFont));

                // Información de contacto
                doc.Add(new Paragraph("Contacto: +598 1234 5678 | aio_parking@gmail.com\n", regularFont));

                // Cerrar el documento PDF
                doc.Close();

                // Abrir el archivo PDF en el visor predeterminado
                Process.Start(new ProcessStartInfo(pdfFilePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar la factura en PDF: " + ex.Message);
            }
        }

        public byte facturaPaga(int ci, string matricula)
        {
            byte resultado = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Definir la consulta SQL
            string sql = "UPDATE Factura " +
                "SET factura_paga = '1' " +
                "WHERE ci = " + ci + " " +
                "AND matricula = '" + matricula + "' " +
                "AND id_factura = " + facturaId + ";";

            try
            {
                // Ejecutar la consulta y obtener los resultados en un DataTable
                bool filasAfectadas = _conexion.Ejecutar(sql);

                if (!filasAfectadas)
                {
                    return 3; // Error: No se insertó
                }
            }
            catch
            {
                return 2; // Error en la ejecución de la consulta
            }
            return resultado;
        }

        public List<Factura> ListarServicios(int numeroPagina, int tamanioPagina, int? ciCliente = null, bool? facturaPaga = null)
        {
            List<Factura> servicios = new List<Factura>();
            Dictionary<int, Factura> serviciosDict = new Dictionary<int, Factura>();

            // Verifica si la conexión está abierta
            if (!_conexion.Abierta())
            {
                throw new Exception("La conexión a la base de datos está cerrada.");
            }

            // Consulta SQL base
            string sql = $@"
    SELECT f.id_factura, f.ci_cliente, f.ci_empleado, f.matricula, f.fecha,
           par.hora_entrada, par.hora_salida, r.id_plaza,
           l.nombre_lavado,
           ayb.nombre_ayb,
           n.nombre_neumatico, c.cantidad_compra
    FROM Factura f
    LEFT JOIN Solicita s ON f.id_factura = s.id_factura
    LEFT JOIN Parking par ON s.id_parking = par.id_parking
    LEFT JOIN Reserva r ON r.id_parking = par.id_parking
    LEFT JOIN Usa u ON u.id_factura = f.id_factura
    LEFT JOIN Lavado l ON u.id_lavado = l.id_lavado
    LEFT JOIN Hace h ON h.id_factura = f.id_factura
    LEFT JOIN Alineacion_Balanceo ayb ON h.id_ayb = ayb.id_ayb
    LEFT JOIN Compra c ON c.id_factura = f.id_factura
    LEFT JOIN Neumatico n ON n.id_neumatico = c.id_neumatico
    WHERE 1 = 1";

            // Agrega filtros según los parámetros opcionales
            if (ciCliente.HasValue)
            {
                sql += $" AND f.ci_cliente = {ciCliente.Value}";
            }

            // Modificación para aplicar el filtro de factura pagada
            if (facturaPaga.HasValue)
            {
                sql += $" AND f.factura_paga = {(facturaPaga.Value ? 1 : 0)}";
            }

            // Ordena por fecha y paginación
            sql += $" ORDER BY f.fecha DESC LIMIT {tamanioPagina} OFFSET {numeroPagina * tamanioPagina};";

            try
            {
                // Ejecuta la consulta y obtiene el DataTable
                DataTable dt = _conexion.EjecutarSelect(sql);

                // Procesa cada fila del DataTable
                foreach (DataRow row in dt.Rows)
                {
                    int idFactura = Convert.ToInt32(row["id_factura"]);

                    // Verifica si el servicio ya está en el diccionario
                    if (!serviciosDict.ContainsKey(idFactura))
                    {
                        // Crear un nuevo objeto Factura
                        Factura servicio = new Factura
                        {
                            facturaId = idFactura,
                            facturaFecha = Convert.ToDateTime(row["fecha"]),
                            Cliente = new Cliente
                            {
                                ci = Convert.ToInt32(row["ci_cliente"]),
                                Telefonos = new List<string>() // Si hay varios teléfonos asociados
                            },
                            Empleado = new Empleado
                            {
                                ci = Convert.ToInt32(row["ci_empleado"])
                            },
                            Vehiculo = new Vehiculo
                            {
                                Matricula = row["matricula"].ToString()
                            },
                            // Inicializa Lavado, AlineacionBalanceo y Neumatico
                            Lavado = new Lavado(),
                            AlineacionBalanceo = new AlineacionBalanceo(),
                            Neumatico = new Neumatico()
                        };

                        // Agregar al diccionario
                        serviciosDict[idFactura] = servicio;
                    }

                    // Agrega información de Parking, Lavado, Alineación/Balanceo y Neumáticos, si existen
                    Factura currentService = serviciosDict[idFactura];

                    // Parking
                    if (!DBNull.Value.Equals(row["hora_entrada"]) && !DBNull.Value.Equals(row["hora_salida"]))
                    {
                        currentService.Parking = new Parking
                        {
                            HoraEntrada = Convert.ToDateTime(row["hora_entrada"]),
                            HoraSalida = Convert.ToDateTime(row["hora_salida"]),
                            Plaza = Convert.ToInt32(row["id_plaza"])
                        };
                    }

                    // Lavado
                    currentService.Lavado.LavadoNombre = row["nombre_lavado"] != DBNull.Value
                        ? row["nombre_lavado"].ToString()
                        : "No asignado";

                    // Alineación y Balanceo
                    currentService.AlineacionBalanceo.aybNombre = row["nombre_ayb"] != DBNull.Value
                        ? row["nombre_ayb"].ToString()
                        : "No asignado";

                    // Neumáticos
                    if (!DBNull.Value.Equals(row["nombre_neumatico"]) && !DBNull.Value.Equals(row["cantidad_compra"]))
                    {
                        currentService.Neumatico.neumaticoNombre = row["nombre_neumatico"].ToString();
                        currentService.Neumatico.neumaticoCantidad = Convert.ToInt32(row["cantidad_compra"]);
                    }
                    else
                    {
                        currentService.Neumatico.neumaticoNombre = "No asignado";
                        currentService.Neumatico.neumaticoCantidad = 0;
                    }
                }

                // Convierte el diccionario a lista
                servicios = serviciosDict.Values.ToList();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al listar los servicios: " + ex.Message);
            }

            return servicios;
        }


        public byte ventaNeumatico()
        {
            byte resultado = 0;
            DataTable dt;
            int existeFacturaSinNeumatico = 0;

            // Verificar si la conexión está abierta
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            // Definir la consulta SQL para buscar por CI
            string sql = "SELECT f.id_factura " +
                "FROM Factura f " +
                "LEFT JOIN Compra c ON c.id_factura = f.id_factura " +
                "WHERE matricula = '" + Vehiculo.Matricula + "' " +
                "AND factura_paga = 0 " +
                "AND c.id_neumatico IS NULL;";

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
                existeFacturaSinNeumatico = 1;
                facturaId = Convert.ToInt32(dt.Rows[0]["id_factura"]);
            }

            string HoraFormateada = facturaFecha.ToString("yyyy-MM-dd HH:mm:ss");

            if (existeFacturaSinNeumatico == 0)
            {
                try
                {
                    // Crear una nueva factura si no existe ninguna sin parking
                    sql = "INSERT INTO Factura (ci, matricula, factura_paga, fecha) " +
                          "VALUES (" + Cliente.ci + ", '" + Vehiculo.Matricula + "', '0', '" + HoraFormateada + "');";

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
                        facturaId = Convert.ToInt32(dt.Rows[0][0]); // Obtener el id_factura recién generado
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
                sql = "INSERT INTO Compra(id_factura, id_neumatico, precio_compra, cantidad_compra) " +
                    "VALUES (" + facturaId + ", " + Neumatico.neumaticoId + ", " + Neumatico.neumaticoPrecio.ToString().Replace(",", ".") + ", " + Neumatico.neumaticoCantidad + ");";

                // Ejecutar el comando de inserción
                bool filasAfectadas = _conexion.Ejecutar(sql);

                if (!filasAfectadas)
                {
                    return 6; // Error: No se insertó la factura
                }
            }
            catch
            {
                return 7;
            }

            try
            {
                sql = "UPDATE Neumatico " +
                "SET stock_neumatico = stock_neumatico - " + Neumatico.neumaticoCantidad + " " +
                "WHERE id_neumatico = " + Neumatico.neumaticoId + ";";

                // Ejecutar el comando de inserción
                bool filasAfectadas = _conexion.Ejecutar(sql);

                if (!filasAfectadas)
                {
                    return 6; // Error: No se insertó la factura
                }
            }
            catch
            {
                return 7;
            }
           
            return resultado;
        }
    }
}
