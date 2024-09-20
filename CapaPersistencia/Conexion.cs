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

        public int Ejecutar(string sql)
        {
            int filasAfectadas = 0;

            try
            {
                _cn.Execute(sql, out object resultado);
                filasAfectadas = Convert.ToInt32(resultado); // Convertir el objeto a int
            }
            catch
            {
                filasAfectadas = -1; // Usamos -1 para indicar un error en la ejecución
            }

            return filasAfectadas; // Retorna el número de filas afectadas
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

        public object EjecutarEscalar(string sql)
        {
            object resultado = null;
            ADODB.Recordset rs = new ADODB.Recordset();
            object filasAfectadas;

            try
            {
                // Ejecutar la consulta SQL
                rs = _cn.Execute(sql, out filasAfectadas, -1);

                // Si hay resultados, obtener el primer valor de la primera fila
                if (!rs.EOF)
                {
                    resultado = rs.Fields[0].Value;
                }
            }
            catch
            {
                // Aquí podrías capturar la excepción y hacer algo con ella si es necesario
                throw;
            }
            finally
            {
                // Cerrar el recordset si está abierto
                if (rs.State == 1)
                {
                    rs.Close();
                }
            }

            return resultado;
        }

    }
}
