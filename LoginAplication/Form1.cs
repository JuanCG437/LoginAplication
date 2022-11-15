using System;
using System.Data;
using System.Data.SqlClient;//Hacemos uso de la libreria Data.SqlClient que nos permitiria una conexion a SQL server
using System.Windows.Forms;

namespace LoginAplication
{
    public partial class Form1 : Form
    {
        //Conexion a la base de datos a traves de la instancia del objeto SqlConnection
        SqlConnection conexion = new SqlConnection("Server = PC\\EQUIPO ; Database = SISTEMA ; INTEGRATED SECURITY = true");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            //Cerramos el formulario actual
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //Para habilitar la conexion con la base de datos
            conexion.Open();

            //Comando que hace la consulta a la base de datos
            SqlCommand cmd = new SqlCommand("SELECT USUARIO, PASSWORD FROM TBLPERSONA WHERE USUARIO =@user AND PASSWORD =@pass", conexion);

            //Añadimos como parametros los datos de la persona (usuario y password)
            cmd.Parameters.AddWithValue("@user", txtuser.Text);
            cmd.Parameters.AddWithValue("@pass", txtpass.Text);

            //Lector del resultado de la consulta se le asigna la ejecuciòn del comando
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                //Cerrar la conexion a la base datos
                conexion.Close();

                //Instancia hacia el segundo formulario que serà la pantalla principal
                Principal pantalla = new Principal();
                pantalla.Show();
                this.Hide();
            }

        }
    }
}
