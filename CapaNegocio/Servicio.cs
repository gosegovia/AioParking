using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using System.Data;
using iTextSharp.text.pdf.codec.wmf;

namespace CapaNegocio
{
    public class Servicio
    {
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
        protected Conexion _conexion;

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

        public Conexion Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public Servicio()
        {
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
            _conexion = new Conexion(); ;
        }

        public Servicio(int l, string lnom, double lpre, int ayb_id, string ayb_nom, double ayb_precio, int al, int bal, Conexion cn)
        {
            _lavado_id = l;
            _lavado_nombre = lnom;
            _lavado_precio = lpre;
            _ayb_id = ayb_id;
            _ayb_nombre = ayb_nom;
            _ayb_precio = ayb_precio;
            _conexion = cn;
        }

        // Metodo para buscar cliente
        public byte BuscarServicios(string matricula)
        {
            byte resultado = 0;

            // Chequeo el estado de la conexion
            if (!_conexion.Abierta())
            {
                return 1; // Conexión cerrada
            }

            try
            {
                // Consulta principal para obtener los datos del cliente
                string sql = "SELECT ayb.nombre_ayb, h.precio_hace " +
                    "FROM Alineacion_Balanceo ayb " +
                    "JOIN Hace h ON ayb.id_ayb = h.id_ayb " +
                    "JOIN Factura f ON f.id_factura = h.id_factura " +
                    "WHERE f.factura_paga = '0' AND f.matricula = '" + matricula + "';";

                // Ejecutamos la consulta
                DataTable dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count == 0)
                {
                    return 3; // No encontrado un cliennte
                }

                // Asignar valores desde la consulta
                DataRow row = dt.Rows[0];
                aybNombre = row["nombre_ayb"].ToString();
                aybPrecio = Convert.ToDouble(row["precio_hace"]);

                sql = "SELECT l.nombre_lavado, u.precio_usa " +
                    "FROM Lavado l " +
                    "JOIN Usa u ON l.id_lavado = u.id_lavado " +
                    "JOIN Factura f ON f.id_factura = u.id_factura " +
                    "WHERE f.factura_paga = '0' AND f.matricula = '" + matricula + "';";

                dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count == 0)
                {
                    return 4; // No encontrado un cliennte
                }

                row = dt.Rows[0];
                lavadoNombre = row["nombre_lavado"].ToString();
                lavadoPrecio = Convert.ToDouble(row["precio_usa"]);

                sql = "SELECT n.nombre_neumatico, c.precio_compra, c.cantidad_compra " +
                    "FROM Neumatico n " +
                    "JOIN Compra c ON n.id_neumatico = c.id_neumatico " +
                    "JOIN Factura f ON f.id_factura = c.id_factura " +
                    "WHERE f.factura_paga = '0' AND f.matricula = '" + matricula + "';";

                dt = _conexion.EjecutarSelect(sql);

                if (dt.Rows.Count == 0)
                {
                    return 5; // No encontrado un cliennte
                }

                row = dt.Rows[0];
                neumaticoNombre = row["nombre_neumatico"].ToString();
                neumaticoPrecio = Convert.ToDouble(row["precio_compra"]);
                neumaticoCantidad = Convert.ToInt32(row["cantidad_compra"]);
            }
            catch
            {
                return 2; // Error en la ejecución de la consulta
            }
            return resultado; // Todo funciono correctamente
        }
    }
}
