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
    public class Servicio
    {
        protected int _factura_id;
        protected DateTime _factura_fecha;
        protected int _lavado_id;
        protected string _lavado_nombre;
        protected double _lavado_precio;
        protected int _ayb_id;
        protected string _ayb_nombre;
        protected double _ayb_precio;
        protected int _neumatico_id;
        protected string _neumatico_nombre;
        protected double _neumatico_precio;
        protected string _neumatico_marca;
        protected int _neumatico_cantidad;
        protected byte _neumatico_estado;
        protected Cliente _cliente;
        protected Vehiculo _vehiculo;
        protected Parking _parking;
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

        public int lavadoId
        {
            set { _lavado_id = value; } 
            get { return (_lavado_id); }
        }

        public string lavadoNombre
        {
            set { _lavado_nombre = value; }
            get { return (_lavado_nombre); }
        }

        public double lavadoPrecio
        {
            set { _lavado_precio = value; }
            get { return (_lavado_precio); }
        }

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
            set { _ayb_precio= value; }
            get { return (_ayb_precio); }
        }

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
            set {  _neumatico_estado = value; }
            get { return (_neumatico_estado); }
        }

        public Cliente Cliente
        {
            set { _cliente = value; }
            get { return _cliente; }
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

        public Conexion Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public Servicio()
        {
            _factura_id = 0;
            _factura_fecha = DateTime.MinValue;
            _lavado_id = 0;
            _lavado_nombre = "";
            _lavado_precio = 0;
            _ayb_id = 0;
            _ayb_nombre = "";
            _ayb_precio = 0;
            _neumatico_id = 0;
            _neumatico_nombre = "";
            _neumatico_precio = 0;
            _neumatico_marca = "";
            _neumatico_cantidad = 0;
            _cliente = new Cliente();
            _vehiculo = new Vehiculo();
            _parking = new Parking();
            _conexion = new Conexion();
        }

        public Servicio(int f, DateTime ffecha,
            int l, string lnom, double lpre,
            int ayb_id, string ayb_nom, double ayb_precio,
            int neu_id, string neu_nom, double neu_pre, string neu_mar, int neu_cant,
            Cliente cli, Vehiculo ve, Parking par, Conexion cn)
        {
            _factura_id = f;
            _factura_fecha = ffecha;

            _lavado_id = l;
            _lavado_nombre = lnom;
            _lavado_precio = lpre;

            _ayb_id = ayb_id;
            _ayb_nombre = ayb_nom;
            _ayb_precio = ayb_precio;

            _neumatico_id = neu_id;
            _neumatico_nombre = neu_nom;
            _neumatico_precio = neu_pre;
            _neumatico_marca = neu_mar;
            _neumatico_cantidad = neu_cant;

            _cliente = cli;
            _vehiculo = ve;
            _parking = par;
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
                    aybNombre = row["nombre_ayb"].ToString();
                    aybPrecio = Convert.ToDouble(row["precio_hace"]);
                    facturaId = Convert.ToInt32(row["id_factura"]);
                } else
                {
                    aybNombre = "ne";
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
                    lavadoNombre = row["nombre_lavado"].ToString();
                    lavadoPrecio = Convert.ToDouble(row["precio_usa"]);
                    facturaId = Convert.ToInt32(row["id_factura"]);
                } else
                {
                    lavadoNombre = "ne";
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
                    neumaticoNombre = row["nombre_neumatico"].ToString();
                    neumaticoPrecio = Convert.ToDouble(row["precio_compra"]);
                    neumaticoCantidad = Convert.ToInt32(row["cantidad_compra"]);
                    facturaId = Convert.ToInt32(row["id_factura"]);
                } else
                {
                    neumaticoNombre = "ne";
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
                if (aybNombre != "ne")
                {
                    table.AddCell(new Phrase($"{aybNombre}", regularFont));
                    table.AddCell(new Phrase("1", regularFont)); // Cantidad siempre será 1 para servicios
                    table.AddCell(new Phrase($"${aybPrecio}", regularFont));
                    table.AddCell(new Phrase($"${aybPrecio}", regularFont));
                    precioTotal += aybPrecio;
                }

                // Lavado
                if (lavadoNombre != "ne")
                {
                    table.AddCell(new Phrase($"{lavadoNombre}", regularFont));
                    table.AddCell(new Phrase("1", regularFont));
                    table.AddCell(new Phrase($"${lavadoPrecio}", regularFont));
                    table.AddCell(new Phrase($"${lavadoPrecio}", regularFont));
                    precioTotal += lavadoPrecio;
                }

                // Neumáticos
                if (neumaticoNombre != "ne")
                {
                    double precioNeumaticoTotal = (neumaticoPrecio/ neumaticoCantidad) * neumaticoCantidad;
                    table.AddCell(new Phrase($"{neumaticoNombre}", regularFont));
                    table.AddCell(new Phrase($"{neumaticoCantidad}", regularFont));
                    table.AddCell(new Phrase($"${(neumaticoPrecio / neumaticoCantidad)}", regularFont));
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

        public List<Servicio> ListarServicios()
        {
            List<Servicio> servicios = new List<Servicio>();
            Dictionary<int, Servicio> serviciosDict = new Dictionary<int, Servicio>();

            // Verifica si la conexión está abierta
            if (!_conexion.Abierta())
            {
                throw new Exception("La conexión a la base de datos está cerrada.");
            }

            // Consulta SQL para obtener las facturas pagadas
            string sql = "SELECT id_factura, ci, matricula, fecha " +
                "FROM factura " +
                "WHERE factura_paga = '1' " +
                "ORDER BY fecha DESC " +
                "LIMIT 10;";

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
                        // Crear un nuevo objeto Servicio
                        Servicio servicio = new Servicio
                        {
                            facturaId = idFactura,
                            facturaFecha = Convert.ToDateTime(row["fecha"]),
                            Cliente = new Cliente
                            {
                                ci = Convert.ToInt32(row["ci"])
                            },
                            Vehiculo = new Vehiculo
                            {
                                Matricula = row["matricula"].ToString()
                            }
                        };

                        // Aquí podrías llamar a otra consulta para obtener datos de Parking
                        string parkingSql = "SELECT par.hora_entrada, par.hora_salida, r.id_plaza " +
                                            "FROM Parking par " +
                                            "JOIN Reserva r ON r.id_parking = par.id_parking " +
                                            "JOIN Solicita s ON s.id_parking = par.id_parking " +
                                            "JOIN Factura f ON f.id_factura = s.id_factura " +
                                            "WHERE f.id_factura = " + idFactura + ";";

                        // Ejecutar la consulta de Parking
                        DataTable parkingDt = _conexion.EjecutarSelect(parkingSql);
                        if (parkingDt.Rows.Count > 0)
                        {
                            DataRow parkingRow = parkingDt.Rows[0]; // Tomamos la primera fila
                            servicio.Parking = new Parking // Asegúrate de que Parking sea una clase
                            {
                                HoraEntrada = Convert.ToDateTime(parkingRow["hora_entrada"]),
                                HoraSalida = Convert.ToDateTime(parkingRow["hora_salida"]),
                                Plaza = Convert.ToInt32(parkingRow["id_plaza"])
                            };
                        }

                        // Consulta para obtener el nombre del lavado
                        string lavadoSql = "SELECT l.nombre_lavado " +
                                           "FROM Lavado l " +
                                           "JOIN Usa u ON u.id_lavado = l.id_lavado " +
                                           "JOIN Factura f ON f.id_factura = u.id_factura " +
                                           "WHERE f.id_factura = " + idFactura + ";";

                        // Ejecuta la consulta y obtiene el DataTable para los lavados
                        DataTable lavadoDt = _conexion.EjecutarSelect(lavadoSql);
                        if (lavadoDt.Rows.Count > 0)
                        {
                            DataRow lavadoRow = lavadoDt.Rows[0];
                            servicio.lavadoNombre = lavadoRow["nombre_lavado"].ToString(); // Asegúrate de que NombreLavado esté en la clase Servicio
                        } else
                        {
                            servicio.lavadoNombre = "No asignado";
                        }

                        string aybSql = "SELECT ayb.nombre_ayb " +
                            "FROM Alineacion_Balanceo ayb " +
                            "JOIN Hace h ON h.id_ayb = ayb.id_ayb " +
                            "JOIN Factura f ON f.id_factura = h.id_factura " +
                            "WHERE f.id_factura = " + idFactura + ";";

                        DataTable aybDt = _conexion.EjecutarSelect(aybSql);
                        if (aybDt.Rows.Count > 0)
                        {
                            DataRow aybRow = aybDt.Rows[0];
                            servicio.aybNombre = aybRow["nombre_ayb"].ToString();
                        } else
                        {
                            servicio.aybNombre = "No asignado";
                        }

                        string neumaticoSql = "SELECT n.nombre_neumatico, c.cantidad_compra " +
                            "FROM Neumatico n " +
                            "JOIN Compra c ON n.id_neumatico = c.id_neumatico " +
                            "JOIN Factura f ON f.id_factura = c.id_factura " +
                            "WHERE f.id_factura = " + idFactura + ";";

                        DataTable neumaticoDt = _conexion.EjecutarSelect(neumaticoSql);
                        if (neumaticoDt.Rows.Count > 0)
                        {
                            DataRow neumaticoRow = neumaticoDt.Rows[0];
                            servicio.neumaticoNombre = neumaticoRow["nombre_neumatico"].ToString();
                            servicio.neumaticoCantidad = Convert.ToInt32(neumaticoRow["cantidad_compra"]);
                        } else
                        {
                            servicio.neumaticoNombre = "No asignado";
                        }

                        // Agregar el servicio al diccionario
                        serviciosDict[idFactura] = servicio;
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

        public List<Servicio> ListarNeumaticos()
        {
            // Lista para almacenar los servicios/neumáticos
            List<Servicio> servicio = new List<Servicio>();
            Dictionary<int, Servicio> servicioDict = new Dictionary<int, Servicio>();

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
                    if (!servicioDict.ContainsKey(idNeumatico))
                    {
                        // Crear un nuevo servicio (neumático) y agregarlo al diccionario
                        servicioDict[idNeumatico] = new Servicio
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
                servicio = servicioDict.Values.ToList();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al listar los neumáticos: " + ex.Message);
            }

            return servicio;
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
                    "VALUES (" + facturaId + ", " + neumaticoId + ", " + neumaticoPrecio.ToString().Replace(",", ".") + ", " + neumaticoCantidad + ");";

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
                "SET stock_neumatico = stock_neumatico - " + neumaticoCantidad + " " +
                "WHERE id_neumatico = " + neumaticoId + ";";

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
    }
}
