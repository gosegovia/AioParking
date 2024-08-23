using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Servicio
    {
        protected int _lavado;
        protected bool _montaje;
        protected bool _ayb;
        protected int _alineacion;
        protected int _balanceo;
        protected Connection _conexion;

        public int lavado
        {
            set { _lavado = value; } 
            get { return (_lavado); }
        }

        public bool montaje
        {
            set { _montaje = value; }
            get { return (_montaje); }
        }

        public bool ayb
        {
            set { _ayb = value; }
            get { return (_ayb); }
        }

        public int alineacion
        {
            set { _alineacion = value; } 
            get { return (_alineacion); }   
        }

        public int balanceo
        {
            set { _balanceo = value; }
            get { return (_balanceo); }
        }

        public ADODB.Connection conexion
        {
            set { _conexion = value; }
            get { return (_conexion); }
        }
        protected Vehiculo Vehiculo { get; set; }

        public Servicio()
        {
            _lavado = 0;
            _montaje = false;
            _ayb = false;
            _alineacion = 0;
            _balanceo = 0;
            _conexion = new Connection(); ;
        }

        public Servicio(int l, bool mon, bool ayb, int al, int bal, Connection cn)
        {
            _lavado = l;
            _montaje = mon;
            _ayb = ayb;
            _alineacion = al;
            _balanceo = bal;
            _conexion = cn;
        }

        public byte BuscarServicio(string matricula)
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
                sql = "SELECT ci, matricula " +
                      "FROM Posee " +
                      "WHERE matricula = '" + matricula + "';";

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
            }
            return resultado;
        }
    }
}
