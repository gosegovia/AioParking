using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using CapaPersistencia;

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
        public static EjecutivoServicios.Parkings frmParking;
        public static EjecutivoServicios.Servicios frmServicios;
        public static EjecutivoServicios.VentaNeumaticos frmVentaNeumaticos;
        // Formulario de Jefe de servicios
        public static JefeServicios.ABMEmpleado frmABMEmpleado;
        public static JefeServicios.ListarEmpleado frmListarEmpleado;
        // Formulario de Gerentes
        public static Gerente.PrecioServicios frmPrecioServicios;
        // Formulario de Cajero
        public static Cajero.Facturas frmFactura;
        public static Cajero.ListarFacturas frmListarFactura;
        // Formulario de Operador de Camaras
        public static OperadorCamaras.AsignarPlaza frmAsignarPlaza;

        // Creamos la coneccion con la base de datos
        public static Conexion con = new Conexion();

        // Para que no haya mas de una aplicacion iniciada
        static Mutex mutex = new Mutex(true, "{CapaPresentacion}");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                frmPrincipal = new Principal();
                Application.Run(frmPrincipal);

                mutex.ReleaseMutex();
            } else
            {
                MessageBox.Show("La aplicación ya está en ejecución.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para saber que tipo de usuario ingreso al programa y dar permisos
        // Inicio doyPermisos
        public static void doyPermisos(string usuario)
        {
            // Sentencia sql
            string sql;
            // Almacenar el resultado del select(está almacenado en la memoria de la máquina del cliente)
            DataTable dt;
            // Guardamos el rol que obtengamos
            byte rol = 0;
            // Guardamos el nombre y el apellido
            int ci;
            string nombre = null;
            string apellido = null;

            // cn.state (estado de la conexión)
            // cn.State != 0 (conexión abierta)
            if (con.Abierta())
            {
                // Sentencia sql para obtener el rol, nombre y apellido

                /* 
                * Utilizamos 2 tablas la tabla empleado donde tenemos guardado el rol
                * y la tabla persona donde está el nombre y el apellido de la persona
                * si la cédula da igual en ambas tablas. 
                * Utilizando la condición que si el usuario que ingresamos al logearnos
                * existe en la tabla empleado se va a complir toda la condicion
               */
                sql = "SELECT Empleado.id_rol, Persona.ci, Persona.nombre, Persona.apellido " +
                             "FROM Empleado " +
                             "JOIN Persona ON Empleado.ci = Persona.ci " +
                             "WHERE Empleado.usuario = '" + usuario + "'";

                try
                {
                    // Ejecutó la sentencia y guardo las filas afectadas
                    dt = con.EjecutarSelect(sql);
                }
                catch
                {
                    // Si no se pudo da error
                    MessageBox.Show("Hubo un problema al obtener el rol del usuario.");
                    return;
                }

                // Si rol == 0  significa que no tiene un rol asignado
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario sin rol asignado. Avise al admin del sistema");
                }
                else // Encontre un registro, buscamos por la clave primaria
                {
                    // Cambiamos el tipo de dato a byte
                    rol = Convert.ToByte(dt.Rows[0][0]);
                    // Obtenemos el nombre y apellido
                    ci = Convert.ToInt32(dt.Rows[0][1]);
                    nombre = Convert.ToString(dt.Rows[0][2]);
                    apellido = Convert.ToString(dt.Rows[0][3]);

                    
                    // Según el rol de el cliente mostramos lo que necesite
                    switch (rol)
                    {
                        case 1: // Operador de camaras
                            // Muestro el formulario a el menú op cámara
                            frmPrincipal.menuOpCamara();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, ci, nombre, apellido);
                            break;
                        case 2: // Cajero
                            // Muestro el formulario a el menú cajero
                            frmPrincipal.menuCajero();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, ci, nombre, apellido);
                            break;
                        case 3: // Ejecutivo de Servicios
                            // Muestro el menú izquierda
                            frmPrincipal.mostrarMenu();
                            // Muestro el menú inicial
                            frmPrincipal.menuInicial();
                            // Doy permiso a sus botones
                            frmPrincipal.botonesEjecutivo();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, ci, nombre, apellido);
                            break;
                        case 4: // Jefe de Servicios
                            // Muestro el menú izquierda
                            frmPrincipal.mostrarMenu();
                            // Muestro el menú inicial
                            frmPrincipal.menuInicial();
                            // Doy permiso a sus botones
                            frmPrincipal.botonesJefeServicio();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, ci, nombre, apellido);
                            break;
                        case 5: // Gerente
                            // Muestro el menú izquierda
                            frmPrincipal.mostrarMenu();
                            // Muestro el menú inicial
                            frmPrincipal.menuInicial();
                            // Doy permiso a sus botones
                            frmPrincipal.botonesGerente();
                            // Muestro el rol, nombre y apellido del empleado
                            frmPrincipal.datosEmpleado(rol, ci, nombre, apellido);
                            break;
                    }
                }
            }
        } // Fin doyPermisos
    }
}