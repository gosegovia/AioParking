using CapaPresentacion;
using System.Windows.Forms;
using System;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        private string _rol; // Campo privado

        public string Rol
        {
            get { return _rol; } // Retorna el valor del campo
            set { _rol = value; } // Asigna el valor al campo
        }

        public Principal()
        {
            InitializeComponent();
            // Cuando inicia oculta el panel izquierdo y los botones
            pIzquierda.Visible = false;
            pBotones.Visible = false;
        }

        // Carga de la aplicación
        private void Principal_Load(object sender, EventArgs e)
        {
            // Creó el objeto para el formulario login
            Program.frmLogin = new Login();
            // Dice que frmLogin va a estar contenido como formulario dentro del formulario principal
            Program.frmLogin.MdiParent = this;
            // Traigo el frmLogin al frente
            Program.frmLogin.BringToFront();
            // Ajusta el contenido de frmLogin para llenar completamente el área del formulario principal
            Program.frmLogin.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmLogin.Show();
        } // Fin carga de la aplicación

        // Inicio OcultarMenu
        public void mostrarMenu()
        {
            // Mostramos el menu de la izquierda
            pIzquierda.Visible = !pIzquierda.Visible;
            pBotones.Visible = true;
        } // Fin OcultarMenu

        // Método para mostrar los datos de empleados
        public void datosEmpleado(int rol, string nom, string ape)
        {
            // Obtenemos el rol que están de los números del 1-5
            // Y según su número le asignamos el nombre
            switch (rol)
            {
                case 1:
                    lblRol.Text = "Gerente";
                    Rol = "Gerente";
                    break;
                case 2:
                    lblRol.Text = "Jefe Servicio";
                    Rol = "Jefe Servicio";
                    break;
                case 3:
                    lblRol.Text = "Ejecutivo";
                    Rol = "Ejecutivo";
                    break;
                case 4:
                    lblRol.Text = "Cajero";
                    Rol = "Cajero";
                    break;
                case 5:
                    lblRol.Text = "Operador";
                    Rol = "Operador";
                    break;
            }

            // Luego asignamos también el nombre y apellido de la persona
            lblPersona.Text = nom + " " + ape;
        } // fin de mostrar datos empleados

        // Inicio menuInicial
        public void menuInicial()
        {
            // Creó el objeto para frmMenuInicial
            Program.frmMenuInicial = new MenuInicial();
            // Dice que frmMenuInicial va a estar contenido como formulario dentro del formulario principal
            Program.frmMenuInicial.MdiParent = this;
            // Ajusta el contenido de frmMenuInicial para llenar completamente el área del formulario principal
            Program.frmMenuInicial.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmMenuInicial.Show();
        } // Fin menuInicial

        // Inicio menuOpCamara
        public void menuOpCamara()
        {
            // Muestro el panel izquierdo pero no los botones
            pIzquierda.Visible = true; pBotones.Visible = false;
            // Creó el objeto para frmAsignarPlaza
            Program.frmAsignarPlaza = new OperadorCamaras.AsignarPlaza();
            // Dice que frmAsignarPlaza va a estar contenido como formulario dentro del formulario principal
            Program.frmAsignarPlaza.MdiParent = this;
            // Ajusta el contenido de frmAsignarPlaza para llenar completamente el área del formulario principal
            Program.frmAsignarPlaza.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmAsignarPlaza.Show();
        } // Fin menuOpCamara

        // Inicio menuCajero
        public void menuCajero()
        {
            // Muestro el panel izquierdo pero no los botones
            pIzquierda.Visible = true; pBotones.Visible = false;
            // Creó el objeto para frmFactura
            Program.frmFactura = new Cajero.Factura();
            // Dice que frmFactura va a estar contenido como formulario dentro del formulario principal
            Program.frmFactura.MdiParent = this;
            // Ajusta el contenido de frmFactura para llenar completamente el área del formulario principal
            Program.frmFactura.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmFactura.Show();
        } // Inicio menuCajero
   
        // Botón mostrar clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Creó el objeto para el formulario frmABMCliente
            Program.frmABMCliente = new EjecutivoServicios.ABMCliente();
            // Dice que frmABMCliente va a estar contenido como formulario dentro del formulario principal
            Program.frmABMCliente.MdiParent = this;
            // Ajusta el contenido de frmABMCliente para llenar completamente el área del formulario principal
            Program.frmABMCliente.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmABMCliente.Show();
        } // Fin botón mostrar clientes

        // Botón servicios
        private void btnServicios_Click(object sender, EventArgs e)
        {
            // Creó el objeto para el formulario frmServicios
            Program.frmServicios = new EjecutivoServicios.Servicios();
            // Dice que frmServicios va a estar contenido como formulario dentro del formulario principal
            Program.frmServicios.MdiParent = this;
            // Ajusta el contenido de frmServicios para llenar completamente el área del formulario principal
            Program.frmServicios.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmServicios.Show();
        } // Fin botón servicios

        // Botón neumaticos
        private void btnNeumaticos_Click(object sender, EventArgs e)
        {
            // Creó el objeto para el formulario frmVentaNeumaticos
            Program.frmVentaNeumaticos = new EjecutivoServicios.VentaNeumaticos();
            // Dice que frmVentaNeumaticos va a estar contenido como formulario dentro del formulario principal
            Program.frmVentaNeumaticos.MdiParent = this;
            // Ajusta el contenido de frmVentaNeumaticos para llenar completamente el área del formulario principal
            Program.frmVentaNeumaticos.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmVentaNeumaticos.Show();
        } // Fin botón neumaticos

        // Botón parking
        private void btnParking_Click(object sender, EventArgs e)
        {
            // Creó el objeto para el formulario frmParking
            Program.frmParking = new EjecutivoServicios.Parkings();
            // Dice que frmParkign va a estar contenido como formulario dentro del formulario principal
            Program.frmParking.MdiParent = this;
            // Ajusta el contenido de frmParking para llenar completamente el área del formulario principal
            Program.frmParking.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmParking.Show();
        } // Fin botón parking

        // Botón empleados
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            // Creó el objeto para el formulario frmABMEmpleado
            Program.frmABMEmpleado = new JefeServicios.ABMEmpleado();
            // Dice que frmABMEmpleado va a estar contenido como formulario dentro del formulario principal
            Program.frmABMEmpleado.MdiParent = this;
            // Ajusta el contenido de frmABMEmpleado para llenar completamente el área del formulario principal
            Program.frmABMEmpleado.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmABMEmpleado.Show();
        } // Fin botón empleados

        // Botón precio
        private void btnPrecio_Click(object sender, EventArgs e)
        {
            // Creó el objeto para el formulario frmPrecioServicios
            Program.frmPrecioServicios = new Gerente.PrecioServicios();
            // Dice que frmPrecioServicios va a estar contenido como formulario dentro del formulario principal
            Program.frmPrecioServicios.MdiParent = this;
            // Ajusta el contenido de frmPrecioServicios para llenar completamente el área del formulario principal
            Program.frmPrecioServicios.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmPrecioServicios.Show();
        } // Fin botón precio

        // Botón Vehículo
        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            // Creó el objeto para el formulario frmABMVehiculos
            Program.frmABMVehiculos = new EjecutivoServicios.ABMVehiculos();
            // Dice que frmABMVehiculos va a estar contenido como formulario dentro del formulario principal
            Program.frmABMVehiculos.MdiParent = this;
            // Ajusta el contenido de frmABMVehiculos para llenar completamente el área del formulario principal
            Program.frmABMVehiculos.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmABMVehiculos.Show();
        } // Fin botón vehículo

        // Listar Clientes
        public void mostrarListarCliente()
        {
            // Creó el objeto para frmListarCliente
            Program.frmListarCliente = new EjecutivoServicios.ListarCliente();
            // Dice que frmListarCliente va a estar contenido como formulario dentro del formulario principal
            Program.frmListarCliente.MdiParent = this;
            // Ajusta el contenido de frmListarCliente para llenar completamente el área del formulario principal
            Program.frmListarCliente.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmListarCliente.Show();
        } // Fin Listar clientes

        // Listar Vehículos
        public void mostrarListarVehiculo()
        {
            // Creó el objeto para frmListarVehiculo
            Program.frmListarVehiculo = new EjecutivoServicios.ListarVehiculo();
            // Dice que frmListarVehiculo va a estar contenido como formulario dentro del formulario principal
            Program.frmListarVehiculo.MdiParent = this;
            // Ajusta el contenido de frmListarVehiculo para llenar completamente el área del formulario principal
            Program.frmListarVehiculo.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmListarVehiculo.Show();
        } // Fin listar vehículos

        // Listar Empleado
        public void mostrarListarEmpleado()
        {
            // Creó el objeto para frmListarEmpleado 
            Program.frmListarEmpleado = new JefeServicios.ListarEmpleado();
            // Dice que frmListarEmpleado va a estar contenido como formulario dentro del formulario principal
            Program.frmListarEmpleado.MdiParent = this;
            // Ajusta el contenido de frmListarEmpleado para llenar completamente el área del formulario principal
            Program.frmListarEmpleado.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmListarEmpleado.Show();
        } // Fin listar empleado

        // Listar Factura
        public void mostrarListarFactura()
        {
            // Creó el objeto para frmListarEmpleado 
            Program.frmListarFactura = new Cajero.ListarFactura();
            // Dice que frmListarEmpleado va a estar contenido como formulario dentro del formulario principal
            Program.frmListarFactura.MdiParent = this;
            // Ajusta el contenido de frmListarEmpleado para llenar completamente el área del formulario principal
            Program.frmListarFactura.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmListarFactura.Show();
        } // Fin listar empleado

        // BOTONES    

        // Acceso a botonesJefeServicio
        public void botonesJefeServicio()
        {
            /* Cambio los estados para que cuando el jefe de servicios entre a la aplicación
             tenga solo los botones que él necesita */
            btnPrecio.Visible = !btnPrecio.Visible;
        } // Fin acceso a botonesJefeServicio

        // Acceso a botonesEjecutivo
        public void botonesEjecutivo()
        {
            /* Cambio los estados para que cuando el jefe de servicios entre a la aplicación
             tenga solo los botones que él necesita */
            btnPrecio.Visible = !btnPrecio.Visible;
            btnEmpleados.Visible = !btnEmpleados.Visible;
        } // Fin acceso a botonesEjecutivo
        
        // Botón para cerrar la aplicación
        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        } // Fin botón cerrar

        // Botón para minimizar la aplicación
        private void lblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        } // Fin botón minimizar

        // Carga el menu inicial
        private void btnInicio_Click(object sender, EventArgs e)
        {
            menuInicial();
        } // Fin Carga el menu inicial

        // Metodo para deslogearse de la aplicación
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Llamamos al metodo para que se oculte el panel qIzquierda y los botones
            mostrarMenu();
            // Cierro la conexión con la base de datos
            Program.con.Cerrar();
            // Creó el objeto para el formulario login
            Program.frmLogin = new Login();
            // Dice que frmLogin va a estar contenido como formulario dentro del formulario principal
            Program.frmLogin.MdiParent = this;
            // Traigo el frmLogin al frente
            Program.frmLogin.BringToFront();
            // Ajusta el contenido de frmLogin para llenar completamente el área del formulario principal
            Program.frmLogin.Dock = DockStyle.Fill;
            // Al final mostramos el formulario
            Program.frmLogin.Show();
        } // Fin de metodo para deslogearse de la aplicación
    }
}