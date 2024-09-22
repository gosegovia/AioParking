﻿using ADODB;
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

namespace CapaNegocio
{
    public class Servicio
    {
        protected int _factura_id;
        protected int _lavado_id;
        protected string _lavado_nombre;
        protected double _lavado_precio;
        protected int _ayb_id;
        protected string _ayb_nombre;
        protected double _ayb_precio;
        protected int _neumatico_id;
        protected string _neumatico_nombre;
        protected double _neumatico_precio;
        protected int _neumatico_cantidad;
        protected Parking _parking;
        protected Conexion _conexion;

        public int facturaId
        {
            set { _factura_id = value; }
            get { return (_factura_id); }
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

        public int neumaticoCantidad
        {
            set { _neumatico_cantidad = value; }
            get { return (_neumatico_cantidad); }
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
            _lavado_id = 0;
            _lavado_nombre = "";
            _lavado_precio = 0;
            _ayb_id = 0;
            _ayb_nombre = "";
            _ayb_precio = 0;
            _neumatico_id = 0;
            _neumatico_nombre = "";
            _neumatico_precio = 0;
            _neumatico_cantidad = 0;
            _parking = new Parking();
            _conexion = new Conexion();
        }

        public Servicio(int f, int l, string lnom, double lpre, int ayb_id, string ayb_nom, double ayb_precio, int al, int bal, Parking par, Conexion cn)
        {
            _factura_id = f;
            _lavado_id = l;
            _lavado_nombre = lnom;
            _lavado_precio = lpre;
            _ayb_id = ayb_id;
            _ayb_nombre = ayb_nom;
            _ayb_precio = ayb_precio;
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
                doc.Add(new Paragraph("Contacto: +598 1234 5678 | aio.parking@example.com\n", regularFont));

                // Cerrar el documento PDF
                doc.Close();

                Console.WriteLine($"Factura generada exitosamente en: {pdfFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar la factura en PDF: " + ex.Message);
            }
        }
    }
}
