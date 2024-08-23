using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        // En la clase program declaramos los objetos para los formularios
        // Formulario principal
        public static Principal frmPrincipal;
        // Formulario login
        public static Login frmLogin;
        // Formulario inicial de la aplicacion
        public static MenuInicial frmMenuInicial;
        // Formularios de Ejecutivo de servicios
        public static EjecutivoServicios.ABMCliente frmABMCliente;
        public static EjecutivoServicios.ListarCliente frmListarCliente;
        public static EjecutivoServicios.ABMVehiculos frmABMVehiculos;
        public static EjecutivoServicios.ListarVehiculo frmListarVehiculo;
        public static EjecutivoServicios.Parking frmParking;
        public static EjecutivoServicios.Servicios frmServicios;
        public static EjecutivoServicios.VentaNeumaticos frmVentaNeumaticos;
        // Formulario de Jefe de servicios
        public static JefeServicios.ABMEmpleado frmABMEmpleado;
        public static JefeServicios.ListarEmpleado frmListarEmpleado;
        // Formulario de Gerentes
        public static Gerente.PrecioServicios frmPrecioServicios;
        // Formulario de Cajero
        public static Cajero.Factura frmFactura;
        // Formulario de Operador de Camaras
        public static OperadorCamaras.AsignarPlaza frmAsignarPlaza;

        // Creamos la coneccion con la base de datos
        public static ADODB.Connection cn = new ADODB.Connection();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            frmPrincipal = new Principal();
            Application.Run(frmPrincipal);
        }

        // Método para saber que tipo de usuario ingreso al programa y dar permisos
        // Inicio doyPermisos
        public static void doyPermisos(string usuario)
        {
            // Sentencia sql
            string sql;
            // Fila que estamos accediendo
            object filasAfectadas;
            // Almacenar el resultado del select(está almacenado en la memoria de la máquina del cliente)
            ADODB.Recordset rs;
            // Guardamos el rol que obtengamos
            byte rol = 0;
            // Guardamos el nombre y el apellido
            string nombre = null;
            string apellido = null;

            // cn.state (estado de la conexión)
            // cn.State != 0 (conexión abierta)
            if (cn.State != 0)
            {
                // Sentencia sql para obtener el rol, nombre y apellido

                /* 
                * Utilizamos 2 tablas la tabla empleado donde tenemos guardado el rol
                * y la tabla persona donde está el nombre y el apellido de la persona
                * si la cédula da igual en ambas tablas. 
                * Utilizando la condición que si el usuario que ingresamos al logearnos
                * existe en la tabla empleado se va a complir toda la condicion
               */
                sql = "SELECT Empleado.id_rol, Persona.nombre, Persona.apellido " +
                             "FROM Empleado " +
                             "JOIN Persona ON Empleado.ci = Persona.ci " +
                             "WHERE Empleado.usuario = '" + usuario + "'";

                try
                {
                    // Ejecutó la sentencia y guardo las filas afectadas
                    rs = cn.Execute(sql, out filasAfectadas);
                }
                catch
                {
                    // Si no se pudo da error
                    MessageBox.Show("Hubo un problema al obtener el rol del usuario.");
                    return;
                }

                // Si rol == 0  significa que no tiene un rol asignado
                if (rs.RecordCount == 0)
                {
                    MessageBox.Show("Usuario sin rol asignado. Avise al admin del sistema");
                }
                else // Encontre un registro, buscamos por la clave primaria
                {
                    // Cambiamos el tipo de dato a byte
                    rol = Convert.ToByte(rs.Fields[0].Value);
                    // Obtenemos el nombre y apellido
                    nombre = Convert.ToString(rs.Fields[1].Value);
                    apellido = Convert.ToString(rs.Fields[2].Value);

                    
                    // Según el rol de el cliente mostramos lo que necesite
                    switch (rol)
                    {
                        case 1: // Gerente
                            // Muestro el menú izquierda
                            frmPrincipal.mostrarMenu();
                            // Muestro el menú inicial
                            frmPrincipal.menuInicial();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, nombre, apellido);
                            break;
                        case 2: // Jefe de Servicios
                            // Muestro el menú izquierda
                            frmPrincipal.mostrarMenu();
                            // Muestro el menú inicial
                            frmPrincipal.menuInicial();
                            // Doy permiso a sus botones
                            frmPrincipal.botonesJefeServicio();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, nombre, apellido);
                            break;
                        case 3: // Ejecutivo de Servicios
                            // Muestro el menú izquierda
                            frmPrincipal.mostrarMenu();
                            // Muestro el menú inicial
                            frmPrincipal.menuInicial();
                            // Doy permiso a sus botones
                            frmPrincipal.botonesEjecutivo();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, nombre, apellido);
                            break;
                        case 4: // Cajero
                            // Muestro el formulario a el menú cajero
                            frmPrincipal.menuCajero();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, nombre, apellido);
                            break;
                        case 5: // Operador de camaras
                            // Muestro el formulario a el menú op cámara
                            frmPrincipal.menuOpCamara();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, nombre, apellido);
                            break;
                    }
                }
                // Reiniciamos las variables
                rs = null;
                filasAfectadas = null;
            }
        } // Fin doyPermisos
    }
}