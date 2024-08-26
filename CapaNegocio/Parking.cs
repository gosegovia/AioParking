using ADODB;
using System;
using System.Data;

namespace CapaNegocio
{
    public class Parking
    {
        protected int _plaza;
        protected int _parking;
        protected string _estadoPlaza;
        protected Connection _conexion;

        public int Plaza
        {
            get { return _plaza; }
            set { _plaza = value; }
        }

        public int ParkingID
        {
            get { return _parking; }
            set { _parking = value; }
        }

        public string EstadoPlaza
        {
            get { return _estadoPlaza; }
            set { _estadoPlaza = value; }
        }

        public ADODB.Connection Conexion
        {
            set { _conexion = value; }
            get { return _conexion; }
        }

        public Parking()
        {
            _plaza = 0;
            _parking = 0;
            _estadoPlaza = "";
            _conexion = new Connection();
        }

        public Parking(int plaza, int parking, string estado, Connection conexion)
        {
            _plaza = plaza;
            _parking = parking;
            _estadoPlaza = estado;
            _conexion = conexion;
        }

        public DataTable ObtenerPlazas()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT nro_plaza, estado_plaza FROM Plaza"; // Consulta actualizada para MySQL

            Recordset rs = new Recordset();

            try
            {
                rs.Open(sql, _conexion, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, -1);

                // Agregar columnas al DataTable
                dt.Columns.Add("Número Plaza");
                dt.Columns.Add("Estado Plaza");

                // Llenar el DataTable con los datos del Recordset
                while (!rs.EOF)
                {
                    DataRow row = dt.NewRow();
                    row["Número Plaza"] = rs.Fields["nro_plaza"].Value;
                    row["Estado Plaza"] = rs.Fields["estado_plaza"].Value;
                    dt.Rows.Add(row);
                    rs.MoveNext();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de plazas: " + ex.Message);
            }
            finally
            {
                // Cerrar y liberar el Recordset
                if (rs != null && rs.State == 1) // 1 indica que el Recordset está abierto
                {
                    rs.Close();
                }
            }

            return dt;
        }

    }
}
