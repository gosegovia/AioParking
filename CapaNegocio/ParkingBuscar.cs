using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ParkingBuscar
    {
        protected int _ci;
        protected string _matricula;
        protected DateTime _horaEntrada;
        protected DateTime _horaSalida;
        protected int _plaza;
        protected Connection _conexion;

        public int ci
        {
            set { _ci = value; }
            get { return (_ci); }
        }

        public string matricula
        {
            set { _matricula = value; }
            get { return (_matricula); }
        }

        public DateTime horaEntrada
        {
            set { _horaEntrada  = value; }
            get { return (_horaEntrada); }
        }

        public DateTime horaSalida
        {
            set { _horaSalida = value; }
            get { return (_horaSalida); }
        }

        public int plaza
        {
            set { _plaza = value; }
            get { return (_plaza); }
        }

        public ADODB.Connection conexion
        {
            set { _conexion = value; }
            get { return (_conexion); }
        }

        public ParkingBuscar()
        {
            _ci = 0;
            _matricula = "";
            _horaEntrada = default(DateTime);
            _horaSalida = default(DateTime);
            _plaza = 0;
            _conexion = new Connection();
        }

        public ParkingBuscar(int ci, string mat, DateTime he, DateTime hs, int p, Connection cn)
        {
            _ci = ci;
            _matricula = mat;
            _horaEntrada = he;
            _horaSalida = hs;
            _plaza = p;
            _conexion = cn;
        }

        // Implementación de los métodos abstractos
        public int BuscarParking(string matricula)
        {
            string sql;
            object filasAfectadas;
            Recordset rs;
            int plaza = 0; // Cambiado a int
            int resultado = 0; // Cambiado a int

            if (_conexion.State == 0)
            {
                resultado = 1; // Conexión cerrada
                return resultado;
            }

            sql = "SELECT p.nro_plaza " +
                  "FROM Vehiculo v " +
                  "JOIN Posee po ON v.matricula = po.matricula " +
                  "JOIN Factura f ON po.ci = f.ci " +
                  "JOIN Solicita s ON f.id_factura = s.id_factura " +
                  "JOIN Plaza p ON s.id_plaza = p.id_plaza " +
                  "WHERE v.matricula = '" + matricula + "'";

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
                rs.MoveFirst();
                plaza = Convert.ToInt32(rs.Fields["nro_plaza"].Value);
            }

            return resultado;
        }

    }
}
