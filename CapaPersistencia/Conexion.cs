using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace CapaPersistencia
{
    public class Conexion
    {
        protected ADODB.Connection _cn;

        public Conexion()
        {
            _cn = new ADODB.Connection();
        }

        public Boolean Abrir(string stringConexion, String usuario, String contrasenia)
        {
            Boolean resultado = true;

            try
            {
                _cn.Open(stringConexion, usuario, contrasenia, -1);
                _cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
            }
            catch
            {
                resultado = false;
            }
            return (resultado);
        }

        public Boolean Cerrar()
        {
            Boolean resultado = true;

            try
            {
                _cn.Close();
            }
            catch
            {
                resultado = false;
            }
            return (resultado);

        }

        public Boolean Ejecutar(string sql)
        {
            Boolean resultado = true;
            object filasAfectadas;

            try
            {
                _cn.Execute(sql, out filasAfectadas);
            }
            catch
            {
                resultado = false;
            }

            return (resultado);
        }

        public DataTable EjecutarSelect(string sql)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            ADODB.Recordset rs = new ADODB.Recordset();
            object FilasAfectadas;

            try
            {
                rs = _cn.Execute(sql, out FilasAfectadas);
            }
            catch
            {
                // El que ejecute el metodo EjecutarSelect va a tener que capturar la excepcion
                throw;
            }

            da.Fill(dt, rs); // Convierte un recordser en un data table

            return (dt);
        }

        public Boolean Abierta()
        {
            Boolean resultado = true;

            try
            {
                if (_cn.State == 0)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
            }
            catch
            {
                resultado = false;
            }
            return (resultado);
        }
    }
}
