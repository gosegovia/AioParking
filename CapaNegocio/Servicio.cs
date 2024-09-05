using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using System.Data;

namespace CapaNegocio
{
    public class Servicio
    {
        protected int _lavado;
        protected bool _montaje;
        protected bool _ayb;
        protected int _alineacion;
        protected int _balanceo;
        protected Conexion _conexion;

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

        public Conexion Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public Servicio()
        {
            _lavado = 0;
            _montaje = false;
            _ayb = false;
            _alineacion = 0;
            _balanceo = 0;
            _conexion = new Conexion(); ;
        }

        public Servicio(int l, bool mon, bool ayb, int al, int bal, Conexion cn)
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
            DataTable dt;
            byte resultado = 0;

            if (!_conexion.Abierta())
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
                    dt = Conexion.EjecutarSelect(sql);
                }
                catch
                {
                    return 2; // Error en la ejecución
                }

                if (dt.Rows.Count == 0)
                {
                    resultado = 3; // No encontrado
                }
            }
            return resultado;
        }
    }
}
